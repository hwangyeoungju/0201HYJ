using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject gameQuitPanel; // ���� ���� Ȯ�� UI �г�

    // ���� ���� Ȯ�� UI�� ǥ���ϴ� �Լ�
    public void ShowQuitGamePanel()
    {
        gameQuitPanel.SetActive(true);
    }

    // ���� ���� Ȯ�� UI�� ����� �Լ�
    public void HideQuitGamePanel()
    {
        gameQuitPanel.SetActive(false);
    }

    // ������ �����ϴ� �Լ�
    public void QuitGame()
    {
        // ���� �����Ͱ� �ƴ� ���� ���忡���� �۵��մϴ�.
        Application.Quit();

        // ���� �����Ϳ��� ������ ���� ���� �ڵ带 ����ϼ���.
        // UnityEditor.EditorApplication.isPlaying = false;
    }
}
