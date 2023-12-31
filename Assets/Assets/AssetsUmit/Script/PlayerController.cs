using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    public float speed; //Controls velocity multiplier
    private Rigidbody2D playerRB;
    private Animator anim;
    private bool faceRight = true;
    public float jumpSpeed, jumpFrequency, nextJumpTime;
    public bool isGrounded;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    private void Start()
    {
        playerRB = player.GetComponent<Rigidbody2D>();
        anim = player.GetComponent<Animator>();
    }

    private void Update()
    {
        HorizontalMove();
        OnGroundCheck();
        
        if(playerRB.velocity.x < 0 && faceRight) FacialMovement();
        else if(playerRB.velocity.x>0 && !faceRight) FacialMovement();

        if (Input.GetAxis("Vertical") > 0 && isGrounded && nextJumpTime < Time.timeSinceLevelLoad)
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetTrigger("Roll");
        }
        
    }

    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRB.velocity.y);
        anim.SetFloat("playerSpeed",Mathf.Abs(playerRB.velocity.x));
    }

    void Jump()
    {
        playerRB.AddForce(new Vector2(0, jumpSpeed));
    }

    void FacialMovement()
    {
        faceRight = !faceRight;
        var transformLocalScale = transform.localScale;
        transformLocalScale.x *= -1;
        transform.localScale = transformLocalScale;

    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position,groundCheckRadius,groundCheckLayer); 
        anim.SetBool("IsGroundedAnim",isGrounded);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish") && Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene(3);
        }
    }
}
