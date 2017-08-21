using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class checkAvatar : MonoBehaviour {

	public void checar(){

		bool ativo2 = gameObject.GetComponent<Image> ().enabled;
		if (ativo2) {
			gameObject.GetComponent<Image> ().enabled = false;
		} else {
			GameObject[] checks = GameObject.FindGameObjectsWithTag ("checkAvatar");
			foreach (GameObject c in checks) {
				c.GetComponent<Image> ().enabled = false;
			}
			gameObject.GetComponent<Image> ().enabled = true;
		}
	}
}
