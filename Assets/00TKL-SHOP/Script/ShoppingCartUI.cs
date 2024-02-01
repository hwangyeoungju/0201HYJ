using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class ShoppingCartUI : MonoBehaviour
{
    public GameObject ShoppingCartPanel;
    private bool activeShoppingCart = false; // ���� īƮ UI�� Ȱ��ȭ ���¸� �����ϴ� ����
    void Start()
    {
        // ���� ���� �� ���� īƮ �г��� ��Ȱ��ȭ
        ShoppingCartPanel.SetActive(false);
    }

    void Update()
    {
        // Oculus Quest ������ ��Ʈ�ѷ��� A ��ư �Է��� Ȯ��
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            activeShoppingCart = !activeShoppingCart; // ���� īƮ UI ���� ���
            ShoppingCartPanel.SetActive(activeShoppingCart); // ���� īƮ �г� Ȱ��ȭ/��Ȱ��ȭ
        }
    }
}




