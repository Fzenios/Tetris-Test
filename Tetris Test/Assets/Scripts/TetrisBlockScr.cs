using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlockScr : MonoBehaviour
{
    float CurrentTime;
    [SerializeField] float FallTimeSlow, FallTimeFast;
    float FallTime;
    public static int Height = 20;
    public static int Width = 10;
    [SerializeField] Transform RotationPoint;
    void Start()
    {
        CurrentTime = 0;
        FallTime = FallTimeSlow;
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
            transform.RotateAround(transform.TransformPoint(RotationPoint.localPosition), new Vector3(0, 0, 1), 90);
            if(!ValidMove())
                transform.RotateAround(transform.TransformPoint(RotationPoint.localPosition), new Vector3(0, 0, 1), -90);           
        }   

        FallTime = Input.GetKey(KeyCode.S) ? FallTimeFast : FallTimeSlow;  

        if(CurrentTime > FallTime)
            {
                transform.position += new Vector3(0, -1, 0);
                CurrentTime = 0;
                if(!ValidMove())
                    transform.position -= new Vector3(0, -1, 0);
            }
        else
            CurrentTime += Time.deltaTime;      

        
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
        }
        return true;
    }
}
