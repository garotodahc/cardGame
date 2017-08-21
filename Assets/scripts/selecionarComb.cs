using UnityEngine;
using System.Collections;

public class selecionarComb : MonoBehaviour {

	private bool marcou = false;
	private GameObject controladorComb;
	private string fc;

	void OnMouseDown(){

		fc = gameObject.GetComponent<atributosDaCarta>().NumCarta.ToString();
		controladorComb = GameObject.Find("controladorCombinacao");
		if (!marcou) {
			gameObject.tag = "combinacao";

			controladorComb.GetComponent<contComb>().frentes.Add(fc);
			marcou = true;
		} else {
			gameObject.tag = "Untagged";
			controladorComb.GetComponent<contComb>().frentes.Remove(fc);
			marcou = false;
		}

	}
}
