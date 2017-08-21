using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DeckCards : MonoBehaviour {


	//lista de posicoes para as cartas
	public List<Vector3> posicoesCartas;



	/*public List<GameObject> deck = new List<GameObject>();
	public static List<GameObject> cartas = new List<GameObject>();*/
	public List<GameObject> mao = new List<GameObject>();
	private int cartasJogadas = 0;
	public GameObject prefabCarta;
	private bool reset;
	private bool resetou;

	public GameObject sortearBtn;
	public GameObject resetarBtn;
	public GameObject contComb;
   
	void Start () {
      
        //ResetDeck ();
        //seta as posicoes padroes para as cartas
        posicoesCartas.Add (new Vector3 (-15.133f,21.6f,22.93f));
		posicoesCartas.Add (new Vector3 (-0.375f,21.6f,22.93f));
		posicoesCartas.Add (new Vector3 (6.957f,21.6f,22.93f));
		posicoesCartas.Add (new Vector3 (14.007f,21.6f,22.93f));
		posicoesCartas.Add (new Vector3 (21.433f,21.6f,22.93f));
		posicoesCartas.Add (new Vector3 (-7.895f,21.6f,22.93f));

		posicoesCartas.Add (new Vector3 (21.899f,-14.7f,23.406f));
		posicoesCartas.Add (new Vector3 (14.3f,-14.7f,23.406f));
		posicoesCartas.Add (new Vector3 (7.0577f,-14.7f,23.406f));
		posicoesCartas.Add (new Vector3 (-0.47087f,-14.7f,23.406f));
		posicoesCartas.Add (new Vector3 (-15.599f,-14.7f,23.406f));
		posicoesCartas.Add (new Vector3 (-8.2144f,-14.7f,23.406f));

		posicoesCartas.Add (new Vector3 (-8.2144f,-5.4f,23.406f));
		posicoesCartas.Add (new Vector3 (-15.599f,-5.4f,23.406f));
		posicoesCartas.Add (new Vector3 (-0.47087f,-5.4f,23.406f));
		posicoesCartas.Add (new Vector3 (7.0577f,-5.4f,23.406f));
		posicoesCartas.Add (new Vector3 (14.3f,-5.4f,23.406f));
		posicoesCartas.Add (new Vector3 (21.899f,-5.4f,23.406f));

		posicoesCartas.Add (new Vector3 (-8.2144f,3.6f,23.406f));
		posicoesCartas.Add (new Vector3 (-15.599f,3.6f,23.406f));
		posicoesCartas.Add (new Vector3 (-0.47087f,3.6f,23.406f));
		posicoesCartas.Add (new Vector3 (7.0577f,3.6f,23.406f));
		posicoesCartas.Add (new Vector3 (14.3f,3.6f,23.406f));
		posicoesCartas.Add (new Vector3 (21.899f,3.6f,23.406f));

		posicoesCartas.Add (new Vector3 (-8.2144f,12.9f,23.406f));
		posicoesCartas.Add (new Vector3 (-15.599f,12.9f,23.406f));
		posicoesCartas.Add (new Vector3 (-0.47087f,12.9f,23.406f));
		posicoesCartas.Add (new Vector3 (7.0577f,12.9f,23.406f));
		posicoesCartas.Add (new Vector3 (14.3f,12.9f,23.406f));
		posicoesCartas.Add (new Vector3 (21.899f,12.9f,23.406f));


	}

	public void clicarSortearResetar(){
		if (!reset) {
				//MoveDealtCard();
				distribuirCartas();

				reset = true;
				sortearBtn.SetActive(false);

		}
		else if(!resetou) {

				ResetDeck();
				resetou = true;
				resetarBtn.SetActive(false);
				contComb.GetComponent<contComb>().frentes.Clear();


		}
	}

	void ResetDeck(){

		foreach (GameObject carta in mao) {
			Destroy (carta);
		}
		mao.Clear ();
		cartasJogadas = 0;
		distribuirCartas ();
	}

	public void distribuirCartas(){
		if (cartasJogadas == 0) {
			foreach (Vector3 posCartaNova in posicoesCartas){
				GameObject novaCarta = criarCarta();
				novaCarta.transform.position = posCartaNova;
				mao.Add(novaCarta);
				cartasJogadas++;
				
			}
		}

	}


	public GameObject criarCarta(){
		int numeroNovaCarta = Random.Range (0, 7);
		GameObject nova = Instantiate (prefabCarta, Vector3.zero, prefabCarta.transform.rotation)  as GameObject;
		nova.GetComponent<atributosDaCarta> ().definirAtributosDaCarta(numeroNovaCarta);
		nova.GetComponent<frenteDaCarta> ().mudarFrenteDaCarta (numeroNovaCarta);
        
		return nova;
		
	}

	void gameOver(){
		cartasJogadas = 0;
		foreach (GameObject carta in mao) {
			Destroy (carta);
		}
		mao.Clear ();
	}
   

	/*
	GameObject DealCard(){

		if(cartasJogadas == 20){
			reset = true;
			return null;
		}

		int card = Random.Range (0,7);//numero q faz referencia para o elemento da carta
		GameObject novaCarta = new GameObject ();
		//ler o tamanho da list para posicionar as cartas nas posiçoes determindas pelo vetor de vector3

		for(int i = 0; i< cartas.Count; i++){

			cartas[i].transform.position = posicaoCarta[i];
			esse = GameObject.Instantiate (cartas[card],cartas[i].transform.position,cartas[i].transform.rotation) as GameObject;
		
			// Instantiate (cartas[card], cartas[i].transform.position, cartas[i].transform.rotation);
			cartasJogadas = i;
			Debug.Log(cartasJogadas);
		}

		cartas.RemoveAt(card);

		if(cartasJogadas == cartas.Count){
			reset = true;

		}
		return esse;


	}
*/
	// Use this for initialization

	/*
	// Update is called once per frame
	void Update () {
	
	}

	*/



	/*void MoveDealtCard()
	{
	GameObject newCard = DealCard();
		// check card is null or not
		if (newCard == null) {
			Debug.Log("Out of Cards");
			reset = true;
			return;
        }
	//	newCard.transform.position = new Vector3 ((float)cartasJogadas ,(float)cartasJogadas, (float) cartasJogadas );

			mao.Add (newCard);
			cartasJogadas++;



	}*/
	
}