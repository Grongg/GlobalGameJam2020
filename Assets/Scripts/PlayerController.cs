using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f;
    public float rotSpeed = 1.0f;
    public GameObject hull;
    public GameObject machineGun;
    public GameObject up;
    public GameObject reactor;
    public GameObject machineGunColl;
    public HealthBar HealthBar;
    public HealthBar RepairBar;
    public UpgradeBar upBar;
    public ScoreHandler score;
    public Shooting shoot;

    private Vector2 moveDirection;
    private GameObject sprite;
    private Animator anim;
    private float actualSpeed = 0;
    private CharacterController controller;
    private int state = 0; // 0 for walking, 1 for turret, 2 for repairing hull, 3 for radar, 4 for reactor....
    private BoxCollider hullCollider;
    private BoxCollider machineGunCollider;
    private BoxCollider upCollider;
    private BoxCollider reactorCollider;
    private float timer = 0f;

    void Start()
    {
        sprite = this.gameObject.transform.GetChild(0).gameObject;
        anim = sprite.GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        hullCollider = hull.GetComponent<BoxCollider>();
        reactorCollider = reactor.GetComponent<BoxCollider>();
        machineGunCollider = machineGunColl.GetComponent<BoxCollider>();
        upCollider = up.GetComponent<BoxCollider>();
        if (DataCollector.Score == 0)
            upBar.setInitSize();
    }

    void repairShield()
    {
        if (HealthBar.currentHealth >= 100)
            return;
        HealthBar.currentHealth += 3f * Time.deltaTime;
        HealthBar.displayHealth();
        HealthBar.setSize(HealthBar.currentHealth * 0.01f);
        if (HealthBar.currentHealth >= (HealthBar.startingHealth * 0.25))
                HealthBar.setColor(Color.green);
    }

    void repairEngine()
    {
        RepairBar.currentHealth += 2f * Time.deltaTime;
        RepairBar.displayHealth();
        RepairBar.setSize(RepairBar.currentHealth * 0.01f);
        if (RepairBar.currentHealth >= 100f)
        {
            DataCollector.State = true;
            SceneManager.LoadScene("EndGameScreen", LoadSceneMode.Single);
        }
    }
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
            actualSpeed = speed / (float)Math.Sqrt(2);
        else
            actualSpeed = speed;
        if (state == 0) {
            moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            controller.Move(moveDirection * actualSpeed * Time.deltaTime);
            if (moveDirection.x != 0 || moveDirection.y != 0) {
                anim.SetBool("is_moving", true);
                sprite.transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, moveDirection));
            } else
                anim.SetBool("is_moving", false);
        }
        else if (state == 2)
            repairShield();
        else if (state == 4)
            repairEngine();
        if (Input.GetButtonDown("Fire2")) {
            if (state == 0) {
                if (hullCollider.bounds.Contains(transform.position + sprite.transform.TransformDirection(Vector3.right) * 0.7f))
                {
                    state = 2;
                    anim.SetBool("is_moving", false);
                    anim.SetBool("is_repairing", true);
                    HealthBar.shieldRepair.Play(0);
                }
                else if (machineGunCollider.bounds.Contains(transform.position + sprite.transform.TransformDirection(Vector3.right) * 0.7f))
                {
                    //Debug.Log("aoierhg");
                    state = 1;
                    anim.SetBool("is_moving", false);
                    anim.SetBool("is_fireing", true);
                    machineGun.GetComponent<MachineGunMovement>().control = true;
                    machineGun.GetComponent<Shooting>().can_fire = true;
                }
                else if (upCollider.bounds.Contains(transform.position + sprite.transform.TransformDirection(Vector3.right) * 0.7f))
                {
                    Debug.Log(DataCollector.Score);
                    Debug.Log(upBar.getCurrentUpgrade());
                    if (score.getScore() >= 400 && upBar.getCurrentUpgrade() == 1)
                    {
                        score.setScore(score.getScore() - 400);
                        state = 5;
                        anim.SetBool("is_moving", false);
                        anim.SetBool("is_repairing", true);
                        shoot.firerate = 0.3f;
                    }
                    else if (score.getScore() >= 1000 && upBar.getCurrentUpgrade() == 2)
                    {
                        score.setScore(score.getScore() - 1000);
                        state = 5;
                        anim.SetBool("is_moving", false);
                        anim.SetBool("is_repairing", true);
                        shoot.firerate = 0.2f;
                    }
                    else if (score.getScore() >= 2000 && upBar.getCurrentUpgrade() == 3)
                    {
                        score.setScore(score.getScore() - 2000);
                        state = 5;
                        anim.SetBool("is_moving", false);
                        anim.SetBool("is_repairing", true);
                        shoot.firerate = 0.15f;
                    }
                    else if (score.getScore() >= 4500 && upBar.getCurrentUpgrade() == 4)
                    {
                        score.setScore(score.getScore() - 4500);
                        state = 5;
                        anim.SetBool("is_moving", false);
                        anim.SetBool("is_repairing", true);
                        shoot.firerate = 0.1f;
                    }
                }
                else if (reactorCollider.bounds.Contains(transform.position + sprite.transform.TransformDirection(Vector3.right) * 0.7f))
                {
                    state = 4;
                    anim.SetBool("is_moving", false);
                    anim.SetBool("is_repairing", true);
                    RepairBar.shieldRepair.Play(0);
                }
            } else if (state == 1)
            {
                machineGun.GetComponent<MachineGunMovement>().control = false;
                machineGun.GetComponent<Shooting>().can_fire = false;
                anim.SetBool("is_fireing", false);
                state = 0;
            }
            else if (state != 0 && state != 5) {
                anim.SetBool("is_repairing", false);
                HealthBar.shieldRepair.Stop();
                RepairBar.shieldRepair.Stop();
                state = 0;
            }
        }
        if (state == 5)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            if (timer >= 3)
            {
                state = 0;
                anim.SetBool("is_repairing", false);
                timer = 0;
                upBar.upgrade();
            }
        }
    }
}
