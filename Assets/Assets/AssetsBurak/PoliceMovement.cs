using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PoliceMovement : MonoBehaviour
{
    public AIPath aiPath;
    private Animator animator;
    private bool isRunning;
    private Vector3 previousPosition;

    private void Start()
    {
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
            policeHurt();
        }
    }

    private void policePunch()
    {
        animator.SetTrigger("isPunching");


    }

    private void policeHurt()
    {
        animator.SetTrigger("isHurt");


    }


    private void FixedUpdate()
    {
        policeIsRunning();

        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(7f, transform.localScale.y, transform.localScale.z);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-7f, transform.localScale.y, transform.localScale.z);
        }
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