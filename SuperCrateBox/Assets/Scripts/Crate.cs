using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Crate : MonoBehaviour
{
    public UnityEvent OnPickUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>())
        {
            OnPickUp.Invoke();
            Destroy(gameObject);
        }
    }
}
