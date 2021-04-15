using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAI : MonoBehaviour
{

    public float SpeedMulti;
    public bool canMove;
    //bool moving;
    bool isWandering;

    [SerializeField]private float Speed;
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator animator;

    IEnumerator Wandering()
    {

        float waitTime = Random.Range(1f, 3f);
        float wanderTime = Random.Range(1f, 3f);

        canMove = false;
        isWandering = true;

            if (Random.Range(0, 2) == 1)
            {
                change.x = Random.Range(-2, 2); // set user input to x 
            }
            else
            {
                change.y = Random.Range(-2, 2); // set user input to y
            }


        yield return new WaitForSeconds(wanderTime);

        isWandering = false;
        change = Vector3.zero;

        yield return new WaitForSeconds(waitTime);

        canMove = true;


        yield break;

    }


    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>(); // locate component of Rigidbody
        //moving = false;
        canMove = true;
        SpeedMulti = 1f;
    }

    void Update()
    {

        if (!isWandering && canMove)
            StartCoroutine(Wandering());

        else if (isWandering)
        {
            myRigidBody.MovePosition
            (
                transform.position + (change.normalized * Speed * SpeedMulti) * Time.deltaTime
            );

        }
        
        if (change != Vector3.zero) // if change value more not 0 then call move function
        {

            //moving = true;
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);

        }
        else
        {
            animator.SetBool("moving", false);
            //moving = false;
        }

    }

    private void FixedUpdate()
    {

    }

}
