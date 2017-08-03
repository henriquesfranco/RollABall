/*
 * Autor: Henrique Santos Franco
 * Descrição: Código associado aos cubos responsável por sua rotação
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        //A cada frame a linha abaixo rotaciona o cubo com base no tempo decorrido
        //Utilizar o tempo em vez de um valor fixo dá fluidez ao movimento
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);		
	}
}
