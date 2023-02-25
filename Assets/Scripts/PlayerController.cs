using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torgueAmount = 400f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float slowSpeed = 12f;
    [SerializeField] float stopSpeed = 5f;

    Rigidbody2D rd;
    SurfaceEffector2D surfaceEffector2D;

    bool canMove = true;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();  //pake find karena component surface hanya ada 1 di scene ini
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) //sama dengan canMove == true
        {
            RotationPlayer();
            BoostPlayer();
        }

    }

    public void StopMove()
    {
        surfaceEffector2D.speed = stopSpeed;
        canMove = false;
    }

    void BoostPlayer()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            surfaceEffector2D.speed = slowSpeed;
        }
        else //bikin else ketika tidak di pencet
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void RotationPlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rd.AddTorque(torgueAmount * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) //else if = mencegah konflik jika player pencet tombol kiri & kanan secara bersamaan
        {
            rd.AddTorque(-torgueAmount * Time.deltaTime);
        }
    }

}
