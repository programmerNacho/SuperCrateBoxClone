using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : PhysicsObject
{
    public float maxSpeed = 5f;
    public string wallTag;
    public string playerTag;

    private int directionX;
    private bool flipped;

    private void Awake()
    {
        InitializeEnemy(1, false);
    }

    public void InitializeEnemy(int directionX, bool flipped)
    {
        this.directionX = directionX;
        this.flipped = flipped;
        CheckOrientation();
    }

    protected override void ComputeVelocity()
    {
        CheckOrientation();

        targetVelocity = Vector2.right * directionX * maxSpeed;
    }

    private void CheckOrientation()
    {
        if (directionX != 0f)
        {
            if (!flipped && directionX < 0 || flipped && directionX > 0)
            {
                flipped = !flipped;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(wallTag))
        {
            directionX = -directionX;
        }
        else if (collision.transform.CompareTag(playerTag))
        {
            collision.transform.GetComponent<HealthSystem>().Hit(1000);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
