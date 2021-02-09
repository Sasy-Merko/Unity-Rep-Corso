using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    //creo una telecamera
    public Camera cam;
    [SerializeField]

    //non è altro che la lunghezza del nostro raggio
    float rayMaxDistance = 50;

    //Non sono altro che i numeri del layer nella scena.
    //quindi questa qui è una layer mask che colpisce sulla layer 9
    //se vogliamo fare che la nostra layermask colpisca qualsiasi layer tranne
    //alcuni viene utilizzata la tilde (circa). (per farla si fa alt + 126)
    LayerMask layerMask = ~((1 << 9) | (1 << 8));


	void Update ()

    
    {
        //se premo il tasto sinistro del mouse ho bisogno di sparare 
        //il mio raggio.
        if(Input.GetMouseButtonDown(0))
        {
            //questa variabile conterrà tutte le informazioni relative 
            //alla collisione del nostro raycast con qualcosa
            RaycastHit hit;

            //con questa istruzione cam.screen
            //stiamo dicendo prendi la telecamera prendi un punto dello schermo
            //e da quel punto dello schermo spara un raggio.
            //input.mouse gli diciamo da quale punto dello schermo noi vogliamo partire
            //avendo una posizione del mouse in cordinate pixel.
            Ray lastRay = cam.ScreenPointToRay(Input.mousePosition);


            //disegna il mio raggio
            //dove gli passo come parametro la posizione del raggio che vogliamo
            //disegnare e la destinazione 
            //Color è semplicemente la funzione che colora il nostro raggio
            //all'interno del nostro progetto. dove in Game non vedremo.
            //quel virgola 3 sono i secondi del nostro raggio che è visibile in progetto.
            Debug.DrawRay(lastRay.origin, lastRay.direction * rayMaxDistance, Color.green, 1);


            //questa è una funzione booleana che restituisce true quando questo raggio
            //colpisce qualcosa o false se non colpisce nnt.
            //gli passiamo il lastray che sarebbe il nostro raggio
            //questa variabile hit verrà riempita con le informazioni della collisione.

            if(Physics.Raycast(lastRay, out hit, rayMaxDistance, layerMask))
            {
                //se vogliamo sapere con chi abbiamo sbattuto per esempio il nostro collider che sarà cubo.
                //Debug.Log(hit.collider.gameObject);

                //dichiaro un Cube essendo che conosco l'oggetto con cui vado a collider
                //di nome hitcube e all'interno ci metto il debug con tutto quello con cui
                //ho fatto la collisione e con getcomponent mi prendo lo script Cube.cs
                //per poi utilizzare la funzione sotto dichiarata se hitcube non è nullo
                //ovvero che colpisce veramente qualcosa.
                 Cube hitCube = hit.collider.gameObject.GetComponent<Cube>();

                //se abbiamo trovato un cubo.
                if(hitCube)
                {
                    //qua vado a richiamare la funzione onhit presente in Cube
                    //dove non fa altro che cambiare il material al mio oggetto(cubo)
                    //una volta cliccato.
                    hitCube.OnHitByRaycast();
                }
            }
        }
		
	}
}
