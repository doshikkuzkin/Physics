using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnknownPlatform : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private float force;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var _platform = Instantiate(platform, transform.position, Quaternion.identity);
            var forceComponent = _platform.GetComponent<ForcePlatform>();
            if (forceComponent != null)
            {
                forceComponent.Force = force;
            }
            Destroy(gameObject);
        }
    }
}
