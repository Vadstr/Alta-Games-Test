using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject TapToPlay;
    [SerializeField] private Text TextPanel;
    [SerializeField] private Button RetryPanel;

    private void OnEnable()
    {
        EventSystem.WinGameEvent += Win;
        EventSystem.LoseGameEvent += Lose;
        EventSystem.StartGameEvent += StartPlay;
        RetryPanel.onClick.AddListener(Restart);
    }

    private void Start()
    {
        TapToPlay.SetActive(true);
        TextPanel.gameObject.SetActive(false);
        RetryPanel.gameObject.SetActive(false);
    }

    private void StartPlay()
    {
        TapToPlay.SetActive(false);
    }

    private void Win()
    {
        TextPanel.text = "Win";
        TextPanel.gameObject.SetActive(true);
        RetryPanel.gameObject.SetActive(true);
    }
    
    private void Lose()
    {
        TextPanel.text = "Lose";
        TextPanel.gameObject.SetActive(true);
        RetryPanel.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    
    private void OnDisable()
    {
        EventSystem.WinGameEvent -= Win;
        EventSystem.LoseGameEvent -= Lose;
        EventSystem.StartGameEvent -= StartPlay;
        RetryPanel.onClick.RemoveListener(Restart);
    }
}
