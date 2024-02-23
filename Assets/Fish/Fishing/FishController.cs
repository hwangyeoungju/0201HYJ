using UnityEngine;
using UnityEngine.UI;

public class FishController : MonoBehaviour
{
    public GameObject[] fishPrefabs;
    public Transform fishPoint;
    public GameObject fishingUIPrefab; // UI Prefab을 저장할 변수 추가
    public float fishingUIHeight = 1f; // UI가 표시될 높이 변수 추가
    private GameObject fishingUIInstance; // 생성된 UI 인스턴스를 저장할 변수 추가
    private bool isFishing = false;
    private bool hasCollided = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!isFishing && collision.gameObject.CompareTag("Water") && !hasCollided)
        {
            SoundManager.instance.PlaySfx(SoundManager.Sfx.water);

            hasCollided = true;

            // 물과 충돌 시 UI를 표시할 위치를 기록
            Vector3 collisionPoint = collision.contacts[0].point;

            // 충돌 지점에 일정 높이를 더한 위치에 UI를 배치
            Vector3 uiPosition = collisionPoint + Vector3.up * fishingUIHeight;

            // 충돌 지점에 UI를 배치하고 회전하여 y축으로 90도 돌림
            ShowFishingUI(uiPosition);

            float randomTime = Random.Range(5f, 10f);
            Invoke("CreateFish", randomTime);
        }
    }

    private void CreateFish()
    {
        Debug.Log("fishing");
        int randomFishIndex = Random.Range(0, fishPrefabs.Length);
        GameObject selectedFishPrefab = fishPrefabs[randomFishIndex];
        GameObject fish = Instantiate(selectedFishPrefab, fishPoint.position, Quaternion.identity);
        if (fish != null)
        {
            fish.transform.parent = fishPoint;
        }
        // 컨트롤러에 진동을 주기
        OVRInput.SetControllerVibration(0.5f, 1.0f, OVRInput.Controller.RTouch);

        // 유아이가 생성된 후 5초 후에 사라지도록 호출
        Invoke("HideFishingUI", 5f);
    }

    private void ShowFishingUI(Vector3 position)
    {
        if (fishingUIPrefab != null)
        {
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
