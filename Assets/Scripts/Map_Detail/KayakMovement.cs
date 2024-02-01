using UnityEngine;

public class kayakObjectMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f; // 움직임 속도
    public float moveDistance = 1.0f; // 움직일 거리

    private Vector3 originalPosition;
    private float direction = 1.0f;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        // 오브젝트를 위아래로 이동
        float newPosition = Mathf.PingPong(Time.time * moveSpeed, moveDistance);
        transform.position = originalPosition + new Vector3(0, newPosition, 0) * direction;
    }
}
