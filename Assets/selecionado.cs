using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class selecionado : MonoBehaviour {

	public string valor;

	public void checar(){
		string tagSel = this.tag;
		/*
		//codigo para select nao obrigatorio
		bool ativo2 = gameObject.GetComponent<Image> ().enabled;
		if (ativo2) {
			gameObject.GetComponent<Image> ().enabled = false;
		} else {
			GameObject[] checks = GameObject.FindGameObjectsWithTag (tagSel);
			foreach (GameObject c in checks) {
				c.GetComponent<Image> ().enabled = false;
			}
			gameObject.GetComponent<Image> ().enabled = true;
		}
		//////////////////
		*/
		GameObject[] checks = GameObject.FindGameObjectsWithTag (tagSel);
		foreach (GameObject c in checks) {
			c.GetComponent<Image> ().enabled = false;
		}
		gameObject.GetComponent<Image> ().enabled = true;
	}
}
