using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum objTypes
    {
        Defend,
        Kill,
        Collect,
        Extract
    }

    public GameObject currentObjective;

    public int objectivesCompelte;
    public bool spawnNextObjective;
    private objTypes currentObjectiveType;

    [field: Header("Components")]
    [SerializeField] private GameObject defendPrefab;
    [SerializeField] private GameObject killPrefab;
    [SerializeField] private GameObject collectPrefab;
    [SerializeField] private GameObject extractionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        spawnNextObjective = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnNextObjective)
        {
            SpawnObjective();
        }

        if(!spawnNextObjective)
        {
            CheckObjectives();
        }
    }

    public void checkDefenseObjective()
    {
        DefendObjective defend = currentObjective.GetComponent<DefendObjective>();

        if(defend.time >= defend.timeToDefend)
        {
            Debug.Log("compelted");
            objectivesCompelte++;
            Destroy(defend.gameObject);
            spawnNextObjective = true;
        }
    }
    public void checkCollectObjective()
    {
        CollectObjective collect = currentObjective.GetComponent<CollectObjective>();

        if(collect.collectedAll)
        {
            Debug.Log("compelted");
            objectivesCompelte++;
            Destroy(collect.gameObject);
            spawnNextObjective = true;
        }
    }
    public void checkExtractObjective()
    {
        Extraction extract = currentObjective.GetComponent<Extraction>();

        if (extract.time >= extract.timeToExtract)
        {
            Debug.Log("compelted");
            objectivesCompelte++;
            Destroy(extract.gameObject);
            SceneManager.LoadScene("End Screen");
        }
    }
    public void spawnDefend()
    {
        currentObjective = Instantiate(defendPrefab);
        spawnNextObjective = false;
        currentObjectiveType = objTypes.Defend;
    }
    public void spawnExtraction()
    {
        currentObjective = Instantiate(extractionPrefab);
        spawnNextObjective = false;
        currentObjectiveType = objTypes.Extract;
    }

    public void spawnKill()
    {
        currentObjective = Instantiate(killPrefab);
        spawnNextObjective = false;
        currentObjectiveType = objTypes.Kill;
    }
    public void spawnCollect()
    {
        currentObjective = Instantiate(collectPrefab);
        spawnNextObjective = false;
        currentObjectiveType = objTypes.Collect;
    }

    public void CheckObjectives()
    {
        //Debug.Log(currentObjectiveType);
        switch(currentObjectiveType)
        {
            
            case objTypes.Defend:
                checkDefenseObjective();
                break;
            case objTypes.Kill:
                break;
            case objTypes.Collect: 
                checkCollectObjective();
                break;
            case objTypes.Extract:
                checkExtractObjective();
                break;
        }
    }

    public void SpawnObjective()
    {
        if (objectivesCompelte < 4)
        {
            int num = Random.Range(0, 3);
            Debug.Log(num);
            switch (num)
            {
                case (int)objTypes.Defend:
                    spawnDefend();
                    break;
                case (int)objTypes.Kill:
                    //spawnKill();
                    break;
                case (int)objTypes.Collect:
                    spawnCollect();
                    break;
            }
        }
        else if (objectivesCompelte >= 4)
        {
            spawnExtraction();
        }
    }
}
