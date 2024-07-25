using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillObjective : MonoBehaviour
{
    public int enemiesToKill;
    // Start is called before the first frame update
    void Start()
    {
        enemiesToKill = Random.Range(20, 30);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
