using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownerScr : MonoBehaviour
{
    [SerializeField] GameObject[] BlocksObj;
    [SerializeField] Transform SpownerPos;
    
    void Start()
    {
        SpownBlock();
    }
    void Update()
    {
        
    }
    public void SpownBlock()
    {
        int RandomBlock = Random.Range(0, BlocksObj.Length); 
        Instantiate(BlocksObj[RandomBlock], SpownerPos.position, BlocksObj[RandomBlock].transform.rotation);
    }
}
