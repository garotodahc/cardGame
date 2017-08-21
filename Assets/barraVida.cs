using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class barraVida : MonoBehaviour {

	public List<Sprite> barras;

	void Update () {

		GameObject p1ou2 = GameObject.Find ("player1ou2") as GameObject;
		bool player1 = p1ou2.GetComponent<p1ou2> ().player1;

		GameObject[] jogadores = GameObject.FindGameObjectsWithTag("informacoesJogador");

		foreach (GameObject jogador in jogadores) {

			if(jogador.GetComponent<informacoesJogador>().player1 == player1){

				int pontosDeVida = jogador.GetComponent<informacoesJogador>().pontosDeVida;
				int imagemN = pontosDeVida -1;
				gameObject.GetComponent<Image>().sprite = barras[imagemN];
			}
		}
		
	}
}
