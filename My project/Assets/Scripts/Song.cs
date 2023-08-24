using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

[CreateAssetMenu(fileName = "Song", menuName = "FunkyDancerPro/Song")]
public class Song : ScriptableObject
{
    public Beat[] Beats;
}
