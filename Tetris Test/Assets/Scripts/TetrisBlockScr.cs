using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlockScr : MonoBehaviour
{
    float CurrentTime;
    [SerializeField] float FallTimeSlow, FallTimeFast;
    float FallTime;
    public static int Height = 21;
    public static int Width = 10;
    [SerializeField] Vector3 RotationPoint;
    static Transform[,] grid = new Transform[Width,Height];
    void Start()
    {
        CurrentTime = 0;
        FallTime = FallTimeSlow;
        GameOverCheck();
    }

    void Update()
    {      
        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);
            if(!ValidMove())
                transform.position -= new Vector3(-1, 0, 0);
        }          
        else if(Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);      
            if(!ValidMove())
                transform.position -= new Vector3(1, 0, 0);    
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            transform.RotateAround(transform.TransformPoint(RotationPoint), new Vector3(0, 0, 1), 90);
            if(!ValidMove())
                transform.RotateAround(transform.TransformPoint(RotationPoint), new Vector3(0, 0, 1), -90);           
        }   

        FallTime = Input.GetKey(KeyCode.S) ? FallTimeFast : FallTimeSlow;  

        if(CurrentTime > FallTime)
            {
                transform.position += new Vector3(0, -1, 0);
                CurrentTime = 0;
                if(!ValidMove())
                {
                    transform.position -= new Vector3(0, -1, 0);
                    AddToGrid();
                    CheckForLine();
                    enabled = false;
                    FindObjectOfType<SpownerScr>().SpownBlock();                    
                }
            }
        else
            CurrentTime += Time.deltaTime;      

    }
    
    void CheckForLine()
    {
        for (int i = Height-1; i >= 0; i--)
        {
            if(HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }
    bool HasLine(int i)
    {
        for (int j = 0; j < Width; j++)
        {
            if(grid[j,i] == null )
            {
                return false;                  
            }                 
        }        
        return true;        
    }
    void DeleteLine(int i)
    {
        for (int j = 0; j < Width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }
    void RowDown(int i)
    {
        for (int y = i; y < Height; y++)
        {
            for (int j = 0; j < Width; j++)
            {
                if(grid[j,y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0 , 1, 0);
                }
            }
        }
    }
    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int RoundedX = Mathf.RoundToInt(children.transform.position.x);
            int RoundedY = Mathf.RoundToInt(children.transform.position.y);   

            grid[RoundedX, RoundedY] = children;             
        }
    }

    bool ValidMove()
    {
        foreach (Transform children in transform)
        {
            int RoundedX = Mathf.RoundToInt(children.transform.position.x);
            int RoundedY = Mathf.RoundToInt(children.transform.position.y);  

            if(RoundedX < 0 || RoundedX >= Width || RoundedY < 0 || RoundedY >= Height)
            {
                return false;
            }
            
            
            if(grid[RoundedX, RoundedY] != null)
                return false;
        }

        return true;
    }
    void GameOverCheck()
    {
        /*foreach (Transform children in transform)
        {
            int RoundedY = Mathf.RoundToInt(children.transform.position.y);  
            if(RoundedY >= Height)
            {
                FindObjectOfType<GameoverScr>().Gameover();
            }
        }*/
        foreach (Transform children in transform)
        {
            int RoundedX = Mathf.RoundToInt(children.transform.position.x);
            int RoundedY = Mathf.RoundToInt(children.transform.position.y);   

            if(grid[RoundedX, RoundedY] != null)
                FindObjectOfType<GameoverScr>().Gameover();    
        }
    }
}
