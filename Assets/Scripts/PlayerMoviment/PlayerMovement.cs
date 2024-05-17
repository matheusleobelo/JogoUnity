using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed, maxSpeed, drag;
    public float rotationSpeed;
    public Transform cam;
    public Rigidbody rb;

    bool left, forward, backward, right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        LimitVelocity();
        HandleDrag();
        
    }

    void HandleDrag()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.y) / (1+drag/100) + new Vector3(0, rb.velocity.y, 0);
    }

    void LimitVelocity()
    {
        Vector3 horizontalvelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (horizontalvelocity.magnitude > maxSpeed)
        {
            Vector3 limitedvelocity = horizontalvelocity.normalized * maxSpeed;
            rb.velocity = new Vector3(limitedvelocity.x, rb.velocity.y, limitedvelocity.z);
        }
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleRotation()
    {
        if ((new Vector2(rb.velocity.x, rb.velocity.z)).magnitude > .1f)
        {
            Vector3 horizontalDir = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            Quaternion rotation = Quaternion.LookRotation(horizontalDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed);
        }
    }

    void HandleMovement()
    {
        Quaternion dir = Quaternion.Euler(0f, cam.rotation.eulerAngles.y, 0f);
        if (left)
        {
            rb.AddForce(dir * Vector3.left * speed);
            left = false;
        }
        if (forward)
        {
            rb.AddForce(dir * Vector3.forward * speed);
            forward = false;
        }
        if (backward)
        {
            rb.AddForce(dir * Vector3.back * speed);
            backward = false;
        }
        if (right)
        {
            rb.AddForce(dir * Vector3.right * speed);
            right = false;
        }
    }

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            left = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            forward = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            backward = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            right = true;
        }
    }
}
