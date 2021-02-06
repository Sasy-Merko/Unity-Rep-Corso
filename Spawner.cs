using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //vediamo come spawnare più cubi ogni volta che clicco.




    //questa cosa qua ci permette di farla apparire nell'inspector
    [SerializeField]
    GameObject cubePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Sono spawnato " + gameObject.name, gameObject);

        //vuole l'oggetto che dobbiamo spawnare
        //Instantiate(cubePrefab);
    }

    // Update is called once per frame
    void Update()
    {
        //con questo if vado a verificare quale pulsante del mouse 
        //vado a cliccare per generare il cubo ogni volta che clicco
        //sinistro è numero 0 invece l'1 è il tasto destro.
        //questo è quando viene rilasciato il tasto sinistro del mouse.
         if (Input.GetMouseButtonUp(0))
          {
              //vector 3 sarebbe la coordinata tredimensionale
              //x -y -z con la stessa identica rotazione che ha l'oggetto cubePrefab.
              Instantiate(cubePrefab,new Vector3(Random.Range(-5,5),Random.Range(-5,5),Random.Range(-5,5)),cubePrefab.transform.rotation);
          }

    }
}
