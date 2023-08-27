using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruction : MonoBehaviour
{
    public IceHp iceHP;
    public float timeToSelfDestroy;
    // Start is called before the first frame update
    void Start()
    {
        iceHP = GetComponent<IceHp>();
        
    }
    private void Update()
    {
        timeToSelfDestroy -= Time.deltaTime;
        if(timeToSelfDestroy <= 0)
        {
            iceHP.Die();
        }
    }
}
