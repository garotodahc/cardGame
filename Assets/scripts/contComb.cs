using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class contComb : MonoBehaviour {
	public List<string> frentes;
	public string resultado;
	private string resultadoTexto;
	private string fs;

	void Update(){
		resultado = "";
		resultadoTexto = "";
		foreach (string f in frentes) {

			switch(f){
			case "0":
				fs = "C";
				break;
			case "1":
				fs = "F";
				break;
			case "2":
				fs = "H";
				break;
			case "3":
				fs = "N";
				break;
			case "4":
				fs = "O";
				break;
			case "5":
				fs = "P";
				break;
			case "6":
				fs = "S";
				break;

			}

			resultado = resultado + f;
			resultadoTexto = resultadoTexto + " " + fs;
		}
		gameObject.GetComponent<Text> ().text = resultadoTexto;
	}

}
