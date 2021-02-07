using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        //possiamo anche mettere collision.collider è la stessa cosa.
        Debug.Log("Ho colliso con " + collision.gameObject.name); 
    }

    

}
