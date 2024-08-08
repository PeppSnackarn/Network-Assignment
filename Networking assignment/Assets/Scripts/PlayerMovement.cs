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
    private NetworkVariable<Vector2> moveDir = new NetworkVariable<Vector2>(writePerm: NetworkVariableWritePermission.Owner);
    private NetworkVariable<Vector2> mousePos = new NetworkVariable<Vector2>(writePerm: NetworkVariableWritePermission.Owner);
    private Gun gun;
    void Start()
    {
        if (IsLocalPlayer)
        {
            rb = GetComponent<Rigidbody2D>();
            gun = GetComponentInChildren<Gun>();

            if (rb == false)
            {
                Debug.LogError("Player did not have a rigidbody.");
            }

            if (gun == false)
            {
                Debug.LogError("Player did not have a gun.");
            }   
            Debug.Log("Hello");
        }
        
    }

    void Update()
    {
        if (IsLocalPlayer)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");
            moveDir = new NetworkVariable<Vector2>( new Vector2(moveX, moveY).normalized * speed);
            mousePos.Value = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           // Debug.Log(OwnerClientId+ ":" +moveDir.Value.x);
           // Debug.Log(OwnerClientId+ ":" +moveDir.Value.y);

           /*
            if (Input.GetKeyDown(KeyCode.Mouse0) && gun)
            {
                gun.Fire();
            }  
            */ 
        }
    }

    private void FixedUpdate()
    {
        if (rb)
        {
            rb.velocity = new Vector2(moveDir.Value.x, moveDir.Value.y);
        }
        if (IsLocalPlayer)
        {
            NetworkVariable<Vector2> aimDir = new NetworkVariable<Vector2>(mousePos.Value - rb.position);
            //Vector2 aimDir = mousePos.Value - rb.position;
            NetworkVariable<float> aimAngle = new NetworkVariable<float>(Mathf.Atan2(aimDir.Value.y, aimDir.Value.x) * Mathf.Rad2Deg - 90f);
            //float aimAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = aimAngle.Value; 
            //Debug.LogError(aimAngle.Value);
            Debug.LogError(rb.rotation);
        }
    }
}
