using System;

[Flags]
public enum Pad
{
    Left  = 0b0001,
    Down  = 0b0010,
    Up    = 0b0100,
    Right = 0b1000,
}