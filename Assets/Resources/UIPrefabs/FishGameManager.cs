using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FishGameManager : MonoBehaviour
{
    public List<GameObject> fishPrefabs;
    public GameObject hookPrefab;
    public Transform[] spawnPoints;
    public Dictionary<string, GameObject> fishUITemplates;
    public Text fishNameText;

    private GameObject currentFish;
    private GameObject currentHook;

    void Start()
    {
        fishUITemplates = new Dictionary<string, GameObject>();
        fishUITemplates["강준치"] = Resources.Load<GameObject>("UIPrefabs/강준치 Fishing UI");
        fishUITemplates["농어"] = Resources.Load<GameObject>("UIPrefabs/농어 Fishing UI");
        fishUITemplates["메기"] = Resources.Load<GameObject>("UIPrefabs/메기 Fishing UI");
        fishUITemplates["붕어"] = Resources.Load<GameObject>("UIPrefabs/붕어 Fishing UI");
        fishUITemplates["역돔"] = Resources.Load<GameObject>("UIPrefabs/역돔 Fishing UI");
        fishUITemplates["잉어"] = Resources.Load<GameObject>("UIPrefabs/잉어 Fishing UI");

        SpawnFish();
    }

    void SpawnFish()
    {
        Debug.Log("Fish Spawn Attempt");
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("Spawn points are not set.");
            return;
        }

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        if (fishPrefabs.Count == 0)
        {
            Debug.LogError("Fish prefabs list is empty.");
            return;
        }

        int randomFishIndex = Random.Range(0, fishPrefabs.Count);
        GameObject selectedFishPrefab = fishPrefabs[randomFishIndex];
        if (selectedFishPrefab == null)
        {
            Debug.LogError("Selected fish prefab is null.");
            return;
        }

        Debug.Log("Selected fish prefab: " + selectedFishPrefab.name);

        currentFish = Instantiate(selectedFishPrefab, spawnPoint.position, Quaternion.identity);
        if (currentFish == null)
        {
            Debug.LogError("Failed to instantiate fish prefab.");
            return;
        }

        string fishName = selectedFishPrefab.name;
        fishNameText.text = "잡은 물고기: " + fishName;

        if (fishUITemplates.ContainsKey(fishName))
        {
            GameObject fishUIPrefab = fishUITemplates[fishName];
            if (fishUIPrefab == null)
            {
                Debug.LogError("Fish UI prefab for " + fishName + " is null.");
            }
            else
            {
                GameObject fishUIInstance = Instantiate(fishUIPrefab, Vector3.zero, Quaternion.identity);
                if (fishUIInstance == null)
                {
                    Debug.LogError("Failed to instantiate fish UI prefab for " + fishName);
                }
                else
                {
                    fishUIInstance.transform.SetParent(GameObject.Find("Canvas").transform, false);
                }
            }
        }
        else
        {
            Debug.LogWarning("No UI template found for fish: " + fishName);
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Water") && currentHook != null)
        {
            SoundManager.instance.PlaySfx(SoundManager.Sfx.water);
            // 다음 물고기 생성을 위한 랜덤한 시간 지연
            float randomTime = Random.Range(5f, 10f);
            Invoke("SpawnFish", randomTime);
        }
    }


    public void AttachFishToHook()
    {
        if (currentHook != null)
        {
            // 훅에 물고기를 부착
            currentFish.transform.SetParent(currentHook.transform);
            currentFish.transform.localPosition = Vector3.zero;
        }
    }
}
