using UnityEngine;
using System.Collections;

public class sampleCard_script : MonoBehaviour {

	public GameObject carta;
	public int rotacao;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

			if(Input.GetMouseButtonDown(0))	{
				transform.Rotate(0,rotacao *Time.deltaTime,0);
			}	


	}
}
