using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Transform _transform;
    private const float moveLimit = 4f;
    private float prevYPos;

    private void Start()
    {
        _transform = transform;
        prevYPos = target.transform.position.y;
    }

    private void Update()
    {
        if (target != null)
        {
            var yPos = target.transform.position.y;
            if (yPos < -10f) return;
            if (Mathf.Abs(yPos - prevYPos) > moveLimit)
            {
                var newPos = _transform.position;
                newPos.y = yPos;
                _transform.position = newPos;
                prevYPos = yPos;
            }
        }
    }
}
