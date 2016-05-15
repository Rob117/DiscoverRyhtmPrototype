using UnityEngine;
using System.Collections;

public class AutoDestruct : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnAnimationStop()
    {
        Destroy(gameObject);
    }

    public void OnAnimationStopOnParent()
    {
        Destroy(transform.parent.gameObject);
    }
}
