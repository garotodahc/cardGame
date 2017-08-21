using UnityEngine;
using System.Collections;

public class scaleCard : MonoBehaviour {

	public GameObject objt;
	public bool scalado = false;
	private Vector3 foi;
	public string name2;
	// Use this for initialization
	void Start () {
		objt = GameObject.Find (name2);
		foi = objt.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0)){
			
			Vector3 scale = transform.localScale;
			scale.y = 0.5f;
			scale.z = 1f;
			scale.x = 0.5f;
			transform.localScale = new Vector3(scale.x, scale.y, scale.z);
			transform.Translate(-4f, -3f,-0.4f);
			scalado = true;
		}
		else{

			if(Input.GetKeyDown(KeyCode.Escape))
			    {
					Vector3 scale = transform.localScale;
					scale.y = 0.17f;
				    scale.z = 0.1324725f;
					scale.x = 0.17f;
					transform.localScale = new Vector3(scale.x, scale.y, scale.z);
		//		transform.Translate() = objt.transform.Translate();
				transform.position = foi;
					scalado = false;
				}


			}
				

		 }


}

