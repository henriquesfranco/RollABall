/*
 * Autor: Henrique Santos Franco
 * Descrição: Script responsável por recalcular o timer a cada frame
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	public Text timerText; //variável pública para controlar o texto do timer
	public static float timeLeft; //variável estática (válida em todas as classes que for instanciada) que armazena o tempo restante
	public Text LostText; //Mesmo texto utilizado para vencer, mas que aqui é aplicado quando o jogador perde por falta de tempo

	// Use this for initialization
	void Start () {
		timeLeft = 30.0f; //Inicializa o contador de tempo quando o jogo inicia em 30 segundos
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime; //deltaTime calcula o tempo decorrido entre os frames e decrementa do tempo restante
		if (timeLeft < 0 && !PlayerController.won) { //Se o tempo restante é menor que zero, informar que o jogador perdeu
			//A variável won permite verificar se o jogo foi vencido antes do tempo acabar, caso o jogador demore pra pressionar enter

			LostText.text = "Ooops! You were not fast enough! Press Enter to restart or ESC to exit.";

			if (Input.GetKeyDown (KeyCode.Escape)) { //Se o jogador pressionar ESC o jogo volta ao menu (scene 0)
				SceneManager.LoadScene (0);
			} else if (Input.GetKeyDown (KeyCode.Return)) { //Se o jogador pressionar Enter(Return) o jogo reinicia (scene 2)
				Scene thisScene = SceneManager.GetActiveScene ();
				SceneManager.LoadScene (thisScene.name);
			}
		} else {
            //No comando abaixo é utilizado um cast (int) para que apenas a fração inteira do número seja apresentada.
			timerText.text = "Time Left: " + ((int)timeLeft % 60).ToString ();
		}
	}
}
