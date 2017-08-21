using UnityEngine;
using System.Collections;

public class controlBatalha : MonoBehaviour {
	private GameObject[] jogadores;
	private GameObject g1;
	private GameObject g2;
	private string resultado = "e";
	public GameObject vitoriaDerrota;
	// Use this for initialization
	void Start () {
		
		jogadores = GameObject.FindGameObjectsWithTag("informacoesJogador");



		foreach (GameObject jogador in jogadores) {
			
			if(jogador.GetComponent<informacoesJogador>().player1){
				string numG = jogador.GetComponent<informacoesJogador>().NumGuerreiro;
				g1 = gameObject.GetComponent<criarGurreiro>().criarNaBatalha(numG, 1);
			}else{
				string numG = jogador.GetComponent<informacoesJogador>().NumGuerreiro;
				g2 = gameObject.GetComponent<criarGurreiro>().criarNaBatalha(numG, 2);
			}

		}

		batalhar (g1, g2);



	}

	public void batalhar(GameObject gue1, GameObject gue2){
		int poder1 = gue1.GetComponent<atributosDoGuerreiro> ().poder;
		int poder2 = gue2.GetComponent<atributosDoGuerreiro> ().poder;
		jogadores = GameObject.FindGameObjectsWithTag("informacoesJogador");



		if (poder1 == poder2) {
			Debug.Log ("empate");
		} else if (poder1 > poder2) {
			Debug.Log ("1 ganhou");
			resultado = "p1";
			foreach (GameObject jogador in jogadores) {
				
				if(!jogador.GetComponent<informacoesJogador>().player1){
					jogador.GetComponent<informacoesJogador>().pontosDeVida = jogador.GetComponent<informacoesJogador>().pontosDeVida -1;
				}
				
			}
		} else {
			Debug.Log("2 ganhou");
			resultado = "p2";
			foreach (GameObject jogador in jogadores) {
				
				if(jogador.GetComponent<informacoesJogador>().player1){
					jogador.GetComponent<informacoesJogador>().pontosDeVida = jogador.GetComponent<informacoesJogador>().pontosDeVida -1;
				}
				
			}
		}

		foreach (GameObject jogador in jogadores) {
			jogador.GetComponent<informacoesJogador>().batalhar = false;
			jogador.GetComponent<informacoesJogador>().NumGuerreiro = "";
			
		}

		Invoke ("mostraResultado", 2);

	}

	void mudarCena()
	{

			Application.LoadLevel("cena1");



	}

	void mostraResultado(){
		GameObject p1ou2 = GameObject.Find ("player1ou2") as GameObject;
		bool player1 = p1ou2.GetComponent<p1ou2> ().player1;
		
		if ((player1 && resultado == "p1") || (!player1 && resultado == "p2") ) {

			vitoriaDerrota.GetComponent<derrotaVitoria> ().mudarSprite ("v");

		} else if ((!player1 && resultado == "p1") || (player1 && resultado == "p2")) {

			vitoriaDerrota.GetComponent<derrotaVitoria> ().mudarSprite ("d");
		}
		resultado = "e";
		Invoke ("mudarCena", 2);
	}
}
