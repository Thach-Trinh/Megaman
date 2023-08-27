using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSpiderLightningWeb : MonoBehaviour
{
    public int damage;
    public Transform target;
    public Animator anim;
    private void OnValidate()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerHP>(out var health))
        {
            health.TakeDamage(damage);
            anim.SetTrigger("Disappear");
            Destroy(gameObject, 0.167f);
        }

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
