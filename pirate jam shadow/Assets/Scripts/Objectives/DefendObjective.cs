using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendObjective : MonoBehaviour
{
    public float time;
    public float timeToDefend;

    public bool enemiesInside;
    // Start is called before the first frame update
    void Start()
    {
        timeToDefend = Random.Range(20, 30);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !enemiesInside)
        {
            time += Time.deltaTime;
        }

        if(collision.gameObject.tag == "Enemy")
        {
            enemiesInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemiesInside = false;
        }
    }
}
