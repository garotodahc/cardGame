using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ativarAlerta2 : MonoBehaviour {

	public void ativar(){
		GameObject controlador = GameObject.Find ("controlador");
		GameObject alerta2 = controlador.GetComponent<objAlerta> ().alerta2;
		alerta2.GetComponent<alertaJogadores> ().nomeJogador = gameObject.GetComponent<objetosBtnJogP> ().objNome.GetComponent<Text> ().text;
		alerta2.SetActive (true);
	}
}
