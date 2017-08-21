using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class irParaCentroLiv : MonoBehaviour {

	public bool expandido;
	private Sprite frente;

	public void clicar(Sprite carta){
		if (!expandido) {
			this.GetComponent<Image>().sprite = carta;
			gameObject.SetActive(true);
			expandido = true;

		} else {
			gameObject.SetActive(false);
			expandido = false;
		}
	}
}
