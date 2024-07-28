using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    CollectObjective collectObj;
    private void Start()
    {
        collectObj = GameObject.FindAnyObjectByType<CollectObjective>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collectObj.collected++;
            Destroy(this.gameObject);
        }
    }

}
