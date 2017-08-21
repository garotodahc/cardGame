using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class frenteDoGuerreiro : MonoBehaviour {

	public int numeroFrenteG;
	public GameObject frente;

	public void mudarFrenteDaGuerreiro(){
			// load all frames in fruitsSprites array
		string caminho = "Textures/cartas/guerreiros/guerreiro_" + numeroFrenteG.ToString ();
		Texture2D cartaText = (Texture2D)Resources.Load(caminho);
		frente.GetComponentInChildren<Renderer>().material.mainTexture = cartaText;
		

	}



	void Start(){
		mudarFrenteDaGuerreiro ();
	}
}
