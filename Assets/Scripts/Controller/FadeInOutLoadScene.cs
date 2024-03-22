using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInOutLoadScene : MonoBehaviour
{
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Fade");
    }

    IEnumerator Fade()
    {
        float startAlpha = 1.0f;
        while (startAlpha > 0.0f)
        {
            startAlpha -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, startAlpha);
        }
    }

}
