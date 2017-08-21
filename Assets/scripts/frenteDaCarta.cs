using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class frenteDaCarta : MonoBehaviour {

	public int numeroFrenteCarta;
	public GameObject frente;

	public void mudarFrenteDaCarta(int nfc){
		numeroFrenteCarta = nfc;

		// load all frames in fruitsSprites array
		string caminho = "Textures/cartas/elementos/carta_" + numeroFrenteCarta.ToString ();
		Texture2D cartaText = (Texture2D)Resources.Load(caminho);
		frente.GetComponentInChildren<Renderer>().material.mainTexture = cartaText;
		

	}

    public int mudaNUmeroCarta(int numeroFrenteCarta) {
        this.numeroFrenteCarta = numeroFrenteCarta + 1;
        return numeroFrenteCarta;
    }

}
