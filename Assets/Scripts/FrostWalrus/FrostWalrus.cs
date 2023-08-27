using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostWalrus : Maverick
{
    public int contactDamage;
    public Transform mouth;
    public Transform foot;
    public Transform hand;
    public Transform dangerChecker;
    public Transform iceBladeLaucher1;
    public Transform iceBladeLaucher2;
    public Transform iceBlockPosition;

    public EnemyProjectile iceBlade1;
    public EnemyProjectile iceBlade2;
    public FrostWalrusIceGas iceGas;
    public FrostWalrusIceBlock iceBlock;
    public IceBladeController iceBladeController;

    public static FrostWalrusIceBlock currentIceBlock;
}
