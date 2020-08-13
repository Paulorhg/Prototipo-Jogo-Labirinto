using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    private Animator anim;

    public float speed = 6f;


    //Gravidade
    public float gravity = -9.81f;
    private Vector3 _velocity;


    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (controller.isGrounded && _velocity.y < 0)
            _velocity.y = 0f;

        _velocity.y += gravity * Time.deltaTime;
        controller.Move(_velocity * Time.deltaTime);

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if(direction.magnitude >= 0.1f && !anim.GetBool("attack") && !anim.GetBool("defend") && !anim.GetBool("dead") && !anim.GetBool("gethit"))
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            anim.SetBool("walk", true);
        }
        else
            anim.SetBool("walk", false);

    }

    public void Hitted()
    {
        controller.Move(Vector3.back.normalized * speed * Time.deltaTime);
    }
}
