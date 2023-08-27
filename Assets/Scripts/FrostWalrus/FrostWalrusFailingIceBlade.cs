using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostWalrusFailingIceBlade : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerHP>(out var playerHealth))
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
