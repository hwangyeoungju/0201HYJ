using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectGrabUIHandler : MonoBehaviour
{
    public XRGrabInteractable grabbableObject; // ���� �� �ִ� ������Ʈ
    public GameObject grabUI; // Ȱ��ȭ�� UI ���

    void Start()
    {
        // ���� ���� �� UI ��Ȱ��ȭ
        if (grabUI != null)
            grabUI.SetActive(false);
    }

    void OnEnable()
    {
        grabbableObject.onSelectEntered.AddListener(ShowUI);
        grabbableObject.onSelectExited.AddListener(HideUI);
    }

    void OnDisable()
    {
        grabbableObject.onSelectEntered.RemoveListener(ShowUI);
        grabbableObject.onSelectExited.RemoveListener(HideUI);
    }

    private void ShowUI(XRBaseInteractor interactor)
    {
        grabUI.SetActive(true);
    }

    private void HideUI(XRBaseInteractor interactor)
    {
        grabUI.SetActive(false);
    }
}
