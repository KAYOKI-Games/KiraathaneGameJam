using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public float speed = 10f; //Controls velocity multiplier
    private Rigidbody2D rb;
    private void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal"); // d key changes value to 1, a key changes value to -1
        float yMove = Input.GetAxisRaw("Vertical"); // w key changes value to 1, s key changes value to -1

        rb.velocity = new Vector3(xMove,yMove) * speed;
    }
}
