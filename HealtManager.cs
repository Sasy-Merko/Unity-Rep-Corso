using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtManager : MonoBehaviour
{
    public int healt;
    public int maxhealt;

    void Start()
    {
        healt = maxhealt;
    }

    public void Heal(int amount) 
    {
        Damage(-amount);
    }
    public void Damage(int damageTaken)
    {
        healt -= damageTaken;
        if (healt < 1)
        {
            Debug.LogError("You Dead");
            GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = false;
        
        }

        if (healt > maxhealt)
        {
            healt = maxhealt;
        }

        Debug.Log("Adesso hai " + healt + " punti vita");
    }
}
