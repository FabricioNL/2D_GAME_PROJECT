using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public float speed;
    public float randomX;
    public float randomY;
    public float minWaitTime;
    public float maxWaitTime;
    private Vector2 currentRandomPos = Vector2.zero;
    public Animator anim;
    private bool m_FacingRight = true;
    private bool walk = false;

    void Start()
    {
        PickPosition();
    }

    void PickPosition()
    {
        currentRandomPos = new Vector2(Random.Range(-randomX, randomX), Random.Range(-randomY, randomY));
        StartCoroutine(MoveToRandomPos());
    }

    IEnumerator MoveToRandomPos()
    {
        float i = 0.0f;
        float rate = 1.0f / speed;
        Vector2 currentPos = transform.position;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            float newXPos = Mathf.Lerp(currentPos.x, currentRandomPos.x, i);

            //verifica se o movimento é positivo ou negativo
            if (currentRandomPos.x > currentPos.x && !m_FacingRight)
            {
                Flip();
            }
            else if (currentRandomPos.x < currentPos.x && m_FacingRight)
            {
                Flip();
            }

            if (!walk)
            {
                anim.SetBool("IsWalking", true);
                walk = true;
            }

            transform.position = new Vector2(newXPos, currentPos.y);
            yield return null;
        }
        
        float randomFloat = Random.Range(0.0f, 1.0f); // Create 50% chance to wait
        if (randomFloat < 0.5f)
        {
            StartCoroutine(WaitForSomeTime());
        }
        else
        {
            PickPosition();
        }
    }


    IEnumerator WaitForSomeTime()
    {   
        if (walk)
        {
            anim.SetBool("IsWalking", false);
            walk = false;
        }
        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        PickPosition();
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











