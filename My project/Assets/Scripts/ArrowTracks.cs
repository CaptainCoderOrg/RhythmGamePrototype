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
        float cursorInPixels = _beatCursor / 1000f;
        SetPadPosition(toAdd, Pad.Left, LeftTrack.transform);
        SetPadPosition(toAdd, Pad.Down, DownTrack.transform);
        SetPadPosition(toAdd, Pad.Up, UpTrack.transform);
        SetPadPosition(toAdd, Pad.Right, RightTrack.transform);
    }

    private void SetPadPosition(Pad toAdd, Pad toCheck, Transform parent)
    {
        float cursorInPixels = _beatCursor / 1000f;
        if (toAdd.HasFlag(toCheck))
        {
            GameObject arrow = Instantiate(Database.Load(_beatCursor, toCheck), parent);
            RectTransform rectTransform = arrow.GetComponent<RectTransform>();
            Vector3 newPosition = rectTransform.localPosition;
            newPosition.y = -200 * cursorInPixels;
            rectTransform.localPosition = newPosition;
        }
    }
}
