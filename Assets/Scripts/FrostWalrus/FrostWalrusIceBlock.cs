using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostWalrusIceBlock : MonoBehaviour
{
    public int numberOfIceSpike;
    public float force;
    public float minAngleInDegree;
    public float maxAngleInDegree;
    
    public FrostWalrusIceSpike iceSpike;

    private float minAngleInRadian;
    private float maxAngleInRadian;
    private float angularInterval;
    private void Start()
    {
        minAngleInRadian = minAngleInDegree * Mathf.PI / 180;
        maxAngleInRadian = maxAngleInDegree * Mathf.PI / 180;
        angularInterval = (maxAngleInRadian - minAngleInRadian) / (numberOfIceSpike - 1);
    }
    public void GetBroken()
    {
        Destroy(gameObject);
        ReleaseIceSpike();
    }
    private void ReleaseIceSpike()
    {
        for (int i = 0; i < numberOfIceSpike; i++)
        {
            var angle = minAngleInRadian + i * angularInterval;
            var xForce = force * Mathf.Cos(angle);
            var yForce = force * Mathf.Sin(angle);
            var spike = Instantiate(iceSpike, transform.position, transform.rotation);
            spike.GetForce(-xForce * transform.right.x, yForce);
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GetBroken();
        }
    }

}
