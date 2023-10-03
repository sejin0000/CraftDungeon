using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneUI : MonoBehaviour
{
    public Button startBtn;

    
    private AudioClip bgmClip;

    public void Start()
    {
        SoundManager soundManager = SoundManager.Instance;
        bgmClip = soundManager.GetOrAddAudioClip("AudioSource/bgm/mainScenebgm", SoundManager.Sound.bgm);
        AudioSource bgm = soundManager.transform.GetChild(0).GetComponent<AudioSource>();
        bgm.clip = bgmClip;
        bgm.loop = true;
        bgm.volume = 0.3f;
        soundManager.Play(bgm.clip, SoundManager.Sound.bgm);
        
    }
    public void StartBtnClicked()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }
}
