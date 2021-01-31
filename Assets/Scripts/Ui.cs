using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ui : MonoBehaviour
{
   

    public string levelName;

    

    void Start()
    {
    
    }

    void Update()
    {
      
    }


    public void LoadScene()
    {
        SceneManager.LoadScene(levelName);
    }

    public void Quit()
    {
        Application.Quit();
    }


}