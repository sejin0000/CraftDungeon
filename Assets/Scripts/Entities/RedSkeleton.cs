using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSkeleton : MonoBehaviour
{
    private enum Pattern
    {
        Run, SpawnSkeleton
    }

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private Pattern _pattern = Pattern.Run;

    private float _patternCooltime = 0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        WaitForNextPattern(2f);
    }


    private void FixedUpdate()
    {
        if(_patternCooltime > 0f)
        {
            _patternCooltime -= Time.fixedDeltaTime;

            return;
        }

        switch (_pattern)
        {
            case Pattern.Run:
                break;
            case Pattern.SpawnSkeleton:
                break;
        }
    }

    private void WaitForNextPattern(float timer)
    {
        _patternCooltime = timer;
    }

    public void Run()
    {
        StartCoroutine(RunCoroutine());
    }

    private IEnumerator RunCoroutine()
    {
        while (true)
        {
            //_rigidbody.MovePosition

            yield return null;
        }
    }
}
