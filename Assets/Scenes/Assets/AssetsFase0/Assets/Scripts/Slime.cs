using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    public Transform target;
    private Rigidbody2D myRigidbody;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;


    private GameObject player;
    private bool m_FacingRight = false;
    private bool walk = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        player = GameObject.FindWithTag("Player");

        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentState = EnemyState.idle;

        myRigidbody.gravityScale = 0f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
        
    }

    void CheckDistance()
    {
        if (Vector2.Distance(target.position, transform.position) <= chaseRadius
            && Vector2.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk)
            {
                // Calculate movement vector in horizontal direction only
                Vector2 direction = new Vector2(target.position.x - transform.position.x, 0).normalized;
                // Convert the 2D direction to a 3D direction with zero Z component
                Vector3 movement = Vector3.ProjectOnPlane(direction, Vector3.up);
                // Calculate the target position using the 3D movement vector

                // Impede o movimento em Y, definindo a velocidade do Rigidbody2D apenas no eixo X.
                Vector2 velocity = new Vector2(movement.x * moveSpeed, myRigidbody.velocity.y);
                myRigidbody.velocity = velocity;

                Vector3 targetPosition = transform.position + movement * moveSpeed * Time.deltaTime;
                // Move the enemy using Rigidbody
                myRigidbody.MovePosition(targetPosition);

                //verifica se o movimento é positivo ou negativo
                if (target.position.x > transform.position.x && !m_FacingRight)
                {
                    Flip();
                }
                else if (target.position.x < transform.position.x && m_FacingRight)
                {
                    Flip();
                }

                if (!walk)
                {
                    anim.SetBool("IsWalking", true);
                    walk = true;
                }
            }
        }  
        
        else
        {

            if (walk)
            {
                anim.SetBool("IsWalking", false);
                walk = false;
                myRigidbody.velocity = new Vector2(0,0);
            }
        }
    }

    private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
