using UnityEngine;
using System.Collections;

public class verificarDes : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		GameObject[] jogadores = GameObject.FindGameObjectsWithTag ("informacoesJogador");
		if (jogadores.Length < 2) {
			Application.LoadLevel("desistencia");
		}
	}
}
