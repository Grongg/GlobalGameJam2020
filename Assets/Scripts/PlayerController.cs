using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f;
    public float rotSpeed = 1.0f;

    private Vector2 moveDirection;
    private GameObject sprite;
    private Animator anim;
    private float actualSpeed = 0;

    void Start()
    {
        sprite = this.gameObject.transform.GetChild(0).gameObject;
        anim = sprite.GetComponent<Animator>();
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
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.Translate(moveDirection * actualSpeed * Time.deltaTime);
        if (moveDirection.x != 0 || moveDirection.y != 0)
        {
            anim.SetBool("is_moving", true);
            sprite.transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, moveDirection));
        }
        else
        {
            anim.SetBool("is_moving", false);
        }
    }
}
