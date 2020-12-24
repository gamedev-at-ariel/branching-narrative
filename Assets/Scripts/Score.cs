using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cradle;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text Scoretext;
    [SerializeField]
    private Story story;
    int score = 0;
    int StolenMoney = 0;
    // Start is called before the first frame update
    void Start()
    {
        Scoretext.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (story.Vars.GetMember("Score").InnerValue != null){
            score = (int)story.Vars.GetMember("Score").InnerValue;
            string myScore = score.ToString();
            Scoretext.text = myScore;
        }
    }
}
