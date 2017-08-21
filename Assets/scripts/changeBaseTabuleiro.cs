using UnityEngine;
using System.Collections;

public class changeBaseTabuleiro : MonoBehaviour {

	public Material[] meuMat;
	public float tempo;
	public Renderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.enabled = true;
	}
	
	// Update is called once per frame
	public void mudarCor (string ph) {
		if (ph == "a") {
			rend.sharedMaterial = meuMat[0];
		}else if(ph == "b"){
			rend.sharedMaterial = meuMat[1];
		}else{
			rend.sharedMaterial = meuMat[2];
		}
	}
}
