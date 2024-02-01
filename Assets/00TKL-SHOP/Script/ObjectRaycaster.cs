using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRaycaster : MonoBehaviour
{
    public Transform rayOrigin; // ���̸� �߻��� ��ġ (��: ī�޶� �Ǵ� VR ��Ʈ�ѷ�)
    public GameObject uiPanel; // Ȱ��ȭ/��Ȱ��ȭ�� UI �г�

    private GameObject lastHitObject = null;

    void Update()
    {
        RaycastHit hit;

        // ���̸� �߻��ϰ� ����� �����ɴϴ�.
        if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out hit))
        {
            // �浹�� ������Ʈ�� UI�� ����� �ϴ� ������Ʈ���� Ȯ���մϴ�.
            if (hit.transform.gameObject.CompareTag("InteractiveObject"))
            {
                if (lastHitObject != hit.transform.gameObject)
                {
                    // ������ �浹�� ������Ʈ�� �ٸ��� UI�� Ȱ��ȭ�մϴ�.
                    uiPanel.SetActive(true);
                    lastHitObject = hit.transform.gameObject;
                }
            }
        }
        else
        {
            // ���̰� �ƹ��͵� �������� �ʾ��� �� UI�� ��Ȱ��ȭ�մϴ�.
            if (uiPanel.activeSelf)
            {
                uiPanel.SetActive(false);
            }
            lastHitObject = null;
        }
    }
}