using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
public class HealtManager : MonoBehaviour
{
    public int healt;
    public int maxhealt;

    //riferimento a quel componente di testo per la salute.
    public Text lblHealt;
    public Slider sliderHealt;
    public GameObject pnlDeath;

    //public Button btnRespawn;

    float currentHealtPercentage
    {

        //quello che ho fatto è stato vita attuale diviso vita massima
        //* 100 il tutto sotto forma di float in modo tale che posso dare un valore
        //tra 0 che è il minimo dello slider e 1 che è il massimo 
        get 
        {
            return ((float)(healt) / (float)(maxhealt));
        }
    }

    void Start()
    {
        healt = maxhealt;
        //lblHealt.text = "Salute: " + healt;
        sliderHealt.value = currentHealtPercentage;
        UpdateHealtBarColor();
        //spegniamo il gameobject così tipo come nell'inspector.
        pnlDeath.SetActive(false);


        //btnRespawn.onClick.AddListener(Respawn);
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

            Die();
        
        }

        if (healt > maxhealt)
        {
            healt = maxhealt;
        }


        sliderHealt.value = currentHealtPercentage;

        //debug verifica errore salute
        //Debug.LogError(currentHealtPercentage);

        //label per la vita salute.
        //lblHealt.text = "Salute: " + healt;       
        //Debug.Log("Adesso hai " + healt + " punti vita");
        UpdateHealtBarColor();
    }



    //update per quanto riguarda la salute il colore se deve essere verde arancio o rosso.
    //in base al mio stato di energia.
    void UpdateHealtBarColor() 
    {
        Image  fillImage = sliderHealt.fillRect.GetComponent<Image>();
        if (currentHealtPercentage >= 0.75f)
        {
            fillImage.color = Color.green;
            //verde

        }
        else if (currentHealtPercentage >= 0.25f && currentHealtPercentage < 0.75f)
        {

            fillImage.color = Color.yellow;
            //arancio
        }

        else 
        {
            fillImage.color = Color.red;
            //rosso
        }

    }

    public void Die()
    {
        //per far si che quando muori si attiva il mouse nella schermata di gioco.
        RigidbodyFirstPersonController movementController = GetComponent<RigidbodyFirstPersonController>();
        movementController.enabled = false;
        movementController.mouseLook.SetCursorLock(false);


        //Debug.LogError("You Dead");
        pnlDeath.SetActive(true);

    }

    public void Respawn() 
    {
        pnlDeath.SetActive(false);
        RigidbodyFirstPersonController movementController = GetComponent<RigidbodyFirstPersonController>();
        movementController.mouseLook.SetCursorLock(true);
        movementController.enabled = true;
        healt = maxhealt; 
        sliderHealt.value = currentHealtPercentage;
        UpdateHealtBarColor();
    }
}
