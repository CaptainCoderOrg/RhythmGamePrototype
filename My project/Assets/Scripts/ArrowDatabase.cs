using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ArrowDatabase", menuName = "FunkyDancerPro/ArrowDatabase")]
public class ArrowDatabase : ScriptableObject
{

    [SerializeField]
    private Image Template;
    [SerializeField]
    private Sprite LeftArrow;
    [SerializeField]
    private Sprite LeftArrowHalfBeat;
    [SerializeField]
    private Sprite LeftArrowQuarterBeat;
    [SerializeField]
    private Sprite DownArrow;
    [SerializeField]
    private Sprite DownArrowHalfBeat;
    [SerializeField]
    private Sprite DownArrowQuarterBeat;
    [SerializeField]
    private Sprite UpArrow;
    [SerializeField]
    private Sprite UpArrowHalfBeat;
    [SerializeField]
    private Sprite UpArrowQuarterBeat;
    [SerializeField]
    private Sprite RightArrow;
    [SerializeField]
    private Sprite RightArrowHalfBeat;
    [SerializeField]
    private Sprite RightArrowQuarterBeat;

    public Sprite LoadSprite(int beatCursor, Pad direction)
    {
        // 1000 is on beat % 1000 == 0
        // 500 is Half beat % 1000 == 500
        // 250 is Quarter beat % 1000 = 250
        int beatOffset = beatCursor % 1000;
        return (direction, beatOffset) switch 
        {
            (Pad.Left, 0) => LeftArrow,
            (Pad.Down, 0) => DownArrow,
            (Pad.Up, 0) => UpArrow,
            (Pad.Right, 0) => RightArrow,
            
            (Pad.Left, 500) => LeftArrowHalfBeat,
            (Pad.Down, 500) => DownArrowHalfBeat,
            (Pad.Up, 500) => UpArrowHalfBeat,
            (Pad.Right, 500) => RightArrowHalfBeat,

            (Pad.Left, 250) => LeftArrowQuarterBeat,
            (Pad.Down, 250) => DownArrowQuarterBeat,
            (Pad.Up, 250) => UpArrowQuarterBeat,
            (Pad.Right, 250) => RightArrowQuarterBeat,

            (Pad.Left, 750) => LeftArrowQuarterBeat,
            (Pad.Down, 750) => DownArrowQuarterBeat,
            (Pad.Up, 750) => UpArrowQuarterBeat,
            (Pad.Right, 750) => RightArrowQuarterBeat,

            _ => throw new NotImplementedException(),
        };
    }

    public GameObject Instantiate(int beatCursor, Pad direction, Transform parent)
    {
        Image newImage = Instantiate(Template, parent);
        newImage.sprite = LoadSprite(beatCursor, direction);
        return newImage.gameObject;
    }
}
