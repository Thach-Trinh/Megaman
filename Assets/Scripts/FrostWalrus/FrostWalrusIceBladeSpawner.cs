using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostWalrusIceBladeSpawner : MonoBehaviour
{
    public Color pointColor = Color.white;
    public float radius;
    public GameObject iceBladeCouple;
    private void OnDrawGizmos()
    {
        Gizmos.color = pointColor;
        Gizmos.DrawSphere(transform.position, radius);
    }
    public void CreateIceBladeCouple()
    {
        Instantiate(iceBladeCouple, transform.position, Quaternion.identity);
    }

}
