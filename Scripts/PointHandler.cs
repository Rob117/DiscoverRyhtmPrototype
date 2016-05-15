using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointHandler : MonoBehaviour {

    public void SetPoint(long point)
    {
        StopCoroutine("PointAnimation");

        StartCoroutine(
            PointAnimation(
                long.Parse(gameObject.GetComponent<Text>().text), point, 0.2f
            )
        );
    }

    //Point Anim

    private IEnumerator PointAnimation(long start, long end, float time)
    {
        float startTime = TimeManager.time;

        float endTime = startTime + time;

        //Per frame action
        do
        {

            //current time in our animation
            float t = (TimeManager.time - startTime) / time;

            long updateValue = (long)((end - start) * t + start);

            GetComponent<Text>().text = updateValue.ToString("0000000");

            yield return null;
        } while (TimeManager.time < endTime);

        GetComponent<Text>().text = end.ToString("0000000");
    }
}
