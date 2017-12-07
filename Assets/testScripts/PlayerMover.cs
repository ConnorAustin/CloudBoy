using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    // The point where he is considered on the ground
    public SphereCollider groundSphere;

    // Extra gravity
    public float gravity;

    // Running speed of the player
    public float speed;

    // Max veloicty for running
    public float maxRunningVelocity;

    // Max velocity for up and down
    public float maxYVelocity;

    // Stopping speed
    public float slipperiness;

    // Jumping force
    public float jumpPower;

    // Held jumping
    public float jumpDecay;
    public float jumpSustain;
    bool holdingJump;

    // If the player is grounded or not
    bool grounded;
    bool canJump = true;

    float timeOffGround;
    float curJumpSustain;

    Rigidbody rigidBody;

    // Move vector for next update
    Vector3 move;

    // Position to orient mover
    [HideInInspector]
    public Vector3 lookAt = Vector3.forward;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public bool IsGrounded()
    {
        return grounded;
    }

    void UpdateGrounded()
    {
        bool oldGrounded = grounded;
        grounded = Physics.CheckSphere(groundSphere.transform.position, groundSphere.radius, LayerMask.GetMask("Ground"));

        // We landed
        if(!oldGrounded && grounded)
        {
            canJump = true;
            holdingJump = false;
            SendMessage("MoverLanded", rigidBody.velocity.y);
        }
    }

    // Jumps the mover. Returns true if successful
    public bool Jump()
    {
        if (canJump && timeOffGround < 0.2f)
        {
            canJump = false;
            holdingJump = true;
            grounded = false;
            transform.position += Vector3.up * 0.5f;
            curJumpSustain = jumpSustain;
            rigidBody.AddForce(Vector3.up * jumpPower);
            return true;
        }
        return false;
    }

    public void JumpHeld(bool jumpHeld)
    {
        holdingJump = jumpHeld;
    }

    public void Move(Vector3 move)
    {
        this.move = move.normalized;
    }

    void MoveGrounded()
    {
        if (move.magnitude > 0.3f)
        {
            rigidBody.AddForce(move * speed);
            move.y = 0;
            lookAt = Vector3.Lerp(lookAt, move, 0.2f);
        }
        else
        {
            DecayRunSpeed();
        }
    }

    void ClampVelocity()
    {
        // Clamp velocity
        var vel = rigidBody.velocity;
        vel.y = 0;
        float velLen = vel.magnitude;
        velLen = Mathf.Min(maxRunningVelocity, velLen);
        vel = vel.normalized * velLen;
        vel.y = Mathf.Clamp(rigidBody.velocity.y, -maxYVelocity, maxYVelocity);
        rigidBody.velocity = vel;
    }

    void DecayRunSpeed()
    {
        var vel = rigidBody.velocity;
        vel.x *= slipperiness;
        vel.z *= slipperiness;
        rigidBody.velocity = vel;
    }

    void AddGravity()
    {
        if (!grounded)
        {
            rigidBody.AddForce(Vector3.down * gravity);
        }
    }

    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("grounded: " + grounded);
            Debug.Log("timeOff: " + timeOffGround);
            Debug.Log("canJump: " + canJump);
        }
        UpdateGrounded();
        AddGravity();
        MoveGrounded();
        ClampVelocity();
        if(holdingJump && !grounded)
        {
            rigidBody.AddForce(Vector3.up * curJumpSustain);
            curJumpSustain = Mathf.Max(0, curJumpSustain - jumpDecay * Time.deltaTime);
        }
        if (!grounded)
        {
            timeOffGround += Time.deltaTime;
        }
        else
        {
            timeOffGround = 0;
        }
        transform.LookAt(transform.position + lookAt);
    }
}
