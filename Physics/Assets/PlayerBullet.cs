using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Crate"))
        {
            Destroy(gameObject);
        }
    }
}
