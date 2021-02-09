using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Material material;


    //funzione che va a prendere il renderer del game object su cui 
    //c'è questo script cubo e gli cambia il materiale che abbiamo sopra dichiarato.

	public void OnHitByRaycast()
    {

        gameObject.GetComponent<Renderer>().material = material;
    }
}
