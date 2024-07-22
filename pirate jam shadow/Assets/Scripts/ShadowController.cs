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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse1))
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.Lerp(transform.position, cursorPos,0.006f);
        }
        if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            backToPlayer = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
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
}
