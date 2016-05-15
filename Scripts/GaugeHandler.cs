using UnityEngine;
using System.Collections;

public class GaugeHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setGauge(float point)
    {
        float length = point / 100f;

        StopCoroutine("GaugeAnim");

        StartCoroutine(
            GuageAnim(
                transform.localScale.x, length, 0.2f
            )
        );
    }

    public void SetPoint(long point)
    {
        
    }

    //Point Anim

    private IEnumerator GuageAnim(float start, float end, float time)
    {
        float startTime = TimeManager.time;

        float endTime = startTime + time;

        //Per frame action
        do
        {

            //current time in our animation
            float t = (TimeManager.time - startTime) / time;

            float updateValue = (end - start) * t + start;

            transform.localScale = new Vector3(updateValue, 1, 1);

            yield return null;

        } while (TimeManager.time < endTime);

        transform.localScale = new Vector3 (end, 1, 1);
    }
}
