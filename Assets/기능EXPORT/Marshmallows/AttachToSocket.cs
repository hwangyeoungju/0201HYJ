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
            // �ʱ⿡ ResizeCollider�� ��Ȱ��ȭ
            resizeCollider.enabled = false;
        }
    }
    //�۵��� �Լ�ȣ��
    private void OnSelectEnter(XRBaseInteractable interactable)
    {
        ToggleMeshVisibility(interactable, false);

        ResizeCollider collider = interactable.GetComponent<ResizeCollider>();
        if (collider != null)
        {
            collider.ResizeColliderManually();
        }
    }
    //���� �Լ�ȣ��
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

    //�޽�����
    private void ToggleMeshVisibility(XRBaseInteractable interactable, bool isVisible = true)
    {
        if (interactable != null)
        {
            MeshRenderer meshRenderer = interactable.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.enabled = isVisible;
            }

            // ������ �κ�: isVisible ���� ���� Spare�� MeshRenderer�� ����
            if (spareMeshRenderer != null)
            {
                spareMeshRenderer.enabled = !isVisible;
            }
        }
    }
}
