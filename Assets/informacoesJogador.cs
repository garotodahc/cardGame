using UnityEngine;
using System.Collections;

public class informacoesJogador : Photon.MonoBehaviour {

	public bool player1;
	public string NumGuerreiro;
	public GameObject esteObjeto;
	public bool batalhar;
	public int pontosDeVida = 10;


	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting) {
			stream.SendNext (player1);

		} else {
			player1 = (bool)stream.ReceiveNext ();
		}

		if (stream.isWriting) {
			stream.SendNext (batalhar);
			
		} else {
			batalhar = (bool)stream.ReceiveNext ();
		}

		if (stream.isWriting) {
			stream.SendNext (NumGuerreiro);
			
		} else {
			NumGuerreiro = (string)stream.ReceiveNext();
		}

		if (stream.isWriting) {
			stream.SendNext (pontosDeVida);
			
		} else {
			pontosDeVida = (int)stream.ReceiveNext();
		}
	}

		void Awake() {
			DontDestroyOnLoad(esteObjeto);
		}
	
}
