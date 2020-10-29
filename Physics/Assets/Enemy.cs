using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] movePoints;
    [SerializeField] private float speed = 5f;

    private Transform target;
    private int pointIndex;
    private Transform _transform;
    private Vector3 targetPosition;

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        pointIndex = 0;
        target = movePoints[pointIndex];
        targetPosition = new Vector2(target.position.x, _transform.position.y);
    }

    private void Update()
    {
        var position = _transform.position;
        _transform.position = Vector2.MoveTowards(position, targetPosition,
            speed * Time.deltaTime);
        if (Vector2.Distance(position, targetPosition) < 1f)
        {
            pointIndex++;
            if (pointIndex >= movePoints.Length) pointIndex = 0;
            target = movePoints[pointIndex];
            targetPosition = new Vector2(target.position.x, _transform.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}
