using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FishController : MonoBehaviour
{
    [System.Serializable]
    public class FishUIPair
    {
        public GameObject fishPrefab;
        public GameObject fishUIPrefab;
    }

    public List<FishUIPair> fishUIPairs;

    public GameObject fishingUIPrefab; // 프리팹을 할당하기 위한 변수
    public Transform fishingUIPosition; // 활성화될 위치

    public Transform fishPoint;
    public float fishingUIHeight = 1f;
    public float fishingUIDuration = 3f; // 유아이가 보여질 시간을 늘림

    private GameObject currentFish;
    private GameObject currentHook;
    private GameObject fishingUIInstance;
    private GameObject previousFishingUIInstance; // 이전에 생성된 유아이를 추적하기 위한 변수 추가

    private bool isFishing = false;
    private bool hasCollided = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!isFishing && collision.gameObject.CompareTag("Water") && !hasCollided)
        {
            SoundManager.instance.PlaySfx(SoundManager.Sfx.water);
            hasCollided = true;

            Vector3 collisionPoint = collision.contacts[0].point;
            Vector3 uiPosition = collisionPoint + Vector3.up * fishingUIHeight;
            ShowFishingUI(uiPosition);

            float randomTime = Random.Range(5f, 10f);
            Invoke("CreateFish", randomTime);
        }
    }

    private void CreateFish()
    {
        int randomFishIndex = Random.Range(0, fishUIPairs.Count);
        GameObject selectedFishPrefab = fishUIPairs[randomFishIndex].fishPrefab;
        GameObject selectedFishUIPrefab = fishUIPairs[randomFishIndex].fishUIPrefab;

        currentFish = Instantiate(selectedFishPrefab, fishPoint.position, Quaternion.identity, fishPoint);
        fishingUIInstance = Instantiate(selectedFishUIPrefab, fishingUIPosition.position, Quaternion.Euler(0f, 90f, 0f)); // 유아이를 90도 돌림

        if (previousFishingUIInstance != null)
        {
            Destroy(previousFishingUIInstance);
        }

        if (currentFish != null)
        {
            AttachFishToHook();
            OVRInput.SetControllerVibration(0.5f, 1.0f, OVRInput.Controller.RTouch);
            Debug.Log("Fishing UI Activated!"); // 유아이가 활성화되었음을 디버깅 로그로 출력
            Invoke("StartHidingFishingUI", fishingUIDuration);
        }
    }

    private void ShowFishingUI(Vector3 position)
    {
        if (fishingUIPrefab != null)
        {
            // 이전에 생성된 유아이를 삭제하고 새로운 유아이 생성
            if (previousFishingUIInstance != null)
            {
                Destroy(previousFishingUIInstance);
            }

            fishingUIInstance = Instantiate(fishingUIPrefab, position, Quaternion.Euler(0f, 90f, 0f));
            previousFishingUIInstance = fishingUIInstance;
        }
    }



    private void HideFishingUI()
    {
        // 이전에 생성된 유아이를 삭제
        if (previousFishingUIInstance != null)
        {
            Destroy(previousFishingUIInstance);
        }
        Debug.Log("Fishing UI Deactivated!"); // 유아이가 사라짐을 디버깅 로그로 출력
    }

    private void AttachFishToHook()
    {
        if (currentHook != null && currentFish != null)
        {
            currentFish.transform.SetParent(currentHook.transform);
            currentFish.transform.localPosition = Vector3.zero;
        }
    }

    private void StartHidingFishingUI()
    {
        HideFishingUI();
    }
}
