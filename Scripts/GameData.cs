using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameData {

    public static long score;

    public static float GagePoint;

    public static int currentCombo;

    public static int MaxCombo;

    public delegate void comboUpdate();
    public static event comboUpdate onUpdated;

    public static void comboUp()
    {
        currentCombo++;
        if (MaxCombo < currentCombo)
        {
            MaxCombo = currentCombo;
            if (onUpdated != null) 
                onUpdated();
        }
    }

    public static void resetCombo()
    {
        currentCombo = 0;
    }
}
