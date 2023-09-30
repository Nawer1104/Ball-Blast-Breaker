using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float speed;
    public void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, null);
        projectile.transform.position = this.transform.position;
        projectile.GetComponent<Rigidbody2D>().AddRelativeForce(-this.transform.right * speed);
    }

    public void SetProjectile(GameObject projectile) 
    {
        projectilePrefab = projectile;
    }
}