using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendObjective : MonoBehaviour
{
    public float time;
    public float timeToDefend = 1;

    public bool enemiesInside;
    public bool increaseTime;
    // Start is called before the first frame update
    void Start()
    {
        timeToDefend = Random.Range(20, 30);
    }

    // Update is called once per frame
    void Update()
    {
        if(increaseTime && !enemiesInside)
        {
            time += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !enemiesInside)
        {
            increaseTime = true;
        }

        if(collision.gameObject.tag == "Enemy" || enemiesInside)
        {
            enemiesInside = true;
            increaseTime = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !enemiesInside)
        {
            increaseTime = true;
        }

        if(collision.gameObject.tag == "Enemy" || enemiesInside)
        {
            enemiesInside = true;
            increaseTime = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemiesInside = false;
        }

        if (collision.gameObject.tag == "Player" )
        {
            increaseTime = false;
        }

    }
}
