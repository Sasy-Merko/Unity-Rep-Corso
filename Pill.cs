using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour
{
    [SerializeField]
    AudioSource audiosource;
    public bool goUp;
    public float speed = 0.25f;
    public float rotationspeed = 50;

    private void Start()
    {
        StartCoroutine(SwitchDirection());
    }
    void Update()
    {
        //questo serve per farlo andare su e giù dopo un certo arco di tempo impostato da noi e dalla velocità.
        if (goUp)
        {
            transform.position = transform.position + new Vector3(0, speed * Time.deltaTime, 0);
        }
        else
        {
            transform.position = transform.position - new Vector3(0, speed * Time.deltaTime, 0);
        }

        //per poter invece farlo ruotare
        //quindi ruota il nostro transform sull'asse Vector3.up che sarebbe (0,1,0) asse y
        //se avessi messo (1,0,0)asse x.
        //abbiamo aggiunto spaceworld per una questione di asse inversa quindi bisogna mettere quello dello space world.
        //per non creare confusione, gli dico non di utilizzare il loro riferimento di asse locale ma quello globale (space world).
        transform.Rotate(Vector3.up, rotationspeed * Time.deltaTime, Space.World);
    }
    //che sarebbe cambiare la direzione della nostra pillola per fare in modo
    //che vada sopra e giù da solo senza spuntare la casella goup che poi dopo vado a togliere
    //come serialize.
    IEnumerator SwitchDirection()
    {
        //finchè questo oggetto è attivo
        while (gameObject.activeSelf)
        {
            //aspettiamo un tot di tempo che in questo caso è 5 secondi
            //dopodichè invertiamo il goUp.
            yield return new WaitForSeconds(0.5f);
            goUp = !goUp;
        }
    }
    //quindi qui che faccio 
    void OnTriggerEnter(Collider other)
    {

        //qua vado a modificare il compareTag dei miei player ovvero il Tag e gli dico quando entra in collisione con questo
        //genera questo effetto.
        if (other.CompareTag("Player")) 
        {
            OnPicked(other);
        }
    }

    //questo metodo viene richiamato quando noi prendiamo la pillola in game.
    protected virtual void OnPicked(Collider other)
    {
        
        //facendo così noi stiamo dicendo che noi vogliamo suonare il suono impostato all'interno della nostra source.
        audiosource.Play();
        HidePill();
        //questo getcomponent in pratica fa si che alla prima collisione con il nostro giocatore
        //si attiverà e genererà l'effetto se ci vado di nuovo sopra non si attiverà perchè l'ho disattivato.
        GetComponent<Collider>().enabled = false;
        //Debug.Log("Hai preso" + gameObject.name);    
    }

    void HidePill() 
    {
        //non fa altro che nascondere la pillola una volta presa.
        GetComponent<Renderer>().enabled = false;
    
    
    }
}
