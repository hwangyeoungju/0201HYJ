using UnityEngine;

public class kayakObjectMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f; // ������ �ӵ�
    public float moveDistance = 1.0f; // ������ �Ÿ�

    private Vector3 originalPosition;
    private float direction = 1.0f;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        // ������Ʈ�� ���Ʒ��� �̵�
        float newPosition = Mathf.PingPong(Time.time * moveSpeed, moveDistance);
        transform.position = originalPosition + new Vector3(0, newPosition, 0) * direction;
    }
}
