using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    public Image m_Image;

    void Start()
    {
        if(null != m_Image)
            StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeIn()
    {
        Color Alpha = m_Image.color;
        while(0 < Alpha.a)
        {
            Alpha.a -= 0.01f;
            m_Image.color = Alpha;

            yield return null;
        }

        Alpha.a = 0f;
        m_Image.color = Alpha;
    }

    IEnumerator FadeOut()
    {
        Color Alpha = m_Image.color;
        while (1f > Alpha.a)
        {
            Alpha.a -= 0.01f;
            m_Image.color = Alpha;

            yield return null;
        }
        Alpha.a = 1f;
        m_Image.color = Alpha;
    }
}
