using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using MiniJSON;

public class ScoreCreator : MonoBehaviour {

    //プレハブを格納変数
    public GameObject scorePrefab;

    float timer;

    //Json Text Data
    public TextAsset jsonData;

    // Score array
    public List<MusicData> scoreData;

    //Xpos from touchbars
    private static float[] ScorePositionXList = new float[]{
    -480, -160, 160, 480
};

    public GameObject[] touchBars;

	// Use this for initialization
	void Start () {
        Random.seed = 100;
        timer = TimeManager.time + 1f;

        scoreData = new List<MusicData>();

        //Change TextData into an array
        IDictionary tempData = (IDictionary)Json.Deserialize(jsonData.text);

        //cast into a score 
        List<object> arrayData = (List<object>)tempData["score"];

        //split up the array data
        foreach(IDictionary val in arrayData){
            if ((string)val["event"] == "note_on")
            {
                scoreData.Add(
                    new MusicData(
                        (long)val["tick"],
                        (int)(long)val["value"]
                    )
                );
            }

            if ((string)val["event"] == "set_tempo")
            {
                TimeManager.tempo = (int)(long)val["value"];
            }
        }

        //foreach (MusicData score in scoreData) {
        //    Debug.Log(score.tick);
        //}
	}
	
	// Update is called once per frame
	void Update () {

        foreach (MusicData tmp in scoreData)
        {
            if (!tmp.isCreated && tmp.tick < TimeManager.tick)
            {
                //譜面作成
                GameObject obj = Instantiate(scorePrefab);

                obj.transform.SetParent(transform);

                //obj.transform.parent = transform;

                int rand = Random.Range(0, ScorePositionXList.Length);
                float x = ScorePositionXList[rand];

                float y = tmp.tick * BoardMove.speed + 1000;

                obj.transform.localPosition = new Vector3(x, y, 0);

                obj.transform.localScale = Vector3.one;

                obj.transform.SetAsFirstSibling();

                obj.GetComponent<ScoreHandler>().touchBar = touchBars[rand];

                tmp.isCreated = true;

            }
        }


	}
}
