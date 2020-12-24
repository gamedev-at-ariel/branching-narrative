using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cradle;
public class KillRobber : MonoBehaviour
{
    [SerializeField]
    private Story story;
    [SerializeField]
    private Animator robber_anim;
    bool animateOnce = false;

    private void Start()
    {
        robber_anim.enabled = false;
    }
    void Update()
    {
        if (story.Vars.GetMember("KillRobber").InnerValue != null)
        {
            if ((bool)story.Vars.GetMember("KillRobber").InnerValue)
            {
                robber_anim.enabled = true;
                robber_anim.Play("RobberDead");
            }
            if (animateOnce)
            {
                robber_anim.enabled = false;
            }
        }
    }

    public void AnimationEnded()
    {
        animateOnce = true;
    }
}
