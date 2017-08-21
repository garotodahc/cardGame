using UnityEngine;
using System.Collections;

public class verificarInicioDaBatalha : MonoBehaviour {

	private GameObject[] jogadores;

	void Update () {
		jogadores = GameObject.FindGameObjectsWithTag("informacoesJogador");

		int contBatalha = 0;
		foreach (GameObject jogador in jogadores) {
			
			if(jogador.GetComponent<informacoesJogador>().batalhar && jogador.GetComponent<informacoesJogador>().NumGuerreiro != ""){
				
				contBatalha++;

			}
		}
		if (contBatalha == 2) {
			Invoke("mudarCena", 1);

		}
	}

	void mudarCena(){
		Application.LoadLevel("cena2");
	}
}
