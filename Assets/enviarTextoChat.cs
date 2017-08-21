using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class enviarTextoChat : MonoBehaviour {
	public GameObject textoObj;
	public GameObject falaPrefab;
	public string hora;

	public void enviar(){
		string texto = textoObj.GetComponent<Text> ().text;

		//pegar os dados do jogador
		GameObject dadosJogadorObj = GameObject.FindGameObjectWithTag ("informacoesJogador");
		dados dadosJ = dadosJogadorObj.GetComponent<dados> ();

		string nome = dadosJ.nome;
		string avatar = dadosJ.avatar;
		string[] data = DateTime.Now.ToString ().Split(' ');
		string[] horaSeg = data [1].Split(':');
		hora = horaSeg [0] + ":" + horaSeg [1] + " " + data [2];

	}
}
