using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f;
    public float rotSpeed = 1.0f;
    public GameObject hull;
    public GameObject machineGun;
    public GameObject radar;
    public GameObject reactor;

    private Vector2 moveDirection;
    private GameObject sprite;
    private Animator anim;
    private float actualSpeed = 0;
    private CharacterController controller;
    private int state = 0; // 0 for walking, 1 for turret, 2 for repairing hull, 3 for radar, 4 for reactor....
    private BoxCollider hullCollider;
    private SphereCollider machineGunCollider;
    private BoxCollider radarCollider;
    private BoxCollider reactorCollider;

    void Start()
    {
        sprite = this.gameObject.transform.GetChild(0).gameObject;
        anim = sprite.GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        hullCollider = hull.GetComponent<BoxCollider>();
        machineGunCollider = machineGun.GetComponent<SphereCollider>();
        radarCollider = radar.GetComponent<BoxCollider>();
        reactorCollider = reactor.GetComponent<BoxCollider>();
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
        if (Input.GetButtonDown("Fire2")) {
            if (state == 0) {
                if (hullCollider.bounds.Contains(transform.position + sprite.transform.TransformDirection(Vector3.right) * 0.7f))
                {
                    state = 2;
                    anim.SetBool("is_moving", false);
                    anim.SetBool("is_repairing", true);
                }
                else if (machineGunCollider.bounds.Contains(transform.position + sprite.transform.TransformDirection(Vector3.right) * 0.7f))
                {
                    state = 1;
                    anim.SetBool("is_moving", false);
                    anim.SetBool("is_fireing", true);
                    machineGun.GetComponent<MachineGunScript>().control = true;
                }
                else if (radarCollider.bounds.Contains(transform.position + sprite.transform.TransformDirection(Vector3.right) * 0.7f))
                {
                    state = 3;
                    anim.SetBool("is_moving", false);
                    anim.SetBool("is_repairing", true);
                }
                else if (reactorCollider.bounds.Contains(transform.position + sprite.transform.TransformDirection(Vector3.right) * 0.7f))
                {
                    state = 4;
                    anim.SetBool("is_moving", false);
                    anim.SetBool("is_repairing", true);
                }
            } else if (state != 0) {
                machineGun.GetComponent<MachineGunScript>().control = false;
                anim.SetBool("is_repairing", false);
                anim.SetBool("is_fireing", false);
                state = 0;
            }
        }
    }
}
