using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class listaDeSalas : MonoBehaviour {
	private RoomInfo[] roomsList;
	public List<GameObject> btnSalas;
	public GameObject conteudo;
	public GameObject btnSalasPrefab;
	public Sprite[] avatares;


	void OnReceivedRoomListUpdate()
	{
		roomsList = PhotonNetwork.GetRoomList();

		if(roomsList != null){
			if (btnSalas != null) {
				
				foreach (GameObject BtnJ in btnSalas) {
					string nomeBtn = BtnJ.GetComponent<objetosBtnJogP>().objNomeSala.GetComponent<Text>().text;
					bool existe = false;
					foreach (RoomInfo ri in roomsList) {
						string nomeR = ri.name;
						if (nomeR == nomeBtn) {
							existe = true;
						}
					}
					if (!existe) {
						Destroy (BtnJ);
						btnSalas.Remove (BtnJ);
					}
				}
				
				foreach (RoomInfo ri in roomsList) {
					string nomeR = ri.name;
					bool existe = false;
					foreach (GameObject BtnJ in btnSalas) {
						string nomeBtn = BtnJ.GetComponent<objetosBtnJogP>().objNomeSala.GetComponent<Text>().text;
						if (nomeR == nomeBtn) {
							existe = true;
						}
					}
					if (!existe) {
						GameObject novoJ = criarBtnJogador (ri.name);
						btnSalas.Add (novoJ);
					}
				}
			}else{
				foreach (RoomInfo ri in roomsList) {
					GameObject novoJ = criarBtnJogador (ri.name);
					btnSalas.Add (novoJ);
				}
			}
		} else {
			if (btnSalas != null) {
				foreach (GameObject BtnJ in btnSalas) {
					Destroy(BtnJ);
				}
				btnSalas.Clear();
			}
		}
	}

	private GameObject criarBtnJogador(string nomeSalaJogador){

		GameObject novoBtn = Instantiate(btnSalasPrefab) as GameObject;

		GameObject nomeSala = novoBtn.GetComponent<objetosBtnJogP> ().objNomeSala;
		nomeSala.GetComponent<Text> ().text = nomeSalaJogador;

		string[] dados = nomeSalaJogador.Split ('/');

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


		GameObject objTempo =  novoBtn.GetComponent<objetosBtnJogP>().objTempo;
		objTempo.GetComponent<Text>().text = dados[4];

		GameObject objQtdGuer =  novoBtn.GetComponent<objetosBtnJogP>().objQtdGuer;
		objQtdGuer.GetComponent<Text>().text = dados[5];

		GameObject objVida =  novoBtn.GetComponent<objetosBtnJogP>().objVida;
		objVida.GetComponent<Text>().text = dados[6];

		GameObject objTurno =  novoBtn.GetComponent<objetosBtnJogP>().objTurno;
		objTurno.GetComponent<Text>().text = dados[7];

		novoBtn.transform.SetParent (conteudo.transform);
		return novoBtn;
	}
}
