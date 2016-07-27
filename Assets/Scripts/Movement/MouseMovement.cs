﻿using UnityEngine;
using System.Collections;
using System;

[CreateAssetMenu(fileName = "MouseMovement", menuName = "ScriptableObjects/MouseMovement")]
public class MouseMovement : IMovement
{

    public override Vector3 getDirection(Transform shipPos)
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 movementVector = mousePos - shipPos.position;
        if (movementVector.magnitude < 0.2f)
            movementVector = Vector3.zero;
        movementVector.z = 0;
        return movementVector.normalized;
    }
}
