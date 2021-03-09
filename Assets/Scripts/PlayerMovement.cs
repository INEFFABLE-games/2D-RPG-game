using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float WalkSpeed;
    public float RunSpeed;

    private float Speed;
    public float SpeedMulti;
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>(); // locate component of Rigidbody
    }

    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal"); // set user input to x 
        change.y = Input.GetAxisRaw("Vertical"); // set user input to y

        if (change != Vector3.zero) // if change value more not 0 zen call move function, for optimization
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Speed = RunSpeed;
            }
            else
            {
                Speed = WalkSpeed;
            }

            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
            UpdateAnimation();

        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void UpdateAnimation()
    {

    }

    void MoveCharacter()
    {
        myRigidBody.MovePosition
        (
            transform.position + change * Speed * SpeedMulti * Time.deltaTime
        );
    }

}
