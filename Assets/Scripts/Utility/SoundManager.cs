using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;
    
    AudioSource[] _audioSources = new AudioSource[(int)Sound.Max];
    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();
    enum Sound
    {
        Bgm,
        Effect,
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

    AudioClip GetOrAddAudioClip(string path, Sound type = Sound.Max)
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
}
