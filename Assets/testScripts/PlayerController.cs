﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip landSound;
    public AudioClip jumpSound;
    public Transform squirtZone;
    public GameObject squirt;
    public AudioClip squirtSound;

    CloudBoiAnim anim;
    GroundMover mover;
    AudioSource audioSource;
    float idleTime;
    float walkAnimSpeed;
    float squirtSoundTime;

    void Start()
    {
        mover = GetComponent<GroundMover>();
        audioSource = GetComponent<AudioSource>();
        anim = transform.Find("CloudBoi").GetComponent<CloudBoiAnim>();
    }

    // Sent from mover
    void MoverLanded(float velocity)
    {
        float landVolume = Mathf.Min(1.0f, Mathf.Abs(velocity) / 50.0f);
        audioSource.PlayOneShot(landSound, landVolume);
        anim.Land();
    }

    void UpdateCamLook()
    {
        float lookAngle = 180.0f + Vector3.SignedAngle(Vector3.right, new Vector3(mover.lookAt.x, 0, -mover.lookAt.z), Vector3.up);
        Camera.main.GetComponent<CamFollow>().UpdateDirection(lookAngle);
    }

    void Squirt()
    {

        var s = GameObject.Instantiate(squirt);
        s.transform.position = squirtZone.position;
        var force = mover.lookAt * 500 + Vector3.up * 200;
        s.GetComponent<Rigidbody>().AddForce(force);
        GetComponent<Player>().AddWater(-0.1f);

        squirtSoundTime -= 1.0f;
        if (squirtSoundTime < 0)
        {
            audioSource.PlayOneShot(squirtSound, 0.3f);
            squirtSoundTime = 5.0f;
        }
            
    }

    void FixedUpdate()
    {
        bool jump = Input.GetKeyDown(KeyCode.X);
        if (jump)
        {
            if (mover.IsGrounded())
            {
                if (mover.Jump())
                {
                    anim.Jump();
                    audioSource.PlayOneShot(jumpSound);
                }
            }
            else
            {
                anim.Hover();
                mover.HoverMode(true);
            }
        }
        bool jumpHeld = Input.GetKey(KeyCode.X);
        if (!jumpHeld)
        {
            anim.NoHover();
        }
        mover.JumpHeld(jumpHeld);

        float right = Input.GetAxis("Horizontal");
        float forward = Input.GetAxis("Vertical");

        var camTrans = Camera.main.transform;
        Vector3 move = camTrans.TransformVector(Vector3.right * right);
        Vector3 camForward = camTrans.TransformVector(Vector3.forward);
        camForward.y = 0;
        camForward.Normalize();
        move += camForward * forward;
        mover.Move(move);
        if (move.magnitude < 0.1f)
        {
            anim.setWalking(false);
            idleTime += Time.deltaTime;
            walkAnimSpeed = 0;
            if (idleTime > 0.6f)
            {
                UpdateCamLook();
            }
        }
        else
        {
            anim.setWalking(true);
            idleTime = 0;
            walkAnimSpeed += move.magnitude;
            walkAnimSpeed = Mathf.Min(20, walkAnimSpeed);

            anim.stride = walkAnimSpeed;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            Squirt();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            UpdateCamLook();
        }
    }
}
