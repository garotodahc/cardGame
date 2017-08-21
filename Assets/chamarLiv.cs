using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class chamarLiv : MonoBehaviour {

	public GameObject referencia;

	public void mandar(){
		Sprite carta = gameObject.GetComponent<Image>().sprite;
		referencia.GetComponent<irParaCentroLiv> ().clicar (carta);
	}
}
