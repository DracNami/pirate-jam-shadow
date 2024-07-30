using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingCover : MonoBehaviour
{
    public List<string> loads;
    int loadsIndex = 0;
    public TMP_Text text;
    float timer = 0f;
    float waitTime = 0.2f;
    void Update()
    {
        if (timer >= waitTime) {
            text.text = loads[loadsIndex];
            loadsIndex++;
            if (loadsIndex >= loads.Count) loadsIndex = 0;
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
