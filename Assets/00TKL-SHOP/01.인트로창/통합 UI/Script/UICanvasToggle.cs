using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR; // Oculus VR�� OVRInput�� ����ϱ� ���� �߰�
using UnityEngine.XR;

public class UICanvasToggle : MonoBehaviour
{
    public Canvas uiCanvas; // UI ĵ������ �����ϱ� ���� ����

    void Update()
    {
        // Oculus Quest ������ ��Ʈ�ѷ��� A ��ư �Է��� Ȯ��
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            // UI ĵ������ Ȱ��ȭ/��Ȱ��ȭ ���¸� ���
            uiCanvas.enabled = !uiCanvas.enabled;
        }
    }
}