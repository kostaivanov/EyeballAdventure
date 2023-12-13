using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimationController : MonoBehaviour
{
    private Renderer myRenderer;
    private Animator myAnimator;
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        myAnimator = GetComponent<Animator>();
        myAnimator.enabled = false;
    }

    void Update()
    {
        if (myRenderer.isVisible)
        {
            myAnimator.enabled = true;
        }
        else
        {
            myAnimator.enabled = false;
        }
    }
}
