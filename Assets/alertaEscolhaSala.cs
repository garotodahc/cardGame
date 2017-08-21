using UnityEngine;
using System.Collections;

public class alertaEscolhaSala : MonoBehaviour {
	public string nomeDaSala;
	public GameObject painelDeAcoes;
	public GameObject textoEntrandoSala;

	public void confirmar(){

		gameObject.SetActive (false);
		painelDeAcoes.SetActive (false);
		textoEntrandoSala.SetActive (true);
		PhotonNetwork.JoinRoom (nomeDaSala);
	}

	public void cancelar(){
		gameObject.SetActive (false);
	}
}
