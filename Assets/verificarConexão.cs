using UnityEngine;
using System.Collections;

public class verificarConexão : MonoBehaviour {

	public bool conectado;
	public bool mudar;

	void Update(){
		if (conectado) {
			GameObject[] jogadores = GameObject.FindGameObjectsWithTag("informacoesJogador");

			if(jogadores.Length == 2){
				Application.LoadLevel("cena1");
			}
		}
	}
}
