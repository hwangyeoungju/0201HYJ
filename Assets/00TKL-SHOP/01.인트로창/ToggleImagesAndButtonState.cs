using UnityEngine;
using UnityEngine.UI;

public class ToggleImagesOnButtonClick : MonoBehaviour
{
    public Button triggerButton; // ����ڰ� Ŭ���� ��ư
    public GameObject imageToDeactivate; // ��Ȱ��ȭ�� �̹��� ������Ʈ
    public GameObject imageToActivate; // Ȱ��ȭ�� �̹��� ������Ʈ

    public Button otherButton; // �ٸ� ��ư�� ���� ���� �߰�

    void Start()
    {
        triggerButton.onClick.AddListener(ToggleImages);
        otherButton.onClick.AddListener(EnableTriggerButtonClick); // �ٸ� ��ư�� Ŭ�� ������ �߰�
    }

    void ToggleImages()
    {
        // ���� �̹��� ��Ȱ��ȭ
        imageToDeactivate.SetActive(false);

        // �� �̹��� Ȱ��ȭ
        imageToActivate.SetActive(true);
    }

    void EnableTriggerButtonClick()
    {
        // triggerButton�� Ŭ�� ����� Ȱ��ȭ �Ǵ� ��Ȱ��ȭ
        triggerButton.interactable = !triggerButton.interactable;
    }
}