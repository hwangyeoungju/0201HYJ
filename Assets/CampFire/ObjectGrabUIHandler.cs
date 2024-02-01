using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectGrabUIHandler : MonoBehaviour
{
    public XRGrabInteractable grabbableObject; // 잡을 수 있는 오브젝트
    public GameObject grabUI; // 활성화할 UI 요소

    void Start()
    {
        // 게임 시작 시 UI 비활성화
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
