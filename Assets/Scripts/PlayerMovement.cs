using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float WalkSpeed;
    public float RunSpeed;
    public float DashManaCost;
    public float SpeedMulti;
    public bool canMove;
    bool moving;

    private float Speed;
    private bool CanDash;
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator animator;
    private float posMulti;

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>(); // locate component of Rigidbody
        posMulti = 1.0f;
        Speed = WalkSpeed;
        moving = false;
        canMove = true;
    }

    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal"); // set user input to x 
        change.y = Input.GetAxisRaw("Vertical"); // set user input to y

        if (change != Vector3.zero) // if change value more not 0 zen call move function, for optimization
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

        if(Input.GetKey(KeyCode.LeftShift))
        ManaRegen();
        else
        {
            Wait(.5f);
            canMove = true;
        }
    }

    private void FixedUpdate() {
        
            if(moving && canMove)
            MoveCharacter();

    }

    void UpdateAnimation()
    {

    }

    void MoveCharacter()
    {

        if(Input.GetKeyDown(KeyCode.Space) && CanDash)
        {
            gameObject.transform.GetComponent<CharacterStats>().mana -= DashManaCost;
            posMulti = 15.0f;
            CanDash = false;
        }

        myRigidBody.MovePosition
        (
            transform.position + change.normalized * Speed * SpeedMulti * posMulti * Time.deltaTime
        );

        if(!CanDash)
        {
            posMulti = 1.0f;
            Wait(1.0f);
            CanDash = true;
        }
    }

    void ManaRegen()
    {
        Wait(.2f);
        gameObject.transform.GetComponent<CharacterStats>().mana += gameObject.transform.GetComponent<CharacterStats>().maxMana/100;
        canMove = false;
    }

}
