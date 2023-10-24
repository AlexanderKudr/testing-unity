using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private Animator animator;
    private SpriteRenderer sprite;

    private float directionX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    // Start is called before the first frame update
    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    private void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");

        playerBody.velocity = new Vector2(directionX * moveSpeed, playerBody.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log($"{KeyCode.Space} clicked");
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpForce);
        }

        AnimationUpdate(directionX);
    }

    private void AnimationUpdate(float directionX)
    {
        if (directionX > 0f)
        {
            animator.SetBool("running", true);
            sprite.flipX = false;
        }

        else if (directionX < 0f)
        {
            animator.SetBool("running", true);
            sprite.flipX = true;
        }

        else
        {
            animator.SetBool("running", false);
        }
    }
}
