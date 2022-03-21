using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDetonateVertScr : MonoBehaviour
{
    public bool CanExplode = false;
    bool ManualDetonate = false;
    void OnDestroy()
    {
        if (!ManualDetonate)
            DetonateBomb();
    }
    void OnMouseDown()
    {
        DetonateBomb();
        ManualDetonate = true;
    }
    void DetonateBomb()
    {
        if (CanExplode)
        {
            int RoundedX = Mathf.RoundToInt(transform.position.x);
            for (int j = 0; j < SpownerScr.Height; j++)
            {
                if (SpownerScr.grid[RoundedX, j] != null)
                    Destroy(SpownerScr.grid[RoundedX, j].gameObject);
                SpownerScr.grid[RoundedX, j] = null;
            }
        }
    }
}
