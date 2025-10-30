using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GernadeBullet : MonoBehaviour
{
    public GameObject explosion;
    public float explosionradius;
    public float explosionForcer;
    public int damage;
    private List<Health> oldVictims = new List<Health>();

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion,transform.position,transform.rotation);   
        Destroy(gameObject);
        BlowOject();
    }
private void BlowOject()
    {
        oldVictims.Clear();
        Collider[]affectedObjects = Physics.OverlapSphere(transform.position,explosionradius);
        for (int i = 0; i <affectedObjects.Length; i++)
        {
            Rigidbody rigidbody = affectedObjects[i].attachedRigidbody;
            if(rigidbody)
            {
                DeliverDamage(affectedObjects[i]);
                rigidbody.AddExplosionForce(explosionForcer,transform.position, explosionradius,1,ForceMode.Impulse);
            }
        }
    }
    void DeliverDamage(Collider victim)
    {
        Health health = victim.GetComponentInParent<Health>();
        if (health != null && !oldVictims.Contains(health))
        {
            health.TakeDamage(damage);
            oldVictims.Add(health);
        }
    }
}
