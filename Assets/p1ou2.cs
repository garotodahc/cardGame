using UnityEngine;
using System.Collections;

public class p1ou2 : MonoBehaviour {

	public bool player1;
	public GameObject esteObjeto;

	void Start(){
		DontDestroyOnLoad (esteObjeto);
	}
}
