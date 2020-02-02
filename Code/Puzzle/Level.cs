using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Level : ScriptableObject
{
    public List<PuzzlePiece> LeftSide;
    public List<PuzzlePiece> RightSide;
    public float PanicTime;
    public float RoundTime;
}
