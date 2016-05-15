using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ComboHandler : MonoBehaviour {

    public Text myText;

    void Start()
    {
        GameData.onUpdated += setMaxCombo;
    }

    void setMaxCombo()
    {
        myText.text = GameData.MaxCombo.ToString("000");
    }

}
