using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5;
    private Vector2 moveDir;
    private Vector2 mousePos;
    private Gun gun;
    void Start()
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
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(moveX, moveY).normalized;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Mouse0) && gun)
        {
            gun.Fire();
        }
    }

    private void FixedUpdate()
    {
        if (rb)
        {
            rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);
        }

        Vector2 aimDir = mousePos - rb.position;
        float aimAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
}
