using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovment : MonoBehaviour
{public CharacterController controller;
    public float speed = 12f;
    Vector3 Velocity;
    public float gravity = -9.81f;
    public Transform groundcheck;
    public float grounddistance = 0.4f;
    public LayerMask groundmask;
    bool isgrounded;
    public float jumpheight = 3f;
    void Start()
    {

    }
    void Update()
    {
        isgrounded = Physics.CheckSphere(groundcheck.position, grounddistance,groundmask); 
        if (isgrounded && Velocity.y < 0)
        {
            Velocity.y = -2;
        }
        float x=Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move= transform.right *x+ transform.forward*z;
        controller.Move(move*speed*Time.deltaTime);
        if (isgrounded && Input.GetButton("Jump")) {
            Velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }
        Velocity.y += gravity * Time.deltaTime;
        controller.Move(Velocity * Time.deltaTime) ;
    }
}
