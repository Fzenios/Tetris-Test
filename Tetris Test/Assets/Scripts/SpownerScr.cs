using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownerScr : MonoBehaviour
{
    [SerializeField] GameObject[] BlocksObj;
    [SerializeField] Transform SpownerPos;
    [SerializeField] Transform BlockParent;
    [SerializeField] Transform Background;
    CleanHierarchyScr cleanHierarchyScr;
    public static int Height;
    public static int Width;
    int RandomBlock;

    public static Transform[,] grid;

    void Awake()
    {
        Height = (int)Background.localScale.y + 1;
        Width = (int)Background.localScale.x;
        grid = new Transform[Width, Height];
    }
    void Start()
    {
        cleanHierarchyScr = gameObject.GetComponent<CleanHierarchyScr>();
        SpownBlock();
    }
    public virtual void SpownBlock()
    {
        cleanHierarchyScr.CleanHierarchy();
        if (BlockOrBomb() == 2)
            RandomBlock = Random.Range(7, 9);
        else
            RandomBlock = Random.Range(0, 7);
        GameObject NewBlock = Instantiate(BlocksObj[RandomBlock], SpownerPos.position, BlocksObj[RandomBlock].transform.rotation, BlockParent);
        ControlsScr.tetrisBlockScr = NewBlock.GetComponent<TetrisBlockScr>();
    }
    int BlockOrBomb()
    {
        float Timer = DifficultyScr.FallTimeSlow;
        int SpownType;
        int RandomChance = Random.Range(0, 101);
        switch (Timer)
        {
            case 0.5f: SpownType = RandomChance < 15 ? 2 : 1; break;
            case 0.3f: SpownType = RandomChance < 10 ? 2 : 1; break;
            case 0.2f: SpownType = RandomChance < 5 ? 2 : 1; break;
            case 0.1f: SpownType = RandomChance < 3 ? 2 : 1; break;
            default: SpownType = RandomChance < 20 ? 2 : 1; break;
        }
        return SpownType;
    }
}
