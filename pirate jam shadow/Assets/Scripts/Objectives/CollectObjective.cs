using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObjective : MonoBehaviour
{
    public int collectables;
    public int collected;

    public bool collectedAll;

    public GameObject collectablePrefab;
    void Start()
    {
        collectables = Random.Range(1, 5);
        for (int i = 0; i < collectables; i++)
        {
            Vector2 randomSpawnPosition = new Vector2(Random.Range(-10, 11), Random.Range(-10,11));
            Instantiate(collectablePrefab,randomSpawnPosition,Quaternion.identity,transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(collected == collectables)
        {
            collectedAll = true;
        }
    }
}
