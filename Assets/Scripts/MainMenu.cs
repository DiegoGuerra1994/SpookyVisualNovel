﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private bool waitForAnimation = false;
    public Animator startGamePanel;
    public TextMeshProUGUI menuText;
    public MainMenuButton enterbutton;
    public MainMenuButton loadButton;

    private void Start()
    {
        AudioClip clip = Resources.Load("Audio/Music/music_title") as AudioClip;
        AudioManager.instance.PlaySong(clip);
    }

    private IEnumerator WaitForFadeIn()
    {
        yield return new WaitForSeconds(2f);
        waitForAnimation = true;
    }

    private IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("VisualNovel");
    }

    public void ClickStartGame()
    {
        if (!waitForAnimation)
        {
            startGamePanel.SetTrigger("activate");
            NovelController.loadingGameSave = false;
            StartCoroutine(WaitForAnimation());
        }
    }

    public void ClickLoadGame()
    {
        if (!waitForAnimation)
        {
            startGamePanel.SetTrigger("activate");
            NovelController.loadingGameSave = true;
            StartCoroutine(WaitForAnimation());
        }
    }

    public void ButtonHover(MainMenuButton button)
    {
        menuText.text = button.menuText;
    }
    public void ButtonUnHover()
    {
        menuText.text = "";
    }
}
