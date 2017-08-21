using UnityEngine;
using System.Collections;

public class irParaCena : MonoBehaviour {

	public string cena;

	public void irPara(){
		Application.LoadLevel (cena);
	}
}
