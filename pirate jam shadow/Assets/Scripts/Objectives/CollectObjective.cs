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
            int randomX = Random.Range(0, WalkerGenerator.Instance.gridHandler.GetLength(0));
            int randomY = Random.Range(0, WalkerGenerator.Instance.gridHandler.GetLength(1));

            while (WalkerGenerator.Instance.gridHandler[randomX, randomY] != WalkerGenerator.Grid.FLOOR)
            {
                randomX = Random.Range(0, WalkerGenerator.Instance.gridHandler.GetLength(0));
                randomY = Random.Range(0, WalkerGenerator.Instance.gridHandler.GetLength(1));
            }
            Vector2 randomSpawnPosition = new Vector2(randomX, randomY);
            Instantiate(collectablePrefab,randomSpawnPosition,Quaternion.identity,transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(collected >= collectables)
        {
            collectedAll = true;
        }
    }
}
