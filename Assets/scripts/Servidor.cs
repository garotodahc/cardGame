using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Servidor : MonoBehaviour {
	public GameObject btnJogador;
	public GameObject conteudo;
	public GameObject lista;
	public List<GameObject> btnDosJogadores;
	public GameObject selecionar;
	public GameObject aguardar;
	public GameObject btnCriarSala;
	public GameObject prefabPlayerInfo;

	void Start()
	{

		Debug.Log (PhotonNetworkingMessage.OnConnectedToPhoton);
	}

	private RoomInfo[] roomsList;
	public bool player1;

	void OnReceivedRoomListUpdate()
	{
		roomsList = PhotonNetwork.GetRoomList();

		if(roomsList != null){
			if (btnDosJogadores != null) {

				foreach (GameObject BtnJ in btnDosJogadores) {
					string nomeBtn = BtnJ.GetComponentInChildren<Text> ().text;
					bool existe = false;
					foreach (RoomInfo ri in roomsList) {
						string nomeR = ri.name;
						if (nomeR == nomeBtn) {
							existe = true;
						}
					}
					if (!existe) {
						Destroy (BtnJ);
						btnDosJogadores.Remove (BtnJ);
					}
				}

				foreach (RoomInfo ri in roomsList) {
					string nomeR = ri.name;
					bool existe = false;
					foreach (GameObject BtnJ in btnDosJogadores) {
						string nomeBtn = BtnJ.GetComponentInChildren<Text> ().text;
						if (nomeR == nomeBtn) {
							existe = true;
						}
					}
					if (!existe) {
						GameObject novoJ = criarBtnJogador (ri.name);
						btnDosJogadores.Add (novoJ);
					}
				}
			}else{
				foreach (RoomInfo ri in roomsList) {
					GameObject novoJ = criarBtnJogador (ri.name);
					btnDosJogadores.Add (novoJ);
				}
			}
		} else {
			if (btnDosJogadores != null) {
				foreach (GameObject BtnJ in btnDosJogadores) {
					Destroy(BtnJ);
				}
				btnDosJogadores.Clear();
			}
		}
		


	}

	void Update(){
		if (clicouCriarSala) {
			input.SetActive(false);
			btnCriarSala.SetActive(false);
			lista.SetActive(false);
			selecionar.SetActive(false);
			aguardar.SetActive(true);
		}
	}

	public GameObject input;
	private bool clicouCriarSala;

	public void criarSala(){
		string nomeDaSala = input.GetComponentInChildren<Text> ().text;
		if (nomeDaSala != "") {
			bool estaNaLista = false;
			if (roomsList != null)
			{


				for (int i = 0; i <roomsList.Length; i++)
				{
					if (roomsList[i].name == nomeDaSala){
						estaNaLista = true;
					}
				}
			}
			if(!estaNaLista){
				player1 = true;
				clicouCriarSala = true;
				PhotonNetwork.CreateRoom(nomeDaSala , true, true, 5);
			}
		}
	}



	private GameObject criarBtnJogador(string nomeSalaJogador){
		GameObject novoBtn = Instantiate(btnJogador) as GameObject;
		novoBtn.GetComponentInChildren<Text> ().text = nomeSalaJogador;
		novoBtn.transform.SetParent (conteudo.transform);

		return novoBtn;
	}
	
	public GameObject controlador;
	public GameObject player1ou2;

	void OnJoinedRoom()
	{
		// Spawn player
		GameObject jogador = PhotonNetwork.Instantiate(prefabPlayerInfo.name, Vector3.zero, Quaternion.identity, 0);
		jogador.GetComponent<informacoesJogador>().player1 = player1;
		player1ou2.GetComponent<p1ou2> ().player1 = player1;
		controlador.GetComponent<verificarConexão> ().conectado = true;


	}

}