﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TypeWriter : MonoBehaviour
{
    
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject closeButton;
    public GameObject panel;
    public bool _closedButton = false;
    
    
    void Start()
    {
        panel.GetComponent<Animator>().Play("PopUp");
        StartCoroutine(Type());

    }
    void Update()
    {
        if (textDisplay.text == sentences[index] && _closedButton == false)
        {
            closeButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        yield return new WaitForSeconds(2f);
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void ClosePanel()
    {
        textDisplay.enabled = false;
        panel.SetActive(false);
        _closedButton = true;
        closeButton.SetActive(false);
    }
    
    /*
    public void NextSentence()
        {
            closeButton.SetActive(false);
            if (index < sentences.Length - 1)
            {
                index++;
                textDisplay.text = "";
                StartCoroutine(Type());
            }
            else
            {
                textDisplay.text = "";
                closeButton.SetActive(false);
            }
        }
      
    public void FinishGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void StartToGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    */
}
