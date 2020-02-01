using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f;
    public float rotSpeed = 1.0f;
    public GameObject component;

    private Vector2 moveDirection;
    private GameObject sprite;
    private Animator anim;
    private float actualSpeed = 0;
    private CharacterController controller;
    private int state = 0; // 0 for wallking, 1 for turret, 2 for repairing ....

    void Start()
    {
        sprite = this.gameObject.transform.GetChild(0).gameObject;
        anim = sprite.GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
        {
            actualSpeed = speed / (float)Math.Sqrt(2);
        }
        else
        {
            actualSpeed = speed;
        }
        if (state == 0) {
            moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            controller.Move(moveDirection * actualSpeed * Time.deltaTime);
            if (moveDirection.x != 0 || moveDirection.y != 0) {
                anim.SetBool("is_moving", true);
                sprite.transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, moveDirection));
            } else {
                anim.SetBool("is_moving", false);
            }
        }
        if (Input.GetButton("Fire2") && state == 0) {
            /*if (transform.position + moveDirection)*/
        } else if (Input.GetButton("Fire2")) {
            state = 0;
        }
    }
}
