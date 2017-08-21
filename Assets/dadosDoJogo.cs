using UnityEngine;
using System.Collections;

public class dadosDoJogo : MonoBehaviour {

	public string nome;
	public string frase;
	public string avatar;
	public string pontuacao;
	public bool player1;

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting) {
			stream.SendNext (nome);
			stream.SendNext (frase);
			stream.SendNext (avatar);
			stream.SendNext (pontuacao);
			stream.SendNext (player1);
		} else {
			nome = (string)stream.ReceiveNext ();
			frase = (string)stream.ReceiveNext ();
			avatar = (string)stream.ReceiveNext ();
			pontuacao = (string)stream.ReceiveNext ();
			player1 = (bool)stream.ReceiveNext ();
		}
	}

	void Start(){
		DontDestroyOnLoad (gameObject);
	}
}
