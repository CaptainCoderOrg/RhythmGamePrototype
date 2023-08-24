using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTracks : MonoBehaviour
{
    [field: SerializeField]
    public GameObject LeftTrack { get; private set; }
    [field: SerializeField]
    public GameObject DownTrack { get; private set; }
    [field: SerializeField]
    public GameObject UpTrack { get; private set; }
    [field: SerializeField]
    public GameObject RightTrack { get; private set; }
    [field: SerializeField]
    public ArrowDatabase Database { get; private set;}

    private int _beatCursor = 0;

    void Awake()
    {
        DestroyAllChildrenOfGameObjectNotHumansDontGetMadAtMe(LeftTrack.transform);
        DestroyAllChildrenOfGameObjectNotHumansDontGetMadAtMe(RightTrack.transform);
        DestroyAllChildrenOfGameObjectNotHumansDontGetMadAtMe(DownTrack.transform);
        DestroyAllChildrenOfGameObjectNotHumansDontGetMadAtMe(UpTrack.transform);
    }

    private void DestroyAllChildrenOfGameObjectNotHumansDontGetMadAtMe(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }

    public void AddBeat(Beat toAdd)
    {
        AddPads(toAdd.Pads);
        _beatCursor += toAdd.Duration;
    }

    private void AddPads(Pad toAdd)
    {
        if (toAdd.HasFlag(Pad.Left))
        {
            GameObject arrow = Instantiate(Database.Load(_beatCursor, Pad.Left), LeftTrack.transform);
        }
        if (toAdd.HasFlag(Pad.Down))
        {
            GameObject arrow = Instantiate(Database.Load(_beatCursor, Pad.Down), DownTrack.transform);
        }
        if (toAdd.HasFlag(Pad.Up))
        {
            GameObject arrow = Instantiate(Database.Load(_beatCursor, Pad.Up), UpTrack.transform);
        }
        if (toAdd.HasFlag(Pad.Right))
        {
            GameObject arrow = Instantiate(Database.Load(_beatCursor, Pad.Right), RightTrack.transform);
        }
    }
}
