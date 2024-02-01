using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class MainMenu1 : MonoBehaviour
{
    public GameObject MainMenuPanel;
    private bool activeMainMenu = false; // ���� �޴��� Ȱ��ȭ ���¸� �����ϴ� ����

    void Update()
    {
        // Oculus Quest ��Ʈ�ѷ��� �Է��� Ȯ��
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            activeMainMenu = !activeMainMenu; // ���� �޴� ���� ���
            MainMenuPanel.SetActive(activeMainMenu); // ���� �޴� �г� Ȱ��ȭ/��Ȱ��ȭ
        }
    }
}
