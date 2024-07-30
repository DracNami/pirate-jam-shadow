using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public WalkerGenerator waGen;
    int H;
    int W;
    public bool initSpawning = false;
    bool started = false;
    public int totalInitialEnemies=10;
    public int curEnemies=0;
    public int MaxEnemies=30;
    public int EnemiesPerWave = 2;
    public float timeBetweenSpawns=2f;
    float timer = 0f;
    
    void Update()
    {
        if (initSpawning)
        {
            while (curEnemies < totalInitialEnemies)
            {
                int x = Random.Range(0,W);
                int y = Random.Range(0,H);
                Instantiate(EnemyPrefab,new Vector3(x,y,0),Quaternion.identity);
                curEnemies++;
            }
            initSpawning = false;
            FindObjectOfType<LoadingCover>().eSpawn = true;
        }
        else if(started)
        {
            if (timer >= timeBetweenSpawns)
            {
                for (int i = 0; i < EnemiesPerWave; i++)
                {
                    if (curEnemies < MaxEnemies)
                    {
                        int x = Random.Range(0, W);
                        int y = Random.Range(0, H);
                        Instantiate(EnemyPrefab, new Vector3(x, y, 0), Quaternion.identity);
                        curEnemies++;
                    }
                }
                timer = 0f;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }
    public void Initial()//call when map is done forming;
    {
        H = waGen.MapHeight;
        W = waGen.MapWidth;
        initSpawning = true;
        started = true;
    }
}
