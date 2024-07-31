using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public bool alive = true;                               //Player alive status
    public float meter = 0;                //stamina charge based system
    [SerializeField] int maxMeter = 100;                      //base maximum value for stamina

    public int health = 100;                 //health segmented
    [SerializeField] int maxHealth = 100;                     //base maximum value for health

    public Slider healthBar;

    public Slider soulMeter;                         //group holding stamina UI

    bool respawnLocal = false;                              //determines if the player will respawn in current scene or get sent back to hub
    public string hubSceneName;                              //scene to go to
    public GameObject respawnLocalPosition;

    public static PlayerStats instance;

    
    private void Start()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = health;

        soulMeter.maxValue = maxMeter;
        soulMeter.value = meter;
        FullyHeal();
    }

    protected void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (alive)
        {
            
        }
        else
        {
            //Respawn();
        }
    }
    public void Respawn()
    {
        if (!respawnLocal)
        {
            SceneManager.LoadScene(hubSceneName);
        }
        else
        {
            if (respawnLocalPosition != null)
            {
                this.gameObject.transform.position = respawnLocalPosition.transform.position;
                alive = true;
                FullyHeal();
            }
        }
    }
    public void GainHealth(int value)                       //if alive, gain Health not exceeding max
    {
        if (alive)
        {
            health += value;
            if (health > maxHealth/*+number of health upgrades from future script*/)
            {
                health = maxHealth;
            }
        }
    }
    public void TakeDamage(int value)                      //if alive, lose health, if none remaining, kill player
    {
        if (alive)
        {
            health -= value;
            healthBar.value = health;
            if (health <= 0)
            {
                alive = false;
            }
        }
    }
    public void FullyHeal()                                 //sets stamina and health to max, for use on level start or reviving
    {
        meter = 0;
        health = maxHealth;
        alive = true;
    }
}
