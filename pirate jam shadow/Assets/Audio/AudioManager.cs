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
    public List<SFX> sfxList;
    public GameObject sfx3dOneshot;

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
            if (superBGMsource.isPlaying == false) superBGMsource.Play();
        }
        else
        {
            bgmSource.volume = 1.0f;
            superBGMsource.volume = 0.0f;
        }
    }

    void PlaySFX2d(string sfxName)
    {
        if (sfxName == null)
        {
            Debug.Log("No SFX name was provided!");
            return;
        }
        else
        {
            for (var index = 0; index < sfxList.Count; index++)
            {
                if (sfxName == sfxList[index].sfxName)
                {
                    Debug.Log("Found sfx! Playing...");
                    var randomClip = (int)Random.Range(0, sfxList[index].clips.Count - 1);
                    sfxSource.PlayOneShot(sfxList[index].clips[randomClip]);
                    return;
                }
                else Debug.Log("No SFX of that name found.");
            }
        }
    }
    void PlaySFX3d(string sfxName, Transform targetTrans)
    {
        //target trans cameo :3 we be targeting trans people for our love and affection
        if (sfxName == null)
        {
            Debug.Log("No SFX name was provided!");
            return;
        }
        else
        {
            for (var index = 0; index < sfxList.Count; index++)
            {
                if (sfxName == sfxList[index].sfxName)
                {
                    Debug.Log("Found sfx! Playing...");
                    var randomClip = (int)Random.Range(0, sfxList[index].clips.Count - 1);
                    var oneshotObj = Instantiate(sfx3dOneshot,targetTrans);
                    oneshotObj.GetComponent<AudioSource>().PlayOneShot(sfxList[index].clips[randomClip]);
                    StartCoroutine(Kill3dOneshot(oneshotObj,3.0f));
                    return;
                }
                else Debug.Log("No SFX of that name found.");
            }
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
    IEnumerator Kill3dOneshot(GameObject oneshotObj, float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        Destroy(oneshotObj);
    }
}
 