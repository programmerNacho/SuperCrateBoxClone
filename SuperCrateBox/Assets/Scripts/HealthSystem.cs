using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    public int health;

    public UnityEvent OnDeath;

    public void Hit(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            OnDeath.Invoke();
        }
    }
}
