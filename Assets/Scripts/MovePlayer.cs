using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField]
    private float speed;
    private float gravity = 9.81f;
    [SerializeField]
    private float jumpHeight;
    Vector3 velocity;
    [SerializeField]
    private Transform groundCheck;
    private float groundDistance = 0.4f;
    [SerializeField]
    private LayerMask groundMask;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        velocity.x = x * speed;
        velocity.z = z * speed;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y -= gravity * Time.deltaTime;
        }
        velocity = transform.TransformDirection(velocity);
        controller.Move(velocity * Time.deltaTime);
    }
}
