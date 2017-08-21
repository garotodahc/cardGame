using UnityEngine;
using System.Collections;

public class iniciarBatalha : MonoBehaviour {

	public int numCartaG; 
	private GameObject[] jogadores;
	public GameObject aguarde;

	public void batalhar(){

		GameObject player1ou2 = GameObject.Find("player1ou2");
		bool player1 = player1ou2.GetComponent<p1ou2> ().player1;

		jogadores = GameObject.FindGameObjectsWithTag("informacoesJogador");

		foreach (GameObject jogador in jogadores) {

			if(player1 == jogador.GetComponent<informacoesJogador>().player1){


				string numDoGueString = numCartaG.ToString();
				jogador.GetComponent<informacoesJogador>().NumGuerreiro = numDoGueString;
				jogador.GetComponent<informacoesJogador>().batalhar = true;
				aguarde.SetActive(true);
			}
		}
	}
}
