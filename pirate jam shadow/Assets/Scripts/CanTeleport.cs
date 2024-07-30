using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanTeleport : MonoBehaviour
{
    public ShadowController shadow;
    public EnemySpawner eSpawner;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shadow")
        {
            Debug.Log("Shadow enter");
            shadow.canTeleport = true;
        }
        else if (collision.gameObject.tag=="Enemy")
        {

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shadow")
        {
            Debug.Log("Shadow exit");
            shadow.canTeleport = false;
        }
    }
}
