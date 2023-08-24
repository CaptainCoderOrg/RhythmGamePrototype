using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArrowDatabase", menuName = "FunkyDancerPro/ArrowDatabase")]
public class ArrowDatabase : ScriptableObject
{
    public GameObject LeftArrow;
    public GameObject DownArrow;
    public GameObject UpArrow;
    public GameObject RightArrow;

    public GameObject Load(int beatCursor, Pad direction)
    {
        return direction switch 
        {
            Pad.Left => LeftArrow,
            Pad.Down => DownArrow,
            Pad.Up => UpArrow,
            Pad.Right => RightArrow,
            _ => throw new NotImplementedException(),
        };
    }
}
