using UnityEngine;
using System.Collections;

public class dados : MonoBehaviour {

	public string nome;
	public string frase;
	public string avatar;
	public string pontuacao;
	public bool player1;

	void Start(){
		DontDestroyOnLoad (gameObject);
	}

}
