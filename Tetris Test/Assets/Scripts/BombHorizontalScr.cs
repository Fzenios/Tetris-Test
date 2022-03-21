using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHorizontalScr : TetrisBlockScr
{
    [SerializeField] BombDetonateHorScr bombDetonateHorScr;
    protected override void EndOfBrick()
    {
        transform.position -= new Vector3(0, -1, 0);
        AddToGrid();
        CheckForLine();
        enabled = false;
        FindObjectOfType<SpownerScr>().SpownBlock();
        bombDetonateHorScr.CanExplode = true;
    }
    protected override void Rotate()
    {

    }
}
