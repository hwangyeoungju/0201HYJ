/*using UnityEngine;
using UnityEngine.UI;

public class ToggleImagesAndButtonState : MonoBehaviour
{
    public Button controlButton; // �̹����� �ٸ� ��ư�� ���¸� ������ ��ư
    public Button targetButton; // ���°� ����� ��ư

    public GameObject imageToDeactivate; // ��Ȱ��ȭ�� �̹��� ������Ʈ
    public GameObject imageToActivate; // Ȱ��ȭ�� �̹��� ������Ʈ

    void Start()
    {
        controlButton.onClick.AddListener(ToggleImagesAndTargetButton);
    }

    void ToggleImagesAndTargetButton()
    {
        // �̹��� ������Ʈ ���� ����
        bool isImageActive = imageToActivate.activeSelf;
        imageToDeactivate.SetActive(isImageActive);
        imageToActivate.SetActive(!isImageActive);

        // ��� ��ư(targetButton)�� Ŭ�� ���� ���� ����
        targetButton.interactable = !targetButton.interactable;
    }
}*/
using UnityEngine;
using UnityEngine.UI;

public class ToggleImagesAndButtonState : MonoBehaviour
{
    public Button controlButton; // �̹����� �ٸ� ��ư�� ���¸� ������ ��ư
    public Button targetButton; // ���°� ����� ��ư

    public GameObject imageToDeactivate; // ��Ȱ��ȭ�� �̹��� ������Ʈ
    public GameObject imageToActivate; // Ȱ��ȭ�� �̹��� ������Ʈ

    void Start()
    {
        // ó���� targetButton�� ��Ȱ��ȭ
        targetButton.interactable = false;

        // controlButton�� �̺�Ʈ ������ �߰�
        controlButton.onClick.AddListener(ToggleImagesAndEnableTargetButton);
    }

    void ToggleImagesAndEnableTargetButton()
    {
        // �̹��� ������Ʈ ���� ����
        bool isImageActive = imageToActivate.activeSelf;
        imageToDeactivate.SetActive(isImageActive);
        imageToActivate.SetActive(!isImageActive);

        // targetButton�� Ȱ��ȭ
        targetButton.interactable = true;
    }
}