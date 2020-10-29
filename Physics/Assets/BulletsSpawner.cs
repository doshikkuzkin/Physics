using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    private float attackTime = 0;
    [SerializeField] private float timeBetweenAttacks = 1f;
    private Vector2[] forces = new Vector2[] {new Vector2(5.5f, 5f), new Vector2(-5f, 6f)};
    private int forceIndex = 0;

    private void Update()
    {
        attackTime += Time.deltaTime;
        if (attackTime >= timeBetweenAttacks)
        {
            attackTime = 0;
            Rigidbody2D rigidbody2D = Instantiate(bullet, transform.position, Quaternion.identity)
                .GetComponent<Rigidbody2D>();
            forceIndex++;
            if (forceIndex >= forces.Length) forceIndex = 0;
            rigidbody2D.AddForce(forces[forceIndex], ForceMode2D.Impulse);
        }
    }
}
