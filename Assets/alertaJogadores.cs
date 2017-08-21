using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class alertaJogadores : MonoBehaviour {

	public string nomeJogador;
	public GameObject infoJogPrefab;
	private string[] info;

	public void cancelar(){
		gameObject.SetActive (false);
	}

	public void deletar(){
		string caminho = "jogadores.txt";
		string[] arq = File.ReadAllLines (caminho);
		List<string> arqL = new List<string> ();

		foreach (string l in arq) {
			string[] dados = l.Split('|');
			if(dados[0] != nomeJogador){
				arqL.Add(l);
			}
		}
		string arqN = string.Join ("\r\n", arqL.ToArray());

		File.WriteAllText (caminho, arqN);
		Application.LoadLevel ("jogadores");
	}

	public void iniciarSessao(){
		string caminho = "jogadores.txt";
		string[] arq = File.ReadAllLines (caminho);


		foreach (string l in arq) {
			string[] linha = l.Split('|');
			if(linha[0] == nomeJogador){
				info = linha;
			}
		}

		GameObject dadosJogador = Instantiate (infoJogPrefab) as GameObject;
		dados d = dadosJogador.GetComponent<dados>();
		d.nome = info[0];
		d.frase = info [1];
		d.avatar = info [2];
		d.pontuacao = info [3];

		Application.LoadLevel ("conexao");
	}
}
