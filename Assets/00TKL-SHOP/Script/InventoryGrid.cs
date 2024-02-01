using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGrid : MonoBehaviour
{
    public Button[] buttons; // �ν����Ϳ��� �Ҵ�
    public GameObject[] imageObjects; // ���� �� Ȱ��ȭ�� �̹��� ������Ʈ��
    private int currentIndex = 0; // ���� �̹��� ������Ʈ �ε���

    void Start()
    {
        // ��� ��ư�� ���� �����ʸ� �߰�
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => AssignImageObjectToButton(button));
        }

        // ���� �� ��� �̹��� ������Ʈ�� ��Ȱ��ȭ
        foreach (GameObject imageObject in imageObjects)
        {
            imageObject.SetActive(false);
        }
    }

    void AssignImageObjectToButton(Button button)
    {
        if (currentIndex < imageObjects.Length)
        {
            // ���� �ε����� �̹��� ������Ʈ�� Ȱ��ȭ
            imageObjects[currentIndex].SetActive(true);
            currentIndex++; // �ε��� ����
        }
    }
}