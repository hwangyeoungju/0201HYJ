using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject gameQuitPanel; // 게임 종료 확인 UI 패널

    // 게임 종료 확인 UI를 표시하는 함수
    public void ShowQuitGamePanel()
    {
        gameQuitPanel.SetActive(true);
    }

    // 게임 종료 확인 UI를 숨기는 함수
    public void HideQuitGamePanel()
    {
        gameQuitPanel.SetActive(false);
    }

    // 게임을 종료하는 함수
    public void QuitGame()
    {
        // 게임 에디터가 아닌 실제 빌드에서만 작동합니다.
        Application.Quit();

        // 게임 에디터에서 실행할 때는 다음 코드를 사용하세요.
        // UnityEditor.EditorApplication.isPlaying = false;
    }
}
