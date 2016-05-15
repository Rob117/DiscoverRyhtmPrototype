using UnityEngine;
using System.Collections;

public class BoardMove : MonoBehaviour {

    public static float speed = 0.5f;
	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = new Vector3(0, -TimeManager.tick * speed , 0);
	}
}
