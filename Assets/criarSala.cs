using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class criarSala : MonoBehaviour {
	public GameObject painelDeAcoes;
	public GameObject textoCriandoSala;

	public void criar(){
		//procurar do tempo de conjuracao
		GameObject[] checksTempo = GameObject.FindGameObjectsWithTag ("tempoConj");
		string tempo = "";
		foreach (GameObject check in checksTempo) {
			bool ativo = check.GetComponent<Image> ().enabled;
			if (ativo) {
				tempo = check.GetComponent<selecionado>().valor;
			}
		}

		//procurar qtd de guereiros
		GameObject[] checksGuer = GameObject.FindGameObjectsWithTag ("guerCom");
		string guerQtd = "";
		foreach (GameObject check in checksGuer) {
			bool ativo = check.GetComponent<Image> ().enabled;
			if (ativo) {
				guerQtd = check.GetComponent<selecionado>().valor;
			}
		}

		//procurar qtd de vida
		GameObject[] checksVida = GameObject.FindGameObjectsWithTag ("vidaJog");
		string vida = "";
		foreach (GameObject check in checksVida) {
			bool ativo = check.GetComponent<Image> ().enabled;
			if (ativo) {
				vida = check.GetComponent<selecionado>().valor;
			}
		}

		//procurar qtd de vida
		GameObject[] checksTurno = GameObject.FindGameObjectsWithTag ("turnoDuelo");
		string turno = "";
		foreach (GameObject check in checksTurno) {
			bool ativo = check.GetComponent<Image> ().enabled;
			if (ativo) {
				turno = check.GetComponent<selecionado>().valor;
			}
		}

		GameObject infoJog = GameObject.FindGameObjectWithTag ("informacoesJogador");
		dados dadosJog = infoJog.GetComponent<dados> ();
		string nomeJog = dadosJog.nome;
		string fraseJog = dadosJog.frase;
		string avatar = dadosJog.avatar;
		string pontuacao = dadosJog.pontuacao;

		string nomeDaSala = nomeJog + "/" + fraseJog + "/" + avatar + "/" + pontuacao + "/" + tempo + "/" + guerQtd + "/" + vida + "/" + turno;
		dadosJog.player1 = true;

		PhotonNetwork.CreateRoom(nomeDaSala, new RoomOptions() { isVisible = true, maxPlayers = 2 }, null);
		painelDeAcoes.SetActive (false);
		textoCriandoSala.SetActive (true);
	}


}
