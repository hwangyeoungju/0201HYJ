using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // 인스펙터 창에서 위치를 지정할 변수
    public Transform targetTransform;

    private void Awake()
    {
        // 씬 이동 전에 이 객체를 파괴하지 않도록 설정
        DontDestroyOnLoad(gameObject);
    }

    // 다음 씬으로 이동할 때 호출되는 이벤트
    private void OnLevelWasLoaded(int level)
    {
        // 씬 이동 후에 위치를 설정
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
