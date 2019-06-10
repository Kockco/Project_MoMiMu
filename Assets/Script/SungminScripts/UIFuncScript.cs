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
        Debug.Log("OnOffPause");

        pauseState = !pauseState;

        if (pauseState)
        {
            homeButton.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            homeButton.SetActive(true);
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