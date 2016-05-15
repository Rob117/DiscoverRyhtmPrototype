using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {

    //tick 
    public static long tick;

    //tempo
    public static int tempo;

    //時間//
    public static float time;

	// Use this for initialization
	void Start () {
       
        //Init//
        time = 2.4f;

        tick = 0;
	}
	
	// Update is called once per frame
	void Update () {

        time += Time.deltaTime;

        tick = (long)(
            time * tempo * 480f / 60f);
	}

}
