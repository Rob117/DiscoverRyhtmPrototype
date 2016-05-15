using UnityEngine;
using System.Collections;

public class ScoreHandler : MonoBehaviour {

    public GameObject TouchRingPrefab;

    public GameObject PointTextPrefab;

    public enum PointTextKey { 
        Miss, Bad, Good, Great, Perfect
    }

    public Sprite[] TextSprite;

    private PointHandler PointHandlerObj;

    private GaugeHandler gaugeHandler;

    [HideInInspector]
    public GameObject touchBar;

	// Use this for initialization
	void Start () {

        int tick = 3100; // This is actually randomly chosen for a good delete time
        Invoke("AutoDestroy", (60 * tick) / (TimeManager.tempo * 480f));

        PointHandlerObj = FindObjectOfType<PointHandler>();
        gaugeHandler = FindObjectOfType<GaugeHandler>();

        //guagehandler find
	}

    //ゲームオブジェクトを削除

    public void OnScoreClick()
    {

        Vector3 PosInGame
            = GetComponentInParent<BoardMove>().transform.localPosition + transform.localPosition;

        //distance from floor
        int distance = (int)Mathf.Abs(PosInGame.y - (-350));

        float distancePoint = (100 - distance) / 100f;


        // if too far away, does nothing
        if (distancePoint <= 0) distancePoint = 0;
        GameData.GagePoint += distancePoint * 2;
        if (GameData.GagePoint > 100) GameData.GagePoint = 100;

        if (distancePoint > 0)
        {
            showRing();

            showText(distancePoint);

            GameData.score += (int)(distancePoint * 1641);
            PointHandlerObj.SetPoint(GameData.score);
            gaugeHandler.setGauge(GameData.GagePoint);

            //削除
            Destroy(gameObject);
        }
    }

    public void AutoDestroy()
    {
        Destroy(gameObject);

        showText(0);

        GameData.GagePoint -= 2;

        if (GameData.GagePoint < 0) GameData.GagePoint = 0;

        gaugeHandler.setGauge(GameData.GagePoint);
        FindObjectOfType<AudioManager>().GetComponent<AudioSource>().PlayOneShot(
            FindObjectOfType<AudioManager>().onMiss);
    }

    void showRing()
    {
        GameObject obj = Instantiate(TouchRingPrefab);

        obj.transform.position = touchBar.transform.position;
        obj.transform.localScale = Vector3.zero;

        obj.GetComponent<Animator>().Play(0);
    }

    void showText(float points)
    {
        GameObject pointObj = Instantiate(PointTextPrefab);

        pointObj.transform.position = touchBar.transform.position;
        pointObj.transform.localScale = Vector3.one;

        if (points > .2f)
            GameData.comboUp();
        else
            GameData.resetCombo();
        

        if (points > 0.8f)
            pointObj.GetComponentInChildren<SpriteRenderer>().sprite = TextSprite[(int)PointTextKey.Perfect];
        else if (points > 0.5f)
            pointObj.GetComponentInChildren<SpriteRenderer>().sprite = TextSprite[(int)PointTextKey.Great];
        else if (points > 0.2f)
            pointObj.GetComponentInChildren<SpriteRenderer>().sprite = TextSprite[(int)PointTextKey.Good];
        else if (points > 0.0f)
            pointObj.GetComponentInChildren<SpriteRenderer>().sprite = TextSprite[(int)PointTextKey.Bad];
        else
            pointObj.GetComponentInChildren<SpriteRenderer>().sprite = TextSprite[(int)PointTextKey.Miss];

        // This is in the child because it is attached to the image itself, not the gameobject parent
        //that is used as a prefab
        pointObj.GetComponentInChildren<Animator>().Play(0);

    }
}
