using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public bool alive = true;                               //Player alive status
    public int meter { get; private set; }                //stamina charge based system
    [SerializeField] int maxMeter = 100;                      //base maximum value for stamina

    public int health { get; private set; }                 //health segmented
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
        soulMeter.value = 0;
        //FullyHeal();
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
/*    public void UpdateUI()
    {
        if (healthList.Count != health)
        {
            if (healthList.Count > health)
            {
                while (healthList.Count > health)
                {
                    GameObject temp = healthList[healthList.Count - 1];
                    healthList.Remove(temp);
                    Destroy(temp);
                }
            }
            else
            {
                while (healthList.Count < health)
                {
                    var healthUI = Instantiate(healthImage, new Vector3(0, 0, 0), Quaternion.identity);
                    healthUI.transform.parent = healthFolder.transform;
                    healthList.Add(healthUI);
                }
            }
        }
        if (staminaList.Count != stamina)
        {
            if (staminaList.Count > stamina)
            {
                while (staminaList.Count > stamina)
                {
                    GameObject temp = staminaList[staminaList.Count - 1];
                    staminaList.Remove(temp);
                    Destroy(temp);
                }
            }
            else
            {
                while (staminaList.Count < stamina)
                {
                    var staminaUI = Instantiate(staminaImage, new Vector3(0, 0, 0), Quaternion.identity);
                    staminaUI.transform.parent = staminaFolder.transform;
                    staminaList.Add(staminaUI);
                }
            }
        }
    }*/
    /*public void GainStamina(int value)                      //gain stamina not exceeding max
    {
        stamina += value;
        if (stamina > maxStamina*//*+number of stamina upgrades from future script*//*)                     //idea for this is that in the save data or playerprefs, something, we can store how many upgrades the player has and use that here so we do not have to code backwards when adding upgrades, feel free to change tho if better idea
        {
            stamina = maxStamina*//*+number of stamina upgrades from future script*//*;
        }
        //UpdateUI();
    }*/
    /*public bool SpendStamina(int value)                     //Check if player has enough stamina to spend, if so spends and returns true
    {
        if (value <= stamina)
        {
            stamina -= value;
            //UpdateUI();
            return true;
        }
        else return false;
    }*/
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
    public void TakeDammage(int value)                      //if alive, lose health, if none remaining, kill player
    {
        if (alive)
        {
            health -= value;
            healthBar.value = health;
            if (health >= 0)
            {
                alive = false;
            }
        }
        //UpdateUI();
    }
    public void FullyHeal()                                 //sets stamina and health to max, for use on level start or reviving
    {
        meter = 0/*+number of stamina upgrades from future script*/;
        health = maxHealth/*+number of health upgrades from future script*/;
        alive = true;
        //UpdateUI();
    }
}
