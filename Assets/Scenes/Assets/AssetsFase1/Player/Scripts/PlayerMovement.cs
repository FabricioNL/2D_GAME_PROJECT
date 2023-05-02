using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    idle,
    walk,
    attack,
    interact,
    stagger
}

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    //bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if ((Input.GetKeyDown(KeyCode.Space)))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        // Move our character (crouch always false)
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    //private IEnumerator KnockCo(float knockTime)
    //{
    //    if (myRigidbody != null)
    //    {
    //        yield return new WaitForSeconds(knockTime);
    //       //myRigidbody.velocity = Vector2.zero;
    //        //currentState = PlayerState.idle;
    //        //myRigidbody.velocity = Vector2.zero;
    //    }
    //}
//
    //public void Knock(float knockTime){
    //    StartCoroutine(KnockCo(knockTime));
    //}
}
