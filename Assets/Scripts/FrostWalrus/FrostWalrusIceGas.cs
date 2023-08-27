using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostWalrusIceGas : MonoBehaviour
{
    public int damage;
    public int speed;
    public Vector2 direction;
    private Vector2 normalDirection;
    void Start()
    {
        normalDirection = direction.normalized;
        Destroy(gameObject, 0.583f);
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * normalDirection);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerHP>(out var playerHealth))
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
