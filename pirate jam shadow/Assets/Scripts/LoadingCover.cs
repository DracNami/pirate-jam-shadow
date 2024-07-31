using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingCover : MonoBehaviour
{
    public List<string> loads;
    int loadsIndex = 0;
    public TMP_Text text;
    public TMP_Text whatDoingText;
    float timer = 0f;
    float waitTime = 0.2f;
    public bool wGen = false;
    public bool eSpawn = false;
    public GameObject panel;
    bool active = true;
    private void Start()
    {
        panel.SetActive(true);
    }
    void Update()
    {
        if (active)
        {
            if (!wGen && !eSpawn)
            {
                whatDoingText.text = "Generating Map";
            }
            else if (wGen && !eSpawn)
            {
                whatDoingText.text = "Spawning Enemies";
            }
            if (timer >= waitTime)
            {
                text.text = loads[loadsIndex];
                loadsIndex++;
                if (loadsIndex >= loads.Count) loadsIndex = 0;
                timer = 0f;
            }
            else
            {
                timer += Time.deltaTime;
            }
            if (wGen && eSpawn)
            {
                Close();
            }
        }
    }
    void Close()
    {
        PlayerController.instance.canMove = true;
        panel.SetActive(false);
        active = false;
    }
}
