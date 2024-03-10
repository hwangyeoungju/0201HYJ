using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFishUI : MonoBehaviour
{
    
    public GameObject fishingUIPrefab; // UI Prefab을 저장할 변수 추가
    public float fishingUIHeight = 1f; // UI가 표시될 높이 변수 추가
    private GameObject fishingUIInstance; // 생성된 UI 인스턴스를 저장할 변수 추가
    private bool isFishing = false;
    private bool hasCollided = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!isFishing && collision.gameObject.CompareTag("Hook") && !hasCollided)
        {


            hasCollided = true;

            // 물과 충돌 시 UI를 표시할 위치를 기록
            Vector3 collisionPoint = collision.contacts[0].point;

            // 충돌 지점에 일정 높이를 더한 위치에 UI를 배치
            Vector3 uiPosition = collisionPoint + Vector3.up * fishingUIHeight;

            // 충돌 지점에 UI를 배치하고 회전하여 y축으로 90도 돌림
            ShowFishingUI(uiPosition);

        }
    }

    private void ShowFishingUI(Vector3 position)
    {
        if (fishingUIPrefab != null)
        {
            Debug.Log("ff");
            // UI Prefab을 생성하여 지정된 위치에 배치
            fishingUIInstance = Instantiate(fishingUIPrefab, position, Quaternion.Euler(0f, 90f, 0f));
        }
    }

    private void HideFishingUI()
    {
        if (fishingUIInstance != null)
        {
            // 생성된 UI를 제거
            Destroy(fishingUIInstance);
        }
    }
}
