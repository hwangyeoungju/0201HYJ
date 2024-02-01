using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // �ν����� â���� ��ġ�� ������ ����
    public Transform targetTransform;

    private void Awake()
    {
        // �� �̵� ���� �� ��ü�� �ı����� �ʵ��� ����
        DontDestroyOnLoad(gameObject);
    }

    // ���� ������ �̵��� �� ȣ��Ǵ� �̺�Ʈ
    private void OnLevelWasLoaded(int level)
    {
        // �� �̵� �Ŀ� ��ġ�� ����
        if (targetTransform != null)
        {
            transform.position = targetTransform.position;
            transform.rotation = targetTransform.rotation;
            transform.localScale = targetTransform.localScale;
        }
        else
        {
            Debug.LogWarning("Target transform is not assigned in the inspector.");
        }
    }
}
