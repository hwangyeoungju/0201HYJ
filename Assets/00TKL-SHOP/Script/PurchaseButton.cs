using UnityEngine;
using UnityEngine.UI;

public class PurchaseButton : MonoBehaviour
{
    public Button button; // ��ư ������Ʈ
    public GameObject imageObject; // ��ư ���� �ø� �̹��� ������Ʈ

    void Start()
    {
        // ������ �� �̹����� ����ϴ�.
        imageObject.SetActive(false);
    }

    public void ToggleImage()
    {
        // �̹����� Ȱ��ȭ ���¸� ����մϴ�.
        imageObject.SetActive(!imageObject.activeSelf);
    }
}
