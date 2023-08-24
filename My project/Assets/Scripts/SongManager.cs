using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    [field: SerializeField]
    public Song CurrentSong { get; private set; }

    [field: SerializeField]
    public ArrowTracks Tracks { get; private set; }

    public void InitiliazeTracks()
    {
        foreach (Beat beat in CurrentSong.Beats)
        {
            Tracks.AddBeat(beat);
        }
    }

    private void Awake()
    {
        Debug.Assert(CurrentSong != null);
        Debug.Assert(Tracks != null);
    }
    
    void Start()
    {
        InitiliazeTracks();
    }
}
