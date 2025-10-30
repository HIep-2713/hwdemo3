using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{
    public int maxHleathPointl;
    public Animator ani;
    private int healthpoint;
    public UnityEvent onDie;
    private bool isDead => healthpoint <= 0;
    void Start()
    {
        healthpoint = maxHleathPointl;
    }

    public void TakeDamage(int damage)
    {
        if(isDead) return;
        healthpoint-=damage;
        if(isDead)
        {
            Die();
        }
    }
    private void Die()
    {
        ani.SetTrigger("Die");
        onDie.Invoke();
    }
}
