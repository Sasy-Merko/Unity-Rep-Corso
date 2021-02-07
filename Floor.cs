using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{

    //questa funzione viene richiamata quando un collider entra o attraversa un collider trigger.

     void OnTriggerEnter(Collider other)
    {
        Debug.Log("E' entrato " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("E' uscito " + other.gameObject.name);
    }
}
