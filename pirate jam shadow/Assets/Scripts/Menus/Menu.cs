using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void swapScene(string s)
    {
        AudioManager.Instance.PlaySFX2d("ButtonPress");
        SceneManager.LoadScene(s);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
