using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    AudioSource source;

    public GameObject GameClear;
    public GameObject GameOver;

    public AudioClip onMiss;

    public AudioClip onGameClear;
    public AudioClip onGameOver;

    [SerializeField]
    ScoreCreator score;

    bool enabled = true;
    bool gameStarted = false;

	// Use this for initialization
	void Start () {
        source = gameObject.GetComponent<AudioSource>();
        source.Play();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(source.timeSamples * 60 / 480);
        if (source != null && !gameStarted && source.time > 0) {
            gameStarted = true;
            score.enabled = true;
            Debug.LogError("Playing");
        }
        if (!source.isPlaying && enabled)
        {
            if (GameData.GagePoint >= 75)
            {
                GameClear.SetActive(true);
                source.PlayOneShot(onGameClear);
            }
            else
            {
                source.PlayOneShot(onGameOver);
                GameOver.SetActive(true);
            }
            enabled = false;
        }
	}
}
