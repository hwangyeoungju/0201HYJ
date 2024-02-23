/*using UnityEngine;
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
}*/
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
        bool shouldEnable = !triggerButton.interactable;
        triggerButton.interactable = shouldEnable;

        // shouldEnable ���� ���� ������ �̹��� Ȱ��ȭ/��Ȱ��ȭ
        if (shouldEnable)
        {
            // ���� �̹����� ��Ȱ��ȭ�ϰ� �� �̹����� Ȱ��ȭ
            imageToDeactivate.SetActive(false);
            imageToActivate.SetActive(true);
        }
        else
        {
            // ����������, ��ư�� ��Ȱ��ȭ�� �� �̹��� ���¸� �ǵ������� �� �κ��� ���
            // imageToDeactivate.SetActive(true);
            // imageToActivate.SetActive(false);
        }
    }
}
