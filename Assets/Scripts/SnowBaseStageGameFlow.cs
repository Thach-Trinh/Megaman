using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBaseStageGameFlow : GameFlow
{
    public IceHp iceStone;
    public IceBladeController iceBladeController;
    [SerializeField] private SFXList list;
    public override void CallTheBoss()
    {
        base.CallTheBoss();
        iceStone.GetCracked();
    }
    public override void CreateBoss()
    {
        list.GetComponent<SFXList>().SFXPlayer(0);
        iceStone.Die();      
        base.CreateBoss();
        var walrus = currentBoss.GetComponent<FrostWalrus>();
        walrus.target = hero.transform;
        walrus.iceBladeController = iceBladeController;

    }
}
