using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlockScr : MonoBehaviour
{
    float CurrentTime;
    float FallTime;
    int Height;
    int Width;
    [SerializeField] Vector3 RotationPoint;
    void Start()
    {
        CurrentTime = 0;
        GameOverCheck();
        Height = SpownerScr.Height;
        Width = SpownerScr.Width;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!ValidMove())
                transform.position -= new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMove())
                transform.position -= new Vector3(1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Rotate();
        }

        FallTime = Input.GetKey(KeyCode.S) ? DifficultyScr.FallTimeFast : DifficultyScr.FallTimeSlow;

        if (CurrentTime > FallTime)
        {
            transform.position += new Vector3(0, -1, 0);
            CurrentTime = 0;
            if (!ValidMove())
            {
                EndOfBrick();
            }
        }
        else
            CurrentTime += Time.deltaTime;

    }
    protected virtual void Rotate()
    {
        transform.RotateAround(transform.TransformPoint(RotationPoint), new Vector3(0, 0, 1), 90);
        if (!ValidMove())
            transform.RotateAround(transform.TransformPoint(RotationPoint), new Vector3(0, 0, 1), -90);
    }
    protected virtual void EndOfBrick()
    {
        transform.position -= new Vector3(0, -1, 0);
        AddToGrid();
        CheckForLine();
        enabled = false;
        FindObjectOfType<SpownerScr>().SpownBlock();
    }

    public void CheckForLine()
    {
        for (int i = Height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
                FindObjectOfType<ScoreCounterScr>().ScoreCount();
            }
        }
    }
    bool HasLine(int i)
    {
        for (int j = 0; j < Width; j++)
        {
            if (SpownerScr.grid[j, i] == null)
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
            Destroy(SpownerScr.grid[j, i].gameObject);
            SpownerScr.grid[j, i] = null;
        }
    }
    void RowDown(int i)
    {
        for (int y = i; y < Height; y++)
        {
            for (int j = 0; j < Width; j++)
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
    public void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int RoundedX = Mathf.RoundToInt(children.transform.position.x);
            int RoundedY = Mathf.RoundToInt(children.transform.position.y);

            SpownerScr.grid[RoundedX, RoundedY] = children;
        }
    }

    bool ValidMove()
    {
        foreach (Transform children in transform)
        {
            int RoundedX = Mathf.RoundToInt(children.transform.position.x);
            int RoundedY = Mathf.RoundToInt(children.transform.position.y);

            if (RoundedX < 0 || RoundedX >= Width || RoundedY < 0 || RoundedY >= Height)
            {
                return false;
            }


            if (SpownerScr.grid[RoundedX, RoundedY] != null)
                return false;
        }

        return true;
    }
    void GameOverCheck()
    {
        foreach (Transform children in transform)
        {
            int RoundedX = Mathf.RoundToInt(children.transform.position.x);
            int RoundedY = Mathf.RoundToInt(children.transform.position.y);

            if (SpownerScr.grid[RoundedX, RoundedY] != null)
                FindObjectOfType<GameoverScr>().Gameover();
        }
    }

}
