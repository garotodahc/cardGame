using UnityEngine;
using System.Collections;

public class sairSala : MonoBehaviour {

	public void sair(){

		GameObject p1ou2 = GameObject.Find ("player1ou2") as GameObject;
		if (PhotonNetwork.connected) {
			Destroy(p1ou2);
			PhotonNetwork.DestroyAll();
			PhotonNetwork.Disconnect();
		}
	}

}
