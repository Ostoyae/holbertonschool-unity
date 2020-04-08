﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    [SerializeField] private Text finalText;
    private Button _nextButton;


    private void Awake()
    {        
        gameObject.SetActive(true);
    }

    private void Start()
    {
        _nextButton = gameObject.GetComponentsInChildren<Button>().Where((button => button.name == "NextButton")).First();
        var cur = SceneManager.GetActiveScene().buildIndex;
        if (SceneManager.sceneCountInBuildSettings - 1 == cur)
            _nextButton.gameObject.SetActive(false);
    }
    
    

    public void DisplayWinMenu(string time)
    {
        gameObject.SetActive(true);
        finalText.text = time;

    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Next()
    {
        var cur = SceneManager.GetActiveScene().buildIndex;
        if (SceneManager.sceneCountInBuildSettings - 1 > cur)
            SceneManager.LoadScene(cur + 1);
        else
            SceneManager.LoadScene(0);
            
    }
}
