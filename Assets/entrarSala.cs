using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class entrarSala : MonoBehaviour {

	public void entrar(){
		string nomeDaSala = gameObject.GetComponentInChildren<Text>().text;
		PhotonNetwork.JoinRoom(nomeDaSala);

	}
}
