using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject uiElement; // ��Ȱ��ȭ�Ϸ��� UI ���
    public Button yourButton; // ��ư

    void Start()
    {
        yourButton.onClick.AddListener(ShowUI); // ��ư�� �̺�Ʈ ������ �߰�
    }

    void ShowUI()
    {
        uiElement.SetActive(true); // UI ��� Ȱ��ȭ
        StartCoroutine(DisableUIAfterSeconds(5)); // 5�� �Ŀ� UI ��� ��Ȱ��ȭ
    }

    IEnumerator DisableUIAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds); // ������ �ð�(��) ���� ���
        uiElement.SetActive(false); // UI ��� ��Ȱ��ȭ
    }
}
