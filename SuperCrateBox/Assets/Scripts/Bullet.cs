using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private int damage = 1;

    private Rigidbody2D rb2d;
    private int directionX;

    public void Initialize(int directionX)
    {
        rb2d = GetComponent<Rigidbody2D>();
        this.directionX = directionX;
    }

    private void Update()
    {
        rb2d.position = rb2d.position + Vector2.right * directionX * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.GetComponent<GroundEnemy>())
        {
            collision.transform.GetComponent<HealthSystem>().Hit(damage);
            Destroy(gameObject);
        }

        else if(!collision.transform.GetComponent<Bullet>() && !collision.transform.GetComponent<Crate>())
        {
            Destroy(gameObject);
        }
    }
}
