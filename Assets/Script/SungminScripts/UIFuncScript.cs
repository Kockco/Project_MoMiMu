using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIFuncScript : MonoBehaviour
{
    private bool pauseState = false;

    [SerializeField]
    private GameObject homeButton;
    [SerializeField]
    private GameObject PausePanel;
    [SerializeField]
    private GameObject hintPanel;

    [SerializeField]
    private Animation[] uiAnime;

    public void OnHint()
    {
        if (hintPanel.activeInHierarchy)
        {
            hintPanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            hintPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void OnReStart()
    {
        SceneManager.LoadScene(3);
    }

    public void OnOffPause()
    {
        pauseState = !pauseState;

        if (pauseState)
        {
            homeButton.SetActive(false);
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            homeButton.SetActive(true);
            PausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void BackScene()
    {
        SceneManager.LoadScene(1);
    }

    public void GameClearAnime()
    {
        for (int i = 0; i < uiAnime.Length; i++)
            uiAnime[i].Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnOffPause();
    }
}