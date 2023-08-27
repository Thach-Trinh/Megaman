using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostWalrusIceSpike : MonoBehaviour
{
    public int damage;

    public Rigidbody2D rigid;
    private void OnValidate()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update

    public void GetForce(float xForce, float yForce)
    {
        rigid.AddForce(new Vector2(xForce, yForce));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
            //rigid.velocity = Vector2.zero;
        }
        if (collision.collider.TryGetComponent<PlayerHP>(out var health))
        {
            health.TakeDamage(damage);

        }
    }

}
