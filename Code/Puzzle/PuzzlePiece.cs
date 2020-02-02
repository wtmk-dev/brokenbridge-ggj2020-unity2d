using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PuzzlePiece : ScriptableObject 
{
   public Action<PuzzlePiece> OnSelected;
   public bool isLeftSide;
   public Sprite sprite;
   public Vector3 startPos;
   public Vector3 endPos;
   public float speed;
   public int ID;

   public void SelectPiece()
   {
       if(OnSelected != null)
       {
           OnSelected(this);
       }
   }

}
