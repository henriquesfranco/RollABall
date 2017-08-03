/*
 * Autor: Henrique Santos Franco
 * Descrição: Código utilizado para controlar a posição da câmera durante o jogo
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //O objeto abaixo representa o jogador (a bola)
    //Ele é necessário para capturar sua posição e ajustar a posição da câmera
	public GameObject player;

    //Variável que irá armazenar a distância entre a câmera e o jogador
	private Vector3 offset;

	// Use this for initialization
	void Start () {
        //Somente na inicialização é preciso calcular o offset, pois ele é constante
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        //A cada frame, após todos os outros elementos carregarem,
        //A nova posição da câmera é calculada com base na posição do jogador
        //mais o offset, mantendo sempre a mesma distância
		transform.position = player.transform.position + offset;
	}
}
