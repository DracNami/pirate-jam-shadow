using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum objTypes
    {
        Defend,
        Kill,
        Collect
    }

    public GameObject currentObjective;

    public int objectivesCompelte;
    public bool spawnNextObjective;
    private objTypes currentObjectiveType;

    [field: Header("Components")]
    [SerializeField] private GameObject defendPrefab;
    [SerializeField] private GameObject killPrefab;
    [SerializeField] private GameObject collectPrefab;
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
            objectivesCompelte++;
            //spawnNextObjective = true;
        }
    }
    public void spawnDefend()
    {
        currentObjective = Instantiate(defendPrefab);
        spawnNextObjective = false;
        currentObjectiveType = objTypes.Defend;
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
        Debug.Log(currentObjectiveType);
        switch(currentObjectiveType)
        {
            
            case objTypes.Defend:
                checkDefenseObjective();
                break;
            case objTypes.Kill:
                break;
            case objTypes.Collect: 
                break;
        }
    }

    public void SpawnObjective()
    {
        int num = Random.Range(0, 3);
        Debug.Log(num);
        switch(num)
        {
            case (int)objTypes.Defend:
                spawnDefend();
                break;
            case (int)objTypes.Kill:
                //spawnKill();
                break;
            case (int)objTypes.Collect:
                //spawnCollect();
                break;
        }
    }
}
