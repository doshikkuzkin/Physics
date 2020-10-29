using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float bulletSpeed;

    public void Shoot(float direction)
    {
        var bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity).GetComponent<Rigidbody2D>();
        bullet.velocity = new Vector2(direction, 0) * bulletSpeed;
    }
}
