using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDetonateVertScr : MonoBehaviour
{
    public bool CanExplode = false;
    bool ManualDetonate = false;
    [SerializeField] GameObject ExplosionVer;
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
            int RoundedY = Mathf.RoundToInt(transform.position.y);

            GameObject ExplosionVerObj = Instantiate(ExplosionVer, new Vector3(RoundedX, RoundedY), ExplosionVer.transform.rotation);
            Destroy(ExplosionVerObj, 1);

            for (int j = 0; j < SpownerScr.Height; j++)
            {
                if (SpownerScr.grid[RoundedX, j] != null)
                    Destroy(SpownerScr.grid[RoundedX, j].gameObject);
                SpownerScr.grid[RoundedX, j] = null;
            }
        }
    }
}
