using UnityEngine;
using System.Collections;

public class ChangeFace : MonoBehaviour {

	public Material[] changeFace;


	// Use this for initialization
	/*void Start () {
		//Simple way: create int array for indicate assign material
		int[] indMat = new int[changeFace.Length];
		//Just in case we initialize an array
		for(int i = 0; i < changeFace.Length; i++) {
			indMat[i] = 0; //not assign material
		}
		foreach(GameObject card in DeckCards.cartas) { //see all objects
			//Assign random material to object
			int num = Random.Range(0, changeFace.Length);
			//already apply, find next
			while(indMat[num] != 0) {
				num++;
				if (num >= changeFace.Length) {
					num = 0;
				}
			}
			indMat[num] = 1;
			card.GetComponent<Renderer>().material = changeFace[num];
		}
	}
	
	// Update is called once per frame
	void Update () {

	
	}*/
}
