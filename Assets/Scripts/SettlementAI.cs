using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettlementAI : MonoBehaviour
{

    public float WalkSpeed;
    public float SpeedMulti;
    public bool canMove;
    bool moving;

    private float Speed;
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator animator;

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }

   
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>(); // locate component of Rigidbody
        Speed = WalkSpeed;
        moving = false;
        canMove = true;
    }

    void Update()
    {
        change = Vector3.zero;

        Debug.Log(Random.Range(0,2));

        if(Random.Range(0,5) == 1)
        {
            if(Random.Range(0,2) == 1)
            change.x = Random.Range(-2,2); // set user input to x 

            if(Random.Range(0,2) == 1)
            change.y = Random.Range(-2,2); // set user input to y

            Debug.Log("Settlement AI");
        }

        if (change != Vector3.zero) // if change value more not 0 then call move function, for optimization
        {
            moving = true;
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);

            UpdateAnimation();


        }
        else
        {
            animator.SetBool("moving", false);
            moving = false;
        }

    }

    private void FixedUpdate()
    {

        if (moving && canMove)
            MoveCharacter();

    }

    void UpdateAnimation()
    {

    }

    void MoveCharacter()
    {

        myRigidBody.MovePosition
        (
            transform.position + (change.normalized * Speed * SpeedMulti) * Time.deltaTime
        );

    }

}
