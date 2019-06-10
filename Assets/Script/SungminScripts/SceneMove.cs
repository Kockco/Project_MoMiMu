using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    void GameStart()
    {
        SceneManager.LoadScene("LobbyView");
        // ScemeManager.LoadScene(0~n);
    }

    void GameExit()
    {
        // 게임 꺼불기
    }
    

}