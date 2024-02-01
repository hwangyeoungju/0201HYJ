using UnityEngine;

public class UICreateObject : MonoBehaviour
{
    public GameObject[] objectsToCreate; // 생성할 오브젝트 배열
    public Transform spawnLocation1; // 첫 번째 오브젝트가 생성될 위치
    public Transform spawnLocation2; // 두 번째 오브젝트가 생성될 위치

    // UI 요소를 누를 때 호출되는 함수
    public void OnUIButtonClicked()
    {
        // UI 요소가 활성화되었을 때, 배열의 첫 번째 오브젝트를 첫 번째 위치에, 두 번째 오브젝트를 두 번째 위치에 생성
        if (objectsToCreate.Length >= 2)
        {
            Instantiate(objectsToCreate[0], spawnLocation1.position, Quaternion.identity);
            Instantiate(objectsToCreate[1], spawnLocation2.position, Quaternion.identity);
        }
        else
        {
        }
    }
}


