using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Unity.Netcode;
using Unity.Netcode.Components;

public class PlayerMovement : NetworkBehaviour
{
    //private NetworkVariable<Rigidbody2D> rb = new NetworkVariable<Rigidbody2D>(writePerm: NetworkVariableWritePermission.Owner);
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 5;
    //private Vector2 moveDir;
    private NetworkVariable<Vector2> moveDir = new NetworkVariable<Vector2>(readPerm: NetworkVariableReadPermission.Everyone, writePerm: NetworkVariableWritePermission.Owner);
    private NetworkVariable<Vector2> mousePos = new NetworkVariable<Vector2>(readPerm: NetworkVariableReadPermission.Everyone, writePerm: NetworkVariableWritePermission.Owner);
    private Gun gun;
    void Start()
    {
        if (IsLocalPlayer)
        {
            rb = GetComponent<Rigidbody2D>();
            gun = GetComponentInChildren<Gun>();
        }
        
    }

    void Update()
    {
        if (IsLocalPlayer)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");
            moveDir = new NetworkVariable<Vector2>( new Vector2(moveX, moveY).normalized * speed);
            UpdateVelocityRPC(moveDir.Value);
            mousePos.Value = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         
            NetworkVariable<Vector2> aimDir = new NetworkVariable<Vector2>(mousePos.Value - rb.position);
            NetworkVariable<float> aimAngle = new NetworkVariable<float>(Mathf.Atan2(aimDir.Value.y, aimDir.Value.x) * Mathf.Rad2Deg - 90f);
            UpdateRotationRPC(aimAngle.Value);
           
            if (Input.GetKeyDown(KeyCode.Mouse0) && gun)
            {
                gun.Fire();
            }
        }
    }

    [Rpc(SendTo.Server)]
    private void UpdateVelocityRPC(Vector2 data)
    {
        rb.velocity = data;
    }
    
    [Rpc(SendTo.Server)]
    private void UpdateRotationRPC(float data)
    {
        rb.rotation = data;
    }
}
