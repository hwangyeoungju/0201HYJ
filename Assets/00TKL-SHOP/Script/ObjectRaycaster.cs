using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRaycaster : MonoBehaviour
{
    public Transform rayOrigin; // 레이를 발사할 위치 (예: 카메라 또는 VR 컨트롤러)
    public GameObject uiPanel; // 활성화/비활성화할 UI 패널

    private GameObject lastHitObject = null;

    void Update()
    {
        RaycastHit hit;

        // 레이를 발사하고 결과를 가져옵니다.
        if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out hit))
        {
            // 충돌한 오브젝트가 UI를 띄워야 하는 오브젝트인지 확인합니다.
            if (hit.transform.gameObject.CompareTag("InteractiveObject"))
            {
                if (lastHitObject != hit.transform.gameObject)
                {
                    // 이전에 충돌한 오브젝트가 다르면 UI를 활성화합니다.
                    uiPanel.SetActive(true);
                    lastHitObject = hit.transform.gameObject;
                }
            }
        }
        else
        {
            // 레이가 아무것도 감지하지 않았을 때 UI를 비활성화합니다.
            if (uiPanel.activeSelf)
            {
                uiPanel.SetActive(false);
            }
            lastHitObject = null;
        }
    }
}