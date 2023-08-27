using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBladeController : MonoBehaviour
{
    public FrostWalrusIceBladeSpawner[] spawners;
    //private int numberOfSpawner;
    //private void Start()
    //{
    //    numberOfSpawner = spawners.Length;
    //}
    
    public void CreateIceBlade()
    {
        var spawnerList = new List<FrostWalrusIceBladeSpawner>(spawners);

        for (int i = 0; i < 3; i++)
        {
            var spawnerIndex = Random.Range(0, spawnerList.Count);
            spawnerList[spawnerIndex].CreateIceBladeCouple();
            spawnerList.RemoveAt(spawnerIndex);
        }
    }
}
