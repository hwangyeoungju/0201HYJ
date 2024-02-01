using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager1 : MonoBehaviour
{
    public GameObject firstUIPanel;
    public GameObject secondUIPanel;
    public GameObject thirdUIPanel;
    public GameObject fourthUIPanel;

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
    }

    public void ShowSecondUI()
    {
        secondUIPanel.SetActive(true);
        firstUIPanel.SetActive(false);
        thirdUIPanel.SetActive(false);
        fourthUIPanel.SetActive(false);
    }

    public void ShowThirdUI()
    {
        thirdUIPanel.SetActive(true);
        firstUIPanel.SetActive(false);
        secondUIPanel.SetActive(false);
        fourthUIPanel.SetActive(false);
    }

    public void ShowFourthUI()
    {
        fourthUIPanel.SetActive(true);
        firstUIPanel.SetActive(false);
        secondUIPanel.SetActive(false);
        thirdUIPanel.SetActive(false);
        StartCoroutine(ActivateFirstUIAfterSeconds(5));
    }

    // 4번째 UI가 활성화된 후 5초가 지나면 첫 번째 UI를 활성화하는 코루틴
    IEnumerator ActivateFirstUIAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ShowFirstUI();
    }
}
