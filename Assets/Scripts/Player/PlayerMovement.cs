using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private Animator animator;
    private BoxCollider2D collider;
    private SpriteRenderer sprite;


    private float directionX = 0f;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState
    {
        idle,
        run,
        jump,
        fall
    }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    private void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        playerBody.velocity = new Vector2(directionX * moveSpeed, playerBody.velocity.y);


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            //Debug.Log($"{KeyCode.Space} clicked");
            jumpSoundEffect.Play();
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpForce);
        }

        AnimationUpdate(directionX);
    }

    private void AnimationUpdate(float directionX)
    {
        MovementState state;

        if (directionX > 0f)
        {
            state = MovementState.run;
            sprite.flipX = false;
        }

        else if (directionX < 0f)
        {
            state = MovementState.run;
            sprite.flipX = true;
        }

        else
        {
            state = MovementState.idle;
        }

        if (playerBody.velocity.y > .1f)
        {
            state = MovementState.jump;
        }

        else if (playerBody.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }
        animator.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
