using UnityEngine;

public class Hanabi_PJH : MonoBehaviour
{
    // 활성화할 게임 오브젝트들을 저장할 배열
    public GameObject[] objectsToActivate;

    // 활성화 지속 시간
    public float activationDuration = 25f;

    // 충돌이 일어났을 때 호출되는 함수
    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트가 "Torch" 태그를 가지고 있는지 확인
        if (collision.gameObject.CompareTag("Torch"))
        {
            // 활성화할 게임 오브젝트 배열이 지정되어 있는지 확인
            if (objectsToActivate != null && objectsToActivate.Length > 0)
            {
                // 배열에 있는 모든 오브젝트를 활성화하고 일정 시간 후에 비활성화할 함수를 호출
                foreach (GameObject obj in objectsToActivate)
                {
                    if (obj != null)
                    {
                        obj.SetActive(true);
                    }
                }
                Invoke("DeactivateObjects", activationDuration);
            }
        }
    }

    // 게임 오브젝트들을 비활성화하는 함수
    private void DeactivateObjects()
    {
        // 활성화할 게임 오브젝트 배열이 지정되어 있는지 확인하고 모두 비활성화
        if (objectsToActivate != null && objectsToActivate.Length > 0)
        {
            foreach (GameObject obj in objectsToActivate)
            {
                if (obj != null)
                {
                    obj.SetActive(false);
                }
            }
        }
    }
}
