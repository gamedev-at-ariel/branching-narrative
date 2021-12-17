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

    void Start() {
        Scoretext.text = score.ToString();
    }

    void Update() {
        if (story.Vars.GetMember("Score").InnerValue != null){
            score = (int)story.Vars.GetMember("Score").InnerValue;
            Scoretext.text = score.ToString();
        }
    }
}
