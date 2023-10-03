using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    
    AudioSource[] _audioSources = new AudioSource[(int)Sound.Max];
    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();
    public enum Sound
    {
        bgm,
        effect,
        Max,
    }
    
    void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
            GameObject root = this.gameObject;
            string[] soundTypes = System.Enum.GetNames(typeof(Sound));
            for (int i = 0; i < soundTypes.Length - 1; i++)
            {
                GameObject go = new GameObject { name = soundTypes[i] };
                _audioSources[i] = go.AddComponent<AudioSource>();
                go.transform.parent = root.transform;
            }

            _audioSources[(int)Sound.bgm].loop = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static SoundManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public AudioClip GetOrAddAudioClip(string path, Sound type = Sound.effect)
    {
        if (path.Contains("AudioSource/") == false)
            path = $"AudioSource/{path}"; 

        AudioClip audioClip = null;

        if (type == Sound.Max) // BGM 배경음악 클립 붙이기
        {
            audioClip =  Resources.Load<AudioClip>(path);
        }
        else // Effect 효과음 클립 붙이기
        {
            if (_audioClips.TryGetValue(path, out audioClip) == false)
            {
                audioClip = Resources.Load<AudioClip>(path);
                _audioClips.Add(path, audioClip);
            }
        }

        if (audioClip == null)
            Debug.Log($"AudioClip Missing ! {path}");

        return audioClip;
    }

    public void Play(AudioClip audioClip, Sound type = Sound.effect, float pitch = 1.0f)
    {
        if (audioClip == null)
            return;

        if (type == Sound.bgm) // BGM 배경음악 재생
        {
            AudioSource audioSource = _audioSources[(int)Sound.bgm];
            if (audioSource.isPlaying)
                audioSource.Stop();

            audioSource.pitch = pitch;
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else // Effect 효과음 재생
        {
            AudioSource audioSource = _audioSources[(int)Sound.effect];
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip);
        }
    }
}
