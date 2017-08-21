using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ativarAlertaJogadores : MonoBehaviour {
	public GameObject alerta;

	public void ativarAlerta(){
		GameObject parente = gameObject.transform.parent.gameObject;
		string nomeJogador = parente.GetComponent<objetosBtnJogP> ().objNome.GetComponent<Text>().text;

		GameObject controlador = GameObject.Find("controlador");
		alerta = controlador.GetComponent<objAlerta> ().alerta;
		alerta.GetComponent<alertaJogadores> ().nomeJogador = nomeJogador;
		alerta.SetActive (true);
	}
}
