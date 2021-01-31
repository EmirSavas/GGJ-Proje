using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutScene : MonoBehaviour
{

    #region Singleton

    public static FadeOutScene instance;

    public void Awake()
    {
        instance = this;
    }

    #endregion
    
    
    public GameObject fadeOutImage;
    
    public int fadeSpeed = 5;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    #region FadeOut

    public IEnumerable FadeOut(bool fadeOutBlack = true)
    {
        Color color = fadeOutImage.GetComponent<Image>().color;
        float fadeAmount;
        Debug.Log("Başladı");

        if (fadeOutBlack)
        {
            Debug.Log("Başladı2");
            while (fadeOutImage.GetComponent<Image>().color.a <= 0)
            {
                Debug.Log("Başladı3");
                fadeAmount = color.a + (fadeSpeed * Time.deltaTime);

                color = new Color(color.b, color.g, color.r, fadeAmount);
                fadeOutImage.GetComponent<Image>().color = color;
                yield return null;
            }
            
        }
        
        else
        {
            while (fadeOutImage.GetComponent<Image>().color.a >= 1)
            {
                fadeAmount = color.a + (fadeSpeed * Time.deltaTime);

                color = new Color(color.b, color.g, color.r, fadeAmount);
                fadeOutImage.GetComponent<Image>().color = color;
                yield return null;
            }
        }
    }

    #endregion
    
}
