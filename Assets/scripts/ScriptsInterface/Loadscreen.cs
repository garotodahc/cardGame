using UnityEngine;
using System.Collections;

public class Loadscreen : MonoBehaviour {

	// Use this for initialization


	
	// Update is called once per frame
	public void ChangeToscene (string sceneToChange) {
		Application.LoadLevel (sceneToChange);
	}

	public void Quitar(){
		Application.Quit ();
	}


}