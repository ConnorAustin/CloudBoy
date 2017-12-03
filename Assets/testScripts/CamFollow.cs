using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public float orbitDistance;
    public float desiredHeight;
    public float heightCorrectionSpeed;

    float height;

    public Transform follow;

    float angle;
    float desiredAngle;
    bool updatingAngle;

    void Start()
    {

    }

    public void UpdateDirection(float desiredAngle)
    {
        updatingAngle = true;
        this.desiredAngle = desiredAngle;
    }

    void UpdateAngle()
    {
        if(updatingAngle)
        {
            angle = Mathf.LerpAngle(angle, desiredAngle, 0.04f);
            if(Mathf.Abs(angle - desiredAngle) < 1.0f)
            {
                angle = desiredAngle;
                updatingAngle = false;
            }
        }
    }

    void Update()
    {
        // Height correction
        float curHeight = transform.position.y - follow.position.y;
        float oldHeight = height;
        float heightDiff = Mathf.Abs(curHeight - desiredHeight);
        if (heightDiff > 0.5f)
        {
            if (curHeight > desiredHeight)
            {
                height -= heightDiff * heightDiff * heightCorrectionSpeed * Time.deltaTime;
            }
            if (curHeight < desiredHeight)
            {
                height += heightDiff * heightDiff * heightCorrectionSpeed * Time.deltaTime;
            }
        }

        Vector3 orbitPos = Vector3.forward * Mathf.Sin(Mathf.Deg2Rad * angle) + Vector3.right * Mathf.Cos(Mathf.Deg2Rad * angle);
        orbitPos *= orbitDistance;

        Vector3 basePos = follow.position;
        basePos.y = transform.position.y - oldHeight;

        transform.position = basePos + Vector3.up * height + orbitPos;

        transform.LookAt(follow);

        UpdateAngle();
    }
}
