using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDetonateHorScr : MonoBehaviour
{
    public bool CanExplode = false;
    bool ManualDetonate = false;
    [SerializeField] GameObject ExplosionHor;
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
            int RoundedY = Mathf.RoundToInt(transform.position.y);
            int RoundedX = Mathf.RoundToInt(transform.position.x);

            GameObject ExplosionHorObj = Instantiate(ExplosionHor, new Vector3(RoundedX, RoundedY), ExplosionHor.transform.rotation);
            Destroy(ExplosionHorObj, 1);

            for (int j = 0; j < SpownerScr.Width; j++)
            {
                if (SpownerScr.grid[j, RoundedY] != null)
                    Destroy(SpownerScr.grid[j, RoundedY].gameObject);
                SpownerScr.grid[j, RoundedY] = null;
            }

            for (int y = RoundedY; y < SpownerScr.Height; y++)
            {
                for (int j = 0; j < SpownerScr.Width; j++)
                {
                    if (SpownerScr.grid[j, y] != null)
                    {
                        SpownerScr.grid[j, y - 1] = SpownerScr.grid[j, y];
                        SpownerScr.grid[j, y] = null;
                        SpownerScr.grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                    }
                }
            }
        }
    }
}
