using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform _target;
    public float lerpSpeed = 1.0f;

    private Vector3 _offset;

    private Vector3 _targetPos;

    private void Start()
    {
        if (_target == null) return;

        _offset = transform.position - _target.position;
    }

    private void Update()
    {
        if (_target == null) return;

        _targetPos = _target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, _targetPos, lerpSpeed * Time.deltaTime);
    }


    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
