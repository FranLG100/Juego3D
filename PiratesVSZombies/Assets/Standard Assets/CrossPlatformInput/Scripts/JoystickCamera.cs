using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class JoystickCamera : MonoBehaviour
{

    public float moveSpeed = 10;
    private float hMovement = 0f;
    private float vMovement = 0f;
    private void Update()
    {
        // movement = Input.GetAxisRaw("Horizontal");
        hMovement = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        vMovement = CrossPlatformInputManager.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, hMovement * Time.fixedDeltaTime * -moveSpeed);
        transform.RotateAround(Vector3.zero, Vector3.right, vMovement * Time.fixedDeltaTime * -moveSpeed);
    }

}
