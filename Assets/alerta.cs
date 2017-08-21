using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class alerta : MonoBehaviour {

	public GameObject texto;
	public int numTexto;
	public void retirar(){
		gameObject.SetActive (false);
	}

	void Update(){
		if (numTexto == 0) {
			texto.GetComponent<Text> ().text = "O NOME DO JOGADOR NAO PODE FICAR EM BRANCO";
		} else if (numTexto == 1) {
			texto.GetComponent<Text> ().text = "ESTE NOME DE JOGADOR JA EXISTE";
		}
	}
}
