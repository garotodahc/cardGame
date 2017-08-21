using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class derrotaVitoria : MonoBehaviour {

	public Sprite vitoria;
	public Sprite derrota;
/*adicionar efeitos de batalha aki*/
	public void mudarSprite( string VouD){
		gameObject.SetActive (true);
		if (VouD == "v") {
			gameObject.GetComponent<Image>().sprite = vitoria;
		} else if (VouD == "d"){
			gameObject.GetComponent<Image>().sprite = derrota;
		}
	}

}
