using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager2 : MonoBehaviour
{
    public GameObject firstUIPanel;
    public GameObject secondUIPanel;
    public GameObject thirdUIPanel;
    public GameObject fourthUIPanel;
    public GameObject fifthUIPanel;
    public GameObject sixthUIPanel; // 추가된 여섯 번째 UI 패널

    void Start()
    {
        ShowFirstUI();
    }

    public void ShowFirstUI()
    {
        firstUIPanel.SetActive(true);
        secondUIPanel.SetActive(false);
        thirdUIPanel.SetActive(false);
        fourthUIPanel.SetActive(false);
        fifthUIPanel.SetActive(false);
        sixthUIPanel.SetActive(false); // 추가된 코드
    }

    public void ShowSecondUI()
    {
        secondUIPanel.SetActive(true);
        firstUIPanel.SetActive(false);
        thirdUIPanel.SetActive(false);
        fourthUIPanel.SetActive(false);
        fifthUIPanel.SetActive(false);
        sixthUIPanel.SetActive(false); // 추가된 코드
    }

    public void ShowThirdUI()
    {
        thirdUIPanel.SetActive(true);
        firstUIPanel.SetActive(false);
        secondUIPanel.SetActive(false);
        fourthUIPanel.SetActive(false);
        fifthUIPanel.SetActive(false);
        sixthUIPanel.SetActive(false); // 추가된 코드
    }

    public void ShowFourthUI()
    {
        fourthUIPanel.SetActive(true);
        firstUIPanel.SetActive(false);
        secondUIPanel.SetActive(false);
        thirdUIPanel.SetActive(false);
        fifthUIPanel.SetActive(false);
        sixthUIPanel.SetActive(false); // 추가된 코드
    }

    public void ShowFifthUI()
    {
        fifthUIPanel.SetActive(true);
        firstUIPanel.SetActive(false);
        secondUIPanel.SetActive(false);
        thirdUIPanel.SetActive(false);
        fourthUIPanel.SetActive(false);
        sixthUIPanel.SetActive(false); // 추가된 코드
    }

    public void ShowSixthUI() // 추가된 함수
    {
        sixthUIPanel.SetActive(true);
        firstUIPanel.SetActive(false);
        secondUIPanel.SetActive(false);
        thirdUIPanel.SetActive(false);
        fourthUIPanel.SetActive(false);
        fifthUIPanel.SetActive(false);
    }
}
