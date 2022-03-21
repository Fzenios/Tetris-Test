using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanHierarchyScr : MonoBehaviour
{
    [SerializeField] Transform BlocksObjs;
    public void CleanHierarchy()
    {
        foreach (Transform BlockParent in BlocksObjs)
        {
            if(BlockParent.childCount == 0)
            {
                Destroy(BlockParent.gameObject);
            }      
        }
    }
}
