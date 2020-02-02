using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerModel : ScriptableObject
{
    public Sprite Sprite;
    public bool IsLeftPlayer, HasSelected;
    public Vector3 StartingPosition;
}
