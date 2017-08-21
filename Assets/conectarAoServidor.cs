using UnityEngine;
using System.Collections;

public class conectarAoServidor : MonoBehaviour {
	public RoomInfo[] roomsList2;
	public GameObject painelDeAcoes;
	public GameObject textoConexao;
	public GameObject textoFalhaConexao;
	public GameObject textoAguardandoOponente;
	public GameObject textoCriandoSala;
	public GameObject textoEntrandoSala;
	public GameObject textoFalhaSala;
	public GameObject dadosDoJogoPrefab;

	private bool ativou = false;

	void Start()
	{	
		PhotonNetwork.ConnectUsingSettings ("0.1");
		
	}

	void Update(){

		if (!ativou && PhotonNetwork.connected) {
			textoConexao.SetActive(false);
			painelDeAcoes.SetActive(true);
			ativou = true;
		}

		int qtdPlayersNaRoom = PhotonNetwork.playerList.Length;
		if (qtdPlayersNaRoom == 2) {
			Application.LoadLevel("chat");
		}
	}

	void  OnFailedToConnectToPhoton(){

		textoFalhaConexao.SetActive (true);
		textoConexao.SetActive (false);
	}

	public void tentarConexaoNovamente(){
		PhotonNetwork.ConnectUsingSettings ("0.1");
		textoFalhaConexao.SetActive (false);
		textoConexao.SetActive (true);
		
	}

	
	void OnJoinedRoom()
	{
		GameObject infoJog = GameObject.FindGameObjectWithTag ("informacoesJogador");
		dados dadosJog = infoJog.GetComponent<dados> ();
		bool p1 = dadosJog.player1;

		if (p1) {
			textoCriandoSala.SetActive (false);
			textoAguardandoOponente.SetActive (true);
		} else {
			textoEntrandoSala.SetActive(false);
		}

		string nomeJog = dadosJog.nome;
		string fraseJog = dadosJog.frase;
		string avatar = dadosJog.avatar;
		string pontuacao = dadosJog.pontuacao;


		GameObject dadosJ = PhotonNetwork.Instantiate(dadosDoJogoPrefab.name, Vector3.zero, Quaternion.identity, 0);
		dadosDoJogo dJ = dadosJ.GetComponent<dadosDoJogo> ();
		dJ.nome = dadosJog.nome;
		dJ.frase = dadosJog.frase;
		dJ.avatar = dadosJog.avatar;
		dJ.pontuacao = dadosJog.pontuacao;
		dJ.player1 = dadosJog.player1;
	}

	void OnPhotonJoinRoomFailed(){
		textoEntrandoSala.SetActive (false);
		textoFalhaSala.SetActive (true);
	}

	public void mostrarListaNovamente(){
		painelDeAcoes.SetActive (true);
		textoFalhaSala.SetActive (false);
	}


}