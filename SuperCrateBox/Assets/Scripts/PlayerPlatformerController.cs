using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{
    public float maxSpeed = 7f;
    public float jumpTakeOffSpeed = 7f;
    public Animator animator;

    public bool flipped;
    private bool moving;

    private void Awake()
    {
        flipped = false;
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;
        moving = false;

        move.x = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if(Input.GetButtonUp("Jump"))
        {
            if(velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        if(move.x != 0f)
        {
            moving = true;

            if(!flipped && move.x < 0 || flipped && move.x > 0)
            {
                flipped = !flipped;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }

        targetVelocity = move * maxSpeed;

        animator.SetBool("Moving", moving);
        animator.SetBool("Grounded", grounded);
    }
}
