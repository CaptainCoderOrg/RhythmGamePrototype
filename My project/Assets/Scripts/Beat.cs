using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

[Serializable]
public struct Beat
{
    // TODO: 1 beat = 1000
    public int Duration;
    public Pad Pads;
}

