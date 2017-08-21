using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class criarBtnDosJogadores : MonoBehaviour {

	public GameObject conteudo;
	public GameObject btnJogadorPrincipalPrefab;
	public Sprite[] avatares;

	// Use this for initialization
	void Start () {
		string caminho = "jogadores.txt";
		string[] arq = File.ReadAllLines(caminho);
		avatares =  Resources.LoadAll<Sprite>("Textures/avatares");
		foreach (string jogador in arq) {
			string[] dados = jogador.Split('|');

			GameObject novoBtn = Instantiate(btnJogadorPrincipalPrefab) as GameObject;

			GameObject objNome =  novoBtn.GetComponent<objetosBtnJogP>().objNome;
			objNome.GetComponent<Text>().text = dados[0];

			GameObject objFrase =  novoBtn.GetComponent<objetosBtnJogP>().objFrase;
			objFrase.GetComponent<Text>().text = dados[1];

			GameObject objPontuacao =  novoBtn.GetComponent<objetosBtnJogP>().objPontuacao;
			objPontuacao.GetComponent<Text>().text = dados[3];

			GameObject objAvatar =  novoBtn.GetComponent<objetosBtnJogP>().objAvatar;
			string[] avaEx = dados[2].Split('_');
			int numAvatar = int.Parse(avaEx[1]);
			objAvatar.GetComponent<Image>().sprite = avatares[numAvatar];

			novoBtn.transform.SetParent (conteudo.transform);
		}
	}

}
