﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    #region Singleton
    private static PlayerHealth _instance = null;

    public static PlayerHealth Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerHealth>();

                if (_instance == null)
                {
                    Debug.LogError("Fatal Error: PlayerHealth not Found");
                }
            }

            return _instance;
        }
    }
    #endregion

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    bool isDead;                                                
    bool damaged;                                               


    void Awake()
    {
        //ambil komponen
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();

        playerShooting = GetComponentInChildren<PlayerShooting>();
        currentHealth = startingHealth;
    }

    void Update()
    {
        //kalo kena damage
        if (damaged)
        {
            //ubah warna gambar jadi flashcolour
            damageImage.color = flashColour;
        }
        else
        {
            //fade out damageimage
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        //set damage ke false
        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        damaged = true;

        //kurangi health
        currentHealth -= amount;

        //update slider
        healthSlider.value = currentHealth;

        //play suara kena damage
        playerAudio.Play();

        //jika darah < 0, panggil method Death()
        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        
        playerShooting.DisableEffects();

        //triger animasi die
        anim.SetTrigger("Die");

        //play sfx pas mati
        playerAudio.clip = deathClip;
        playerAudio.Play();

        //matiin script playermovement & playershooting
        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }

    //tambah darah pemain sebanyak amount
    public void AddHealth(int amount)
    {
        if(currentHealth < startingHealth)
        {
            currentHealth += amount;

            healthSlider.value = currentHealth;
        }
    }

    public void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
