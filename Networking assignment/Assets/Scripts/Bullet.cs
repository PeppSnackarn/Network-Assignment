using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Bullet : NetworkBehaviour
{
    public float Damage = 15;
    public float Force = 10;
    public Vector2 rotation;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collission");
        if (other.gameObject.CompareTag("Player"))
        {
            Health health = other.gameObject.GetComponent<Health>();
            health.TakeDamage(Damage);
            Debug.Log("Damage player");
        }
        DestroyBulletRPC();
    }

    private void Update()
    {
        foreach (Collider collider in Physics.OverlapSphere(transform.position, 10))
        {
          Debug.Log(collider.gameObject);  
        }
    }

    public override void OnNetworkSpawn()
    {
        Rigidbody2D rb;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * Force;
    }

    [Rpc(SendTo.Server)]
    private void DestroyBulletRPC()
    {
        Destroy(gameObject);
    }
    
}
