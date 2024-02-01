using UnityEngine;

public class FishController : MonoBehaviour
{
    public GameObject[] fishPrefabs; // ?迭?? ???? ?????? ??????
    public Transform fishPoint; //?????? ???????
    private bool isFishing = false;
    private bool hasCollided = false; // ?浹 ???? ??ο?

    void Start()
    {
        if (fishPoint == null)
        {
            return;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isFishing && collision.gameObject.CompareTag("Water") && !hasCollided)
        {
            SoundManager.instance.PlaySfx(SoundManager.Sfx.water);

            hasCollided = true;

            float randomTime = Random.Range(10f, 30f); // 10????? 30?? ?????? ???? ?ð?
            Invoke("CreateFish", randomTime);
        }
    }

    private void CreateFish()
    {
        int randomFishIndex = Random.Range(0, fishPrefabs.Length); // ?????? ?????? ?????? ????
        GameObject selectedFishPrefab = fishPrefabs[randomFishIndex];

        if (selectedFishPrefab != null)
        {
            GameObject fish = Instantiate(selectedFishPrefab, fishPoint.position, Quaternion.identity);

            if (fish != null)
            {
                fish.transform.parent = fishPoint;
            }

            // 컨트롤러에 진동을 주기
            OVRInput.SetControllerVibration(0.5f, 2.0f, OVRInput.Controller.RTouch); // 오른손 컨트롤러 진동
        }
    }
}
