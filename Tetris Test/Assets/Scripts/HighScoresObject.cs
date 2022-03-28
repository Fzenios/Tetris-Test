using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HighScoresObject", menuName = "HighScoresObject")]
public class HighScoresObject : ScriptableObject
{
    public DataForSaving dataForSaving;

    [System.Serializable]
    public class DataForSaving
    {
        public float ClassicHS, HyperHS;
    }
}
