using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterTrigger : MonoBehaviour
{

    public GameObject logShooterObject;

    // Update is called once per frame
    void Update()
    {
        //quando viene premuto il tasto S della tastiera
        //getkeydown è l'evento quando un tasto viene premuto.
        //quando lo rilascio è getkeyup
        //solo getkey e quando continua ad essere premuto.
        if (Input.GetKeyDown(KeyCode.S))
        {
            LogShooter logShooter = logShooterObject.GetComponent<LogShooter>();
            //se esiste il logshooter spara questa cosa qua altrimenti no 
            //questo se nel nostro oggetto non teniamo il logshooter script.
            if (logShooter)
            {
                logShooter.score = 10;
                logShooter.ShootLog("Hello");
            }
        }
    }
}
