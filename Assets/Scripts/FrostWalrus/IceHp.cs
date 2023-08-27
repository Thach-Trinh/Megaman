using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceHp : EnemyHp
{
    public int numberOfPiece;
    public float force;
    public IcePiece[] pieces;
    public Transform crackPosition;
    public void GetCracked()
    {
        crackPosition.gameObject.SetActive(true);
    }
    public override void Die()
    {
        ReleaseIcePiece();
        Destroy(gameObject);
    }
    private void ReleaseIcePiece()
    {
        for (int i = 0; i < numberOfPiece; i++)
        {
            var pieceType = Random.Range(0, pieces.Length);
            var newPiece = Instantiate(pieces[pieceType], transform.position, Quaternion.identity);
            newPiece.Lauch(force);
            
        }
    }
}
