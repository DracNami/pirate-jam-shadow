using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource bgmSource;
    public AudioSource superBGMsource;
    public AudioSource sfxSource;

    void Start()
    {
        EnableSuperBGM(false);
        bgmSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableSuperBGM(bool isEnabled)
    {
        if (isEnabled)
        {
            bgmSource.volume = 0.0f;
            superBGMsource.volume = 1.0f;
        }
        else
        {
            bgmSource.volume = 1.0f;
            superBGMsource.volume = 0.0f;
        }
    }
}
 