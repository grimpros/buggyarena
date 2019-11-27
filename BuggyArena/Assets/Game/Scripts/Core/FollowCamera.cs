using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraType
{
    Vertical, Horizontal, FreeCam
}

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float camSpeed = 1f;
    [SerializeField] CameraType cameraType;
    [SerializeField] Vector3 offset;

    void FixedUpdate()
    {
        if (target != null)
        {
            FollowTarget();
        }
    }

    void FollowTarget()
    {
        Vector3 toPos = target.position + offset;
        switch (cameraType)
        {
                case CameraType.Vertical:
                    toPos.x = 0f;
                    break;
                
                case CameraType.Horizontal:
                    toPos.z = 0f;
                    break;
        }

        Vector3 smoothedPos = Vector3.Lerp(transform.position, toPos, camSpeed);
        transform.position = smoothedPos;
    }
}
