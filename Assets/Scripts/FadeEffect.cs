using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    public Image image;

    void Start()
    {
        if(null != image)
            StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        Color Alpha = image.color;
        while(0 < Alpha.a)
        {
            Alpha.a -= 0.01f;
            image.color = Alpha;

            yield return null;
        }

        Alpha.a = 0f;
        image.color = Alpha;
    }

    private IEnumerator FadeOut()
    {
        Color Alpha = image.color;
        while (1f > Alpha.a)
        {
            Alpha.a -= 0.01f;
            image.color = Alpha;

            yield return null;
        }
        Alpha.a = 1f;
        image.color = Alpha;
    }
}
