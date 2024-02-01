using UnityEngine;

public class DisableAfterDelay : MonoBehaviour
{
    public float delay = 2.0f;

    void Start()
    {
        // Start �޼��忡�� Invoke�� ���� ��Ȱ��ȭ �Լ��� ȣ��
        Invoke("DisableCanvas", delay);
    }

    void DisableCanvas()
    {
        // GameObject�� ��Ȱ��ȭ�Ǿ��� �� ȣ��Ǵ� �޼���
        gameObject.SetActive(false);
    }
}