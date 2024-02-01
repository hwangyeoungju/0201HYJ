using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketController : MonoBehaviour
{
    public GameObject[] basketButtons; // ��ٱ��� ��ư �迭
    private int currentButtonIndex = 0; // ���� Ȱ��ȭ�� ��ư�� �ε���

    // ��� ��ư �̺�Ʈ �ڵ鷯
    public void AddItemToBasket(Sprite itemSprite)
    {
        if (currentButtonIndex < basketButtons.Length)
        {
            // ���� �ε����� ��ư���� �̹����� �Ҵ��ϰ� Ȱ��ȭ�մϴ�.
            GameObject button = basketButtons[currentButtonIndex];
            button.GetComponent<Image>().sprite = itemSprite;
            button.SetActive(true);

            currentButtonIndex++; // ���� ��ư�� ���� �ε����� ������ŵ�ϴ�.
        }
        else
        {
            // ��� ��ư�� �̹� Ȱ��ȭ�Ǿ��ٸ�, �߰� ó���� �����մϴ�. (��: ��� �޽��� ��)
        }
    }
}