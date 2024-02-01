using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject firstUIPanel; // 1��° UI �г�
    public GameObject secondUIPanel; // 2��° UI �г�
    public GameObject thirdUIPanel; // 3��° UI �г�

    // 1��° UI�� ǥ���ϴ� �Լ�
    public void ShowFirstUI()
    {
        firstUIPanel.SetActive(true);
        secondUIPanel.SetActive(false);
        thirdUIPanel.SetActive(false);
    }

    // 2��° UI�� ǥ���ϴ� �Լ�
    public void ShowSecondUI()
    {
        secondUIPanel.SetActive(true);
        firstUIPanel.SetActive(false);
        thirdUIPanel.SetActive(false);
    }

    // 3��° UI�� ǥ���ϴ� �Լ�
    public void ShowThirdUI()
    {
        thirdUIPanel.SetActive(true);
        firstUIPanel.SetActive(false);
        secondUIPanel.SetActive(false);
    }
}
