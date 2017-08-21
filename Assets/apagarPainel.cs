using UnityEngine;
using System.Collections;

public class apagarPainel : MonoBehaviour {
	public GameObject painel;

	public void apagar(){
		painel.SetActive (false);
	}
}
