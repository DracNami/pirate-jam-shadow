using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public AudioSource bgmSource;
    public AudioSource superBGMsource;
    public AudioSource sfxSource;
    public AudioClip bgmClip;
    private AudioClip bgmClipLastUpdate;
    private Scene sceneLastUpdate;

    private void Awake()
    {
        if (Instance != null)
        {
            //pass this instance's info to the main music manager, then destroy self
            AudioManager.Instance.bgmClip = bgmClip;
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            Debug.Log(Instance);
        }

    }
    private void Start()
    {
        NewSceneActOnInfo();
    }
    private void Update()
    {
        if (sceneLastUpdate != SceneManager.GetActiveScene()) NewSceneActOnInfo();

        bgmClipLastUpdate = bgmClip;
        sceneLastUpdate = SceneManager.GetActiveScene();
    }

    public void EnableResonanceBGM(bool isEnabled)
    {
        if (isEnabled)
        {
            bgmSource.volume = 0.0f;
            superBGMsource.volume = 1.0f;
            superBGMsource.Play();
        }
        else
        {
            bgmSource.volume = 1.0f;
            superBGMsource.volume = 0.0f;
            superBGMsource.Stop();
        }
    }

    void NewSceneActOnInfo()
    {
        if (bgmClip == null) return;
        else
        {
            if (bgmClipLastUpdate != bgmClip)
            {
                EnableResonanceBGM(false);
                bgmSource.Stop();
                bgmSource.clip = bgmClip;
                bgmSource.Play();
            }
        }
    }
}
 