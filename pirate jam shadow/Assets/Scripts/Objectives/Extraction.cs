using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extraction : MonoBehaviour
{
    public float time;
    public float timeToExtract = 1;

    public bool increaseTime;
    // Start is called before the first frame update
    void Start()
    {
        timeToExtract = Random.Range(120, 180);
    }

    // Update is called once per frame
    void Update()
    {
        if (increaseTime)
        {
            time += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            increaseTime = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            increaseTime = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            increaseTime = false;
        }
    }
}
