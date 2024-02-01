using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AttachToSocket : MonoBehaviour
{
    private XRSocketInteractor socketInteractor;
    private MeshRenderer spareMeshRenderer;
    private ResizeCollider resizeCollider;

    private void Start()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();

        if (socketInteractor == null)
        {
           // Debug.LogError("XRSocketInteractor not found!");
            return;
        }

        socketInteractor.onSelectEntered.AddListener(OnSelectEnter);
        socketInteractor.onSelectExited.AddListener(OnSelectExit);

        spareMeshRenderer = GetComponent<MeshRenderer>();
        resizeCollider = GetComponentInChildren<ResizeCollider>();
        if (resizeCollider != null)
        {
            // 초기에 ResizeCollider를 비활성화
            resizeCollider.enabled = false;
        }
    }
    //작동시 함수호출
    private void OnSelectEnter(XRBaseInteractable interactable)
    {
        ToggleMeshVisibility(interactable, false);

        ResizeCollider collider = interactable.GetComponent<ResizeCollider>();
        if (collider != null)
        {
            collider.ResizeColliderManually();
        }
    }
    //끌때 함수호출
    private void OnSelectExit(XRBaseInteractable interactable)
    {
        ToggleMeshVisibility(interactable);

        ResizeCollider collider = interactable.GetComponent<ResizeCollider>();
        // if (resizeCollider != null)
        if (collider != null)
        {
            // resizeCollider.enabled = false;
            collider.ChangeColliderSizeToDefault();
        }
    }

    //메쉬끄기
    private void ToggleMeshVisibility(XRBaseInteractable interactable, bool isVisible = true)
    {
        if (interactable != null)
        {
            MeshRenderer meshRenderer = interactable.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.enabled = isVisible;
            }

            // 수정된 부분: isVisible 값에 따라 Spare의 MeshRenderer도 조작
            if (spareMeshRenderer != null)
            {
                spareMeshRenderer.enabled = !isVisible;
            }
        }
    }
}
