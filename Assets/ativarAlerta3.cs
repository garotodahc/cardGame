using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ativarAlerta3 : MonoBehaviour {
	
	public void ativar(){
		GameObject controlador = GameObject.Find ("controlador");
		GameObject alerta3 = controlador.GetComponent<objAlerta> ().alerta3;
		alerta3.GetComponent<alertaEscolhaSala> ().nomeDaSala = gameObject.GetComponent<objetosBtnJogP> ().objNomeSala.GetComponent<Text> ().text;
		alerta3.SetActive (true);
	}
}
