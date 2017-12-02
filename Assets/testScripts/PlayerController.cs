using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip landSound;
    public AudioClip jumpSound;

    GroundMover mover;
    AudioSource audioSource;

    void Start()
    {
        mover = GetComponent<GroundMover>();
        audioSource = GetComponent<AudioSource>();
    }

    // Sent from mover
    void MoverLanded(float velocity)
    {
        float landVolume = Mathf.Min(1.0f, Mathf.Abs(velocity) / 50.0f);
        audioSource.PlayOneShot(landSound, landVolume);
    }

    void FixedUpdate()
    {
        bool jump = Input.GetKeyDown(KeyCode.Space);
        if (jump)
        {
            if (mover.Jump())
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }

        float right = Input.GetAxis("Horizontal");
        float forward = Input.GetAxis("Vertical");

        var camTrans = Camera.main.transform;
        Vector3 move = camTrans.TransformVector(Vector3.right * right);

        Vector3 camForward = camTrans.TransformVector(Vector3.forward);
        camForward.y = 0;
        camForward.Normalize();
        move += camForward * forward;
        mover.Move(move);
    }
}
