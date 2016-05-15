using UnityEngine;
using System.Collections;

public class MusicData {

    // Tick
    public long tick;

    //Values
    public int value;

    public bool isCreated;

    // Constructor
    public MusicData(long tick, int value)
    {
        this.tick = tick;
        this.value = value;
        isCreated = false;
    }
}
