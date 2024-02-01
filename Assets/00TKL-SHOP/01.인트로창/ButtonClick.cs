using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public Button yourButton; // �Ҵ��� ��ư
    public Sprite newImage; // ��ü�� �� �̹���
    private bool isButtonPressed = false; // ��ư ����

    void Start()
    {
        yourButton.onClick.AddListener(ChangeButtonState);
    }

    void ChangeButtonState()
    {
        isButtonPressed = !isButtonPressed; // ��ư ���� ����
        yourButton.image.sprite = isButtonPressed ? newImage : yourButton.image.sprite; // �̹��� ��ü
    }
}