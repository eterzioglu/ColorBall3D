using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Bounds : MonoBehaviour
{
    public Transform right;
    public Transform left;
    public Transform back;
    public Transform forward;

    private void FixedUpdate()
    {
        LimitPositions();
    }

    private void LimitPositions()
    {
        Vector3 limitedPosition = transform.position;
        limitedPosition.x = Mathf.Clamp(limitedPosition.x, left.position.x, right.position.x);
        limitedPosition.z = Mathf.Clamp(limitedPosition.z, back.position.z, forward.position.z);
        transform.position = limitedPosition;
    }
}
