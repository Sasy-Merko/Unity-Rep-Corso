using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogShooter : MonoBehaviour {

    public int score;


    //andrà a stampare il messaggio che gli passiamo come parametro.
	public void ShootLog(string message)
    {
        Debug.Log("Shooting: " + message);
    }
}
