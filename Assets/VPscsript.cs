using UnityEngine;
using System.Collections;

public class VPscsript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		Invoke ("sairSala", 4);
	}
	
	void sairSala(){
		GameObject p1ou2 = GameObject.Find ("player1ou2");
		Destroy(p1ou2);
		PhotonNetwork.DestroyAll();
		PhotonNetwork.Disconnect();
		Application.LoadLevel ("home");
	}
}
