using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFcontroller : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumppableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;

    private enum MovementState { idle, run, jump, bash }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.S) && IsGrounded())
        {
            Jump();
        }

        if (!IsGrounded())
        {
            Bash();
        }

        UpdateAnimationState();
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumppableGround);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void Bash()
    {
        anim.SetInteger("state", (int)MovementState.bash);
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.run;
            AudioMgr.instance.PlayAudioSource("脚步声");
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.run;
            AudioMgr.instance.PlayAudioSource("脚步声");
            sprite.flipX = true;
        }
        else
        {
            AudioMgr.instance.stopVoice();
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.bash;
        }
        
        anim.SetInteger("state", (int)state);
    }
}