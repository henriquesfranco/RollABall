/*
 * Autor: Henrique Santos Franco
 * Descrição: Código associado ao botão de seleção do menu
 * Sua função é capturar o valor do level e abri-lo
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadOnClick : MonoBehaviour {
	//Essa classe é utilizada somente para chamar o método abaixo
    //O botão utiliza sua função On Click para chamar o método LoadScene
    public void LoadScene(int level)
	{
        //A variável level está associada ao botão, que passa o parâmetro de qual nível está a carregar
		SceneManager.LoadScene (level);
	}
}
