using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class validarGravarJogador : MonoBehaviour {

	public GameObject nome;
	public GameObject frase;
	public GameObject alerta;
	private List<string> arqL;

	public void validarGravar(){

		string nomeJ = nome.GetComponentInChildren<Text> ().text;
		string fraseJ = frase.GetComponentInChildren<Text> ().text;

		if (nomeJ == "") {
			alerta.GetComponent<alerta>().numTexto = 0;
			alerta.SetActive (true);
		} else {

			GameObject[] checks = GameObject.FindGameObjectsWithTag ("checkAvatar");
			string spriteAvatar = "";
			foreach (GameObject check in checks) {
				bool ativo = check.GetComponent<Image> ().enabled;
				if (ativo) {
					GameObject parent = check.transform.parent.gameObject;
					spriteAvatar = parent.GetComponent<Image> ().sprite.name;
				}
			}

			string caminho = "jogadores.txt";
			string linha = nomeJ+"|"+fraseJ+"|"+spriteAvatar+"|0|";
			if(File.Exists(caminho)){

				string[] arq = File.ReadAllLines(caminho);


				bool jaExiste = false;
				arqL = new List<string>();
				foreach (string l in arq){
					arqL.Add(l);
					string[] lex = l.Split('|');
					if(lex[0] == nomeJ){
						jaExiste = true;
					}
				}

				if(jaExiste){
					alerta.GetComponent<alerta>().numTexto = 1;
					alerta.SetActive (true);
				}else{
					arqL.Add(linha);
					arq = arqL.ToArray();
					string arqImp = string.Join("\r\n",arq);
					File.WriteAllText(caminho, arqImp);
					Application.LoadLevel("jogadores");
				}

			}else{
				File.WriteAllText(caminho, linha);
				Application.LoadLevel("jogadores");
			}
		}
	}
}
