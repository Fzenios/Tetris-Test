using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombVerticalScr : TetrisBlockScr
{
    [SerializeField] BombDetonateVertScr bombDetonateVertScr;
    protected override void EndOfBrick()
    {
        transform.position -= new Vector3(0, -1, 0);
        AddToGrid();
        CheckForLine();
        enabled = false;
        FindObjectOfType<SpownerScr>().SpownBlock();
        bombDetonateVertScr.CanExplode = true;
    }
    protected override void Rotate()
    {

    }
}
