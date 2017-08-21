using UnityEngine;
using System.Collections;

public class verificarFimVP : MonoBehaviour {

	public bool fim;
	public string VP = "";

	// Update is called once per frame
	void Update () {
		GameObject p12 = GameObject.Find ("player1ou2") as GameObject;
		bool player1 = p12.GetComponent<p1ou2> ().player1;

		GameObject[] jogadores = GameObject.FindGameObjectsWithTag ("informacoesJogador");
		foreach (GameObject jog in jogadores) {
			int pontosDeVida = jog.GetComponent<informacoesJogador>().pontosDeVida;
			if(pontosDeVida == 0){
				fim = true;
				if(player1 == jog.GetComponent<informacoesJogador>().player1){
					Application.LoadLevel("perdeu");
				}else{
					Application.LoadLevel("venceu");
				}
			}
		}



	}
}
