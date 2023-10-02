using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager instance;   
    public ParticleSystem effect;
    private void Awake()
    {
        instance = this;
    }

    public void effectOn(Transform transform)
    {
        Instantiate(effect).transform.position = transform.position;
    }
}
