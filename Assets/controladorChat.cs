using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class controladorChat : MonoBehaviour {

	public GameObject mensagem;
	public GameObject inputMsg;
	public GameObject displayMsg;
	private SimChat chat;
	private string nomeJ;
	void Start(){

		string nomeDaSala = PhotonNetwork.room.name;
		GameObject infoJ = GameObject.FindGameObjectWithTag ("informacoesJogador");
		nomeJ = infoJ.GetComponent<dados> ().nome;
		//initialize the SimChat objects
		chat = new SimChat(nomeDaSala,gameObject.GetComponent<MonoBehaviour>(),nomeJ);
		//tell the SimChat Objects to continuously check for new messages
		chat.continueCheckMessages();
		//set the functions to call when a new message is received
		//chat.setReceiveFunction(msgRecebida);
	}

	public void enviarMsg(){
		string msn  = mensagem.GetComponent<Text>().text;
		chat.sendMessage(nomeJ,msn);
		inputMsg.GetComponent<InputField> ().text = "";
	}

	public void msgRecebida(){

	}

	void Update(){
		string mensagens="";
		foreach(SimpleMessage sm in chat.allMessages){
			//check if the sender had the same name as me, and change the color
			if(sm.sender == nomeJ){
				string mensagem = "\r\nEu: "+sm.message;
				mensagens = mensagens+mensagem;
			}else{
				string mensagem = "\r\n"+sm.sender+": "+sm.message;
				mensagens = mensagens+mensagem;
			}
		}
		displayMsg.GetComponent<Text> ().text = mensagens;
	}
}
