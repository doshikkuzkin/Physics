using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePlatform : MonoBehaviour
{
    [SerializeField] private float force = 1200f;

    public float Force
    {
        get => force;
        set => force = value;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var rigid = other.collider.attachedRigidbody;
            rigid.AddForce(Vector3.up * force);
        }
    }
}
