using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float HP = 100;
    private float fullHP = 0;

    private void Start()
    {
        fullHP = HP;
    }

    void Update()
    {
        if (HP <= 0)
        {
            KillPlayerRPC();
        }
    }

    public void TakeDamage(float value)
    {
        HP -= value;
    }

    [Rpc(SendTo.Server)]
    private void KillPlayerRPC()
    {
        gameObject.GetComponent<NetworkObject>().Despawn();
    }
}
