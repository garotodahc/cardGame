using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class validacaoNomeJogador : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		string novoTexto = gameObject.GetComponentInChildren<Text>().text.Replace(" ","");
		gameObject.GetComponent<InputField>().text = novoTexto;
	}
}
