using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class PoliceMovement : MonoBehaviour
{
    // public AIPath aiPath;
    private Animator animator;
    private bool isRunning;
    private Vector3 previousPosition;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        previousPosition = transform.position;
    }

    private void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerTag"))
        {
            policePunch();
        }

        if (collision.gameObject.CompareTag("HurtItemTag"))
        {
            policeHurt(collision.gameObject);
        }
    }

    private void policePunch()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("PlayerTag");
        animator.SetTrigger("isPunching");

        if (playerObject != null)
        {
            BurakPlayerControl playerScript = playerObject.GetComponent<BurakPlayerControl>();

            if (playerScript != null)
            {
                playerScript.Die();
            }
        }

    }

    private void policeHurt(GameObject newObject)
    {
        Invoke("stopMove", 15f);
        animator.SetTrigger("isHurt");
        newObject.SetActive(false);

    }


    private void stopMove()
    {
        rb.velocity = new Vector2(0f, 0f);
    }

    private void FixedUpdate()
    {
        policeIsRunning();

       /* if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(7f, transform.localScale.y, transform.localScale.z);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-7f, transform.localScale.y, transform.localScale.z);
        }*/
    }


    private void policeIsRunning()
    {
        if ((Mathf.Abs(previousPosition.x - transform.position.x) > 0))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        previousPosition = transform.position;

        if (isRunning)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}