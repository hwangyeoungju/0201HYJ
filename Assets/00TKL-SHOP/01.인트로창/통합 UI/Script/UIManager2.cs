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
    public GameObject sixthUIPanel; // �߰��� ���� ��° UI �г�

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
        sixthUIPanel.SetActive(false); // �߰��� �ڵ�
    }

    public void ShowSecondUI()
    {
        secondUIPanel.SetActive(true);
        firstUIPanel.SetActive(false);
        thirdUIPanel.SetActive(false);
        fourthUIPanel.SetActive(false);
        fifthUIPanel.SetActive(false);
        sixthUIPanel.SetActive(false); // �߰��� �ڵ�
    }

    public void ShowThirdUI()
    {
        thirdUIPanel.SetActive(true);
        firstUIPanel.SetActive(false);
        secondUIPanel.SetActive(false);
        fourthUIPanel.SetActive(false);
        fifthUIPanel.SetActive(false);
        sixthUIPanel.SetActive(false); // �߰��� �ڵ�
    }

    public void ShowFourthUI()
    {
        fourthUIPanel.SetActive(true);
        firstUIPanel.SetActive(false);
        secondUIPanel.SetActive(false);
        thirdUIPanel.SetActive(false);
        fifthUIPanel.SetActive(false);
        sixthUIPanel.SetActive(false); // �߰��� �ڵ�
    }

    public void ShowFifthUI()
    {
        fifthUIPanel.SetActive(true);
        firstUIPanel.SetActive(false);
        secondUIPanel.SetActive(false);
        thirdUIPanel.SetActive(false);
        fourthUIPanel.SetActive(false);
        sixthUIPanel.SetActive(false); // �߰��� �ڵ�
    }

    public void ShowSixthUI() // �߰��� �Լ�
    {
        sixthUIPanel.SetActive(true);
        firstUIPanel.SetActive(false);
        secondUIPanel.SetActive(false);
        thirdUIPanel.SetActive(false);
        fourthUIPanel.SetActive(false);
        fifthUIPanel.SetActive(false);
    }
}
