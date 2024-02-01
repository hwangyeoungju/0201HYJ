using UnityEngine;

public class DisableAfterDelay : MonoBehaviour
{
    public float delay = 2.0f;

    void Start()
    {
        // Start 메서드에서 Invoke를 통해 비활성화 함수를 호출
        Invoke("DisableCanvas", delay);
    }

    void DisableCanvas()
    {
        // GameObject가 비활성화되었을 때 호출되는 메서드
        gameObject.SetActive(false);
    }
}