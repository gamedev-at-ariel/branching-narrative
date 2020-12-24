using Cradle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    [SerializeField]
    private string startPassage;
    private string currentPassage;
    [SerializeField]
    private Story story;
    bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        currentPassage = startPassage;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            currentPassage = story.CurrentPassage.Name;
        }
    }
    public void GoToPassage()
    {
        story.GoTo(currentPassage);
    }
    public void Active()
    {
        active = true;
    }
    public void ShotDown()
    {
        active = false;
    }
}
