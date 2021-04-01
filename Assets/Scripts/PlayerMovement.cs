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
    public GameObject regenEffect;
    bool moving;

    private float Speed;
    private GameObject eff;
    private bool CanDash;
    private bool canRegen;
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator animator;
    private float posMulti;

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }

    IEnumerator Dash()
    {
        gameObject.transform.GetComponent<CharacterStats>().mana -= DashManaCost;
        canMove = false;
        posMulti = 10f;
        yield return new WaitForSeconds(.01f);
        posMulti = 1f;
        yield return new WaitForSeconds(.5f);
        CanDash = true;
        yield break;
    }

    IEnumerator ManaRegen()
    {

        canRegen = false;
        gameObject.transform.GetComponent<CharacterStats>().mana += gameObject.transform.GetComponent<CharacterStats>().maxMana / 50;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        if (!eff)
        {
            eff = Instantiate(regenEffect, transform.position, transform.rotation);
            eff.transform.SetParent(transform);
        }
        canMove = false;
        yield return new WaitForSeconds(.05f);
        canRegen = true;
        yield break;

    }

    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>(); // locate component of Rigidbody
        posMulti = 1.0f;
        Speed = WalkSpeed;
        moving = false;
        canMove = true;
        CanDash = true;
        canRegen = true;
    }

    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal"); // set user input to x 
        change.y = Input.GetAxisRaw("Vertical"); // set user input to y


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


        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (canRegen)
            {
                StartCoroutine(ManaRegen());
            }
        }
        else
        {
            Wait(.1f);                                                      // GOVNOCODE: senpai fix me later please :3
            canMove = true;                                                 // GOVNOCODE: senpai fix me later please :3
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            if (eff)
                GameObject.Destroy(eff);
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

        if (Input.GetKey(KeyCode.Space) && CanDash)
        {
            CanDash = false;
            StartCoroutine(Dash());
        }

        myRigidBody.MovePosition
        (
            transform.position + (change.normalized * Speed * SpeedMulti * posMulti) * Time.deltaTime
        );

    }

}
