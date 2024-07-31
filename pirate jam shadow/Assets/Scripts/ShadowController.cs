using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour
{

    public bool canTeleport;
    public bool backToPlayer = false;

    [field: Header("Components")]
    public GameObject ShadowAnchor;
    public GameObject Player;

    public bool wallCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse1) && !PlayerController.instance.inResonance)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.Lerp(transform.position, cursorPos,0.006f);
            backToPlayer = false;
        }
        if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            backToPlayer = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && canTeleport && !wallCheck && !PlayerController.instance.inResonance)
        {
            Player.transform.position = transform.position;
            transform.position = ShadowAnchor.transform.position;
        }

        if(backToPlayer)
        {
            transform.position = Vector2.Lerp(transform.position, ShadowAnchor.transform.position, 0.006f);
            if(transform.position == ShadowAnchor.transform.position)
            {
                backToPlayer = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyScript enemy=collision.GetComponent<EnemyScript>();
            
            if(!enemy.tagged)
            {
                enemy.tagged = true;
                PlayerStats.instance.meter += 5;
                PlayerStats.instance.soulMeter.value = PlayerStats.instance.meter;
            }
            
        }
    }

    /* private void OnTriggerEnter2D(Collider2D collision)
     {
         if(collision.gameObject.tag == "Floor")
         {
             canTeleport = true;
         }
         if (collision.gameObject.tag == "Wall")
         {
             canTeleport = false;
         }
     }

     private void OnTriggerStay2D(Collider2D collision)
     {
         if (collision.gameObject.tag == "Floor")
         {
             canTeleport = true;
         }
         if (collision.gameObject.tag == "Wall")
         {
             canTeleport = false;
         }

     }

     private void OnTriggerExit2D(Collider2D collision)
     {
         if (collision.gameObject.tag == "Floor")
         {
             canTeleport = false;
         }
     }*/
}
