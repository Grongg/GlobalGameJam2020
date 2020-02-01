using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunScript : MonoBehaviour
{
    public bool control = false;

    private GameObject sprite;

    void Start()
    {
        sprite = this.gameObject.transform.GetChild(0).gameObject;
        Debug.Log(transform.position);
    }

    void Update()
    {
        if (control)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;

            mousePos.x = mousePos.x - transform.position.x * 40 - 465;
            mousePos.y = mousePos.y - transform.position.y * 40 - 195;
            Debug.Log(mousePos);
            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            sprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }
    }
}
