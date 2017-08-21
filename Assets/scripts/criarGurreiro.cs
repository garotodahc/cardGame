using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class criarGurreiro : MonoBehaviour {
	public GameObject contComb;
	public GameObject prefabGuerreiro;

	public GameObject prefabGuerBat1;
	public GameObject prefabGuerBat2;

	public string combinacao;
	public bool guerreiroCriado;
	private GameObject cartaGuerreiro;
	public GameObject botaoJogar;
    Inventory myInv;
    ItemDataBaseList dadositem;

    void Start() {
        dadositem = GetComponent<ItemDataBaseList>();
        myInv = GetComponentInChildren<Inventory>();
    }
    public void criarDestuir(){

		if (!guerreiroCriado) {
			combinacao = contComb.GetComponent<contComb> ().resultado;
 
			int numGuerreiro = numeroDoGuerreiro(combinacao);
            myInv.addItemToInventory(numGuerreiro);
       //     

            if (numGuerreiro != -1) {
               
                cartaGuerreiro = Instantiate (prefabGuerreiro) as GameObject;
				cartaGuerreiro.GetComponent<atributosDoGuerreiro> ().numeroDoGuerreiro = numGuerreiro;
				cartaGuerreiro.GetComponent<frenteDoGuerreiro> ().numeroFrenteG = numGuerreiro;
				cartaGuerreiro.GetComponent<frenteDoGuerreiro> ().mudarFrenteDaGuerreiro ();
               
               
                guerreiroCriado = true;
                
				//gameObject.GetComponentInChildren<Text>().text = "DESCARTAR GUERREIRO";
				//adiciona aki a lista para o inventario
				//inventory.inventario[0] = cartaGuerreiro;

				botaoJogar.SetActive(true);
                
                botaoJogar.GetComponent<iniciarBatalha>().numCartaG = numGuerreiro;
                
            }
            else {
					Destroy (cartaGuerreiro);
					guerreiroCriado = false;
					//gameObject.GetComponentInChildren<Text>().text = "CRIAR GUERREIRO";
					botaoJogar.GetComponent<iniciarBatalha>().numCartaG = -1;
					botaoJogar.SetActive(false);

			}
		} 
	}

	public GameObject criarNaBatalha(string numDoGuer, int jog){

		int numG = int.Parse (numDoGuer);
		int poder = poderGuerreiro (numG);
		GameObject cartaGB = null;
		if (jog == 1) {
			cartaGB = Instantiate (prefabGuerBat1) as GameObject;


		} else if (jog == 2) {
			cartaGB = Instantiate (prefabGuerBat2) as GameObject;

		}

		cartaGB.GetComponent<atributosDoGuerreiro> ().numeroDoGuerreiro = numG;
		cartaGB.GetComponent<atributosDoGuerreiro> ().poder = poder;
		cartaGB.GetComponent<frenteDoGuerreiro> ().numeroFrenteG = numG;
		cartaGB.GetComponent<frenteDoGuerreiro> ().mudarFrenteDaGuerreiro ();

		return cartaGB;
	}

	int numeroDoGuerreiro(string combinacao){
		int numGuerreiro;

		switch (combinacao) {
			//acidos  /////////////////////////////////////////////////////////////	
		case "220444":
			numGuerreiro = 1; //carbonico
       
			break;
		case "02220220442":
			numGuerreiro = 9;//propanoico
           
                break;
		case "02220442":
			numGuerreiro = 5;//acetico
          
                break;
		case "000000222220442":
			numGuerreiro = 0;//benzoico
        
                break;
		case "22044":
			numGuerreiro = 4;//formico
          
                break;
		case "2344":
			numGuerreiro = 8;//nitroso
              
                break;
		case "21":
			numGuerreiro = 2;//fluoridrico
        
                break;
		case "222254444":
			numGuerreiro = 6;//fosforico
         
                break;
		case "264444":
			numGuerreiro = 7;//hidrogenossulfato
           
                break;
		case "226444":
			numGuerreiro = 3;//sulfuroso
        
                break;
			////bases   /////////////////////////////////////////////////////
		case "64444":
		numGuerreiro = 17;//ion sulfato
      
                break;
		case "00000022222322":
			numGuerreiro = 12;//anilina
       
                break;
		case "0222044":
			numGuerreiro = 16;//ion acetato
          
                break;
		case "00000222223":
			numGuerreiro = 19;//piridina
          
                break;
		case "20444":
			numGuerreiro = 11;//ion hidrogenocarbonato
          
                break;
		case "26":
			numGuerreiro = 15;//ion hidrogenossulfureto
        
                break;
		case "03":
			numGuerreiro = 14;//ion cianeto

                break;
		case "3222":
			numGuerreiro = 10;//amoniaco
      
                break;
		case "0444":
			numGuerreiro = 13;//lao carbonato
         
                break;
		case "0222322":
			numGuerreiro = 18;//metilamina
     
                break;
			///////////////////////////////////////////
		default:
			numGuerreiro = -1;
			break;
		}
		return numGuerreiro;
	}

	int poderGuerreiro(int numG){

		int poder = 0;

		switch (numG) {
		case 0:
			poder = 11;
			break;
		case 1:
			poder = 7;
			break;
		case 2:
			poder = 16;
			break;
		case 3:
			poder = 19;
			break;
		case 4:
			poder = 12;
			break;
		case 5:
			poder = 9;
			break;
		case 6:
			poder = 17;
			break;
		case 7:
			poder = 18;
			break;
		case 8:
			poder = 14;
			break;
		case 9:
			poder = 8;
			break;
		case 10:
			poder = 10;
			break;
		case 11:
			poder = 5;
			break;
		case 12:
			poder = 2;
			break;
		case 13:
			poder = 13;
			break;
		case 14:
			poder = 9;
			break;
		case 15:
			poder = 6;
			break;
		case 16:
			poder = 3;
			break;
		case 17:
			poder = 1;
			break;
		case 18:
			poder = 15;
			break;
		case 19:
			poder = 4;
			break;
		}

		return poder;

    }
    //
    /*public int addInventario(int numeroCarta)
    {
        
           numeroCarta += 1;
        myInv.ItemsInInventory.Add(dadositem.getItemByID(numeroCarta));
        myInv.addItemToInventory(numeroCarta);
        myInv.updateItemList();


        return numeroCarta;
    }*/
 }

