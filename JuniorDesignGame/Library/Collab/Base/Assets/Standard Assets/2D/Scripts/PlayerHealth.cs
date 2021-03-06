﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider HealthSlider;                                 // Reference to the UI's health bar.
    //public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    //public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
    

    Animator anim;                                              // Reference to the Animator component.
    //AudioSource playerAudio;                                    // Reference to the AudioSource component.
    bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.


    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        //playerAudio = GetComponent<AudioSource>();

        // Set the initial health of the player.
        currentHealth = startingHealth;
    }


    void Update()
    {
        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            //damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            //damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        //Debug.Log(currentHealth);
        // Reset the damaged flag.
        damaged = false;
        //testing the damage taken
        if(Input.GetKeyDown(KeyCode.B)==true)
        {
            TakeDamage(10);
        }
        if(Input.GetKeyDown(KeyCode.L) == true)
        {
            TakeDamage(-10);
        }
    }


    public void TakeDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Set the health bar's value to the current health.
        HealthSlider.value = currentHealth;

        // Play the hurt sound effect.
        //playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            //Debug.Log("I should have 0 Health");
            Death();
            new WaitForSeconds(2);
            SceneManager.LoadScene("Scene3");
        }
    }


    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;
        //this.gameObject.ge = false;
        


        // Tell the animator that the player is dead.
        anim.SetTrigger("Death");

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        //playerAudio.clip = deathClip;
        //playerAudio.Play();

    }

    public void increaseHealth(int amount)
    {
        HealthSlider.maxValue += amount;
        currentHealth = (int)HealthSlider.maxValue;
        HealthSlider.value = currentHealth;
    }
}

