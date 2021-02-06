using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //se muovo il tasto, muovi l'oggetto sull'asse corrispondente al tasto.
        // Horizontal
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                Debug.Log("Stai andando verso Destra");
            }
            else
            {
                Debug.Log("Stai andando verso Sinistra");
            }
        }
    }
}
