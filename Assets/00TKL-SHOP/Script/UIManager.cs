using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject firstUIPanel; // 1번째 UI 패널
    public GameObject secondUIPanel; // 2번째 UI 패널
    public GameObject thirdUIPanel; // 3번째 UI 패널

    // 1번째 UI를 표시하는 함수
    public void ShowFirstUI()
    {
        firstUIPanel.SetActive(true);
        secondUIPanel.SetActive(false);
        thirdUIPanel.SetActive(false);
    }

    // 2번째 UI를 표시하는 함수
    public void ShowSecondUI()
    {
        secondUIPanel.SetActive(true);
        firstUIPanel.SetActive(false);
        thirdUIPanel.SetActive(false);
    }

    // 3번째 UI를 표시하는 함수
    public void ShowThirdUI()
    {
        thirdUIPanel.SetActive(true);
        firstUIPanel.SetActive(false);
        secondUIPanel.SetActive(false);
    }
}
