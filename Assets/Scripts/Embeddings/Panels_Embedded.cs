using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Panels_Embedded : MonoBehaviour
{
    RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void right_button(float delay = 0f)
    {
        print(rectTransform.rect.width);
        rectTransform.DOMoveX(rectTransform.rect.width *-1/2, 0.3f).SetDelay(delay);
    }

    public void left_button(float delay = 0f) 
    {
        print(rectTransform.rect.width);
        rectTransform.DOMoveX(rectTransform.rect.width * 1/2, 0.3f).SetDelay(delay);
    }
}
