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
    private Animation[] uiAnime;

    public void OnHint()
    {

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

    public void BackScene()
    {
        SceneManager.LoadScene(2);
    }

    public void GameClearAnime()
    {
        Debug.Log("OnOffPause");

        for (int i = 0; i < uiAnime.Length; i++)
            uiAnime[i].Play();
    }
}