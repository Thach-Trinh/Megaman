using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBladeTrap : MonoBehaviour
{
    public Rigidbody2D rigid;
    private void Start()
    {
        rigid.gravityScale = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (rigid != null) rigid.gravityScale = 1;
    }

}
