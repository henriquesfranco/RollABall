/*
 * Autor: Henrique Santos Franco
 * Descrição: Script vinculado ao player(bola) e é responsável por tratar seus movimentos,
 * colisões e computar resultados
 */
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed; //variável pública que representa a velocidade de movimento da bola
	public Text countText; //variável pública que permite modificar o texto de contagem
	public Text winText; //variável pública que permite modificar o texto de vitória ou derrota

	private Rigidbody rb; //rigid body do próprio player, possibilita a aplicação da física sobre o mesmo
	private int count; //contador para número de objetos capturados
	public static bool won; //variável para controlar se o jogador venceu ou não

    //Executado na inicialização
	void Start ()
	{
		rb = GetComponent<Rigidbody>(); 
		count = 0; //Contador deve começar nulo
		SetCountText();
		winText.text = "";
        Timer.timeLeft = 30.0f; //Esse timer evita que o jogo reinicie com o tempo zerado
		won = false;
	}

	void FixedUpdate ()
	{
		/*Movimento para setas do computador*/
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

        //Criação do vetor de movimento a partir das teclas detectadas
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed); //Aplicação da força para gerar a transformação

        //Verifica a condição de fim do jogo: pegou todas as bolas e, caso seja o nível com tempo, ainda está dentro do tempo
		//O tempo continua rodando quando o jogo é vencido, então a variável won sobrepõe a condição de vitória
		if ((count >= 16 && Timer.timeLeft >= 0.0f) || won) {
			if (Input.GetKeyDown (KeyCode.Return)) { //Verifica se a tecla Enter(Return) foi pressionada
				SceneManager.LoadScene (0); //Carrega a Scene 0, ou menu
			}
		}
	}

    //O método OnTriggerEnter é acionado quando ocorre uma colisão que, neste caso, é com um cubo
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {//A tag Pick Up, associada ao cubo, é utilizada para saber se o objeto em que houve a colisão é, de fato, o cubo.
			other.gameObject.SetActive (false); //O cubo é deixado como inativo, o que o remove da scene
			count++; //O contador é incrementado
			SetCountText(); //A função que escreve o contador é corrigida

            //Aplica o texto para quando o jogador vence
			//O tempo continua rodando quando o jogo é vencido, então a variável won sobrepõe a condição de vitória
			if ((count >= 16 && Timer.timeLeft >= 0.0f) || won) {
				winText.text = "You Win! Press Enter to return";
				won = true;
			}
		}
	}

    //Método para setar o texto do contador, utilizado no FixedUpdate
	void SetCountText(){
		countText.text = "Count: " + count.ToString (); //count.ToString deve ser utilizado pois count é inteiro, e não uma string.
	}
}