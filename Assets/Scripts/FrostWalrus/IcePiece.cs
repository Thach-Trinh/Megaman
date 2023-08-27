using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePiece : MonoBehaviour
{
    public Rigidbody2D rigid;
    private void OnValidate()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }
    public void Lauch(float force)
    {
        var xDirection = Random.Range(-1f, 1f);
        var yDirection = Random.Range(-1f, 1f);
        var direction = new Vector2(xDirection, yDirection);
        rigid.AddForce(force * direction.normalized);
    }
}
