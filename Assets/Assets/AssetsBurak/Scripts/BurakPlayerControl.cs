using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;

public class BurakPlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject _gameWin;
    [SerializeField]
    private GameObject player;
    public float speed = 12f; //Controls velocity multiplier
    private Rigidbody2D playerRB;
    private Animator anim;
    private bool faceRight = true;
    public float jumpSpeed, jumpFrequency, nextJumpTime;
    public bool isGrounded;
    [SerializeField] private GameObject chatBalloon;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    private bool isDead = false;
    public float throwSpeed = 350f;
    private bool throwIt = false;
    public GameObject gameOverObject;
    private void Start()
    {
        playerRB = player.GetComponent<Rigidbody2D>();
        anim = player.GetComponent<Animator>();
        Invoke("ChatBaloon",4);
    }

    private void Update()
    {
        if (!isDead)
        {
            HorizontalMove();
            OnGroundCheck();

            if (playerRB.velocity.x < 0 && faceRight) FacialMovement();
            else if (playerRB.velocity.x > 0 && !faceRight) FacialMovement();

            if (Input.GetAxis("Vertical") > 0 && isGrounded && nextJumpTime < Time.timeSinceLevelLoad)
            {
                nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
                Jump();
            }
            if(Input.GetKeyDown(KeyCode.E))
            {
                throwIt = true;
            }

        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetTrigger("Roll");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HurtItemTag"))
        {
            if (throwIt)
                ThrowIfHurtItem(collision.gameObject);
            throwIt = false;
        }
    }
   
    public void Die()
    {
 
        if (!isDead)
        {
            isDead = true;
            anim.SetTrigger("playerDeath");

            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
            AnimatorTransitionInfo transitionInfo = anim.GetAnimatorTransitionInfo(0);

            if (transitionInfo.IsName("AnyState -> Idle") && currentState.IsName("playerDeath"))
            {
                anim.ResetTrigger("playerDeath");
            }

            Invoke("ActivateGameOver", 4f);

            InvokeRepeating("stopMove", 0.1f, 0.7f);

            
            

        }
    }

    private void ActivateGameOver()
    {
        if (gameOverObject != null)
        {
            gameOverObject.SetActive(true);
        }
    }

    private void stopMove()
    {
        playerRB.velocity = new Vector2(0f, 0f);
    }

    private void ThrowIfHurtItem(GameObject collidedObject)
    {
        Vector2 throwDirection = faceRight ? Vector2.right : Vector2.left;
        throwDirection = Quaternion.Euler(0, 0, 70) * throwDirection;
        Debug.Log("deneme0");
        Rigidbody2D hurtItemRB = collidedObject.GetComponent<Rigidbody2D>();

        Vector2 force = throwDirection * throwSpeed;
        hurtItemRB.AddForce(force);
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

    void ChatBaloon()
    {
        chatBalloon.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(4);
        }

        if (other.gameObject.CompareTag("GameWin"))
        {
            Time.timeScale = 0;
            _gameWin.SetActive(true);
        }
    }
    
}
