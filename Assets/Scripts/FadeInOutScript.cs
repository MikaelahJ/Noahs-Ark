using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private RawImage image;

    private void Start()
    {
        image.enabled = false;
    }

    public void FadeIn()
    {
        image.enabled = true;
        animator.SetTrigger("FadeIn");
    }

    public void FadeInFinished()
    {
        image.enabled = false;
    }

    public void FadeOut()
    {
        image.enabled = true;
        animator.SetTrigger("FadeOut");
    }
    
    public void FadeOutFinished()
    {
       // GameManager.instance.ChangeScene();
    }

}
