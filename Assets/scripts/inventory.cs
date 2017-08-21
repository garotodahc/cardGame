using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class inventory : MonoBehaviour {


	public static List<Vector3> inventario ;
	public GameObject objetoTeste;
	// Use this for initialization
	void Start () {


		inventario.Add ( new Vector3(-41.9f , 22f ,23.1f));
		inventario.Add (new Vector3(-41.9f , 14.4f ,23.1f));
		inventario.Add (new Vector3(-41.9f , 6.7f ,23.1f));
		inventario.Add (new Vector3(-41.9f , -1.1f ,23.1f));
		inventario.Add (new Vector3(-41.9f , -10.4f ,23.1f));
		inventario.Add (new Vector3(-33.77f , 18.5f ,23.1f));
		inventario.Add (new Vector3(-33.77f , 10.9f ,23.1f));
		inventario.Add (new Vector3(-33.77f , 2.6f ,23.1f));
		inventario.Add (new Vector3(-33.77f , -6.6f ,23.1f));
		inventario.Add (new Vector3(-33.77f , -14.3f ,23.1f));


	}
	
	// Update is called once per frame
	void Update () {
	
		for(int i = 0; i< inventario.Count;i++){
			Instantiate(objetoTeste, inventario[i], Quaternion.identity);
		}

	}
}
