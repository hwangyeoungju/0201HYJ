using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGrid : MonoBehaviour
{
    public Button[] buttons; // 인스펙터에서 할당
    public GameObject[] imageObjects; // 누를 때 활성화할 이미지 오브젝트들
    private int currentIndex = 0; // 현재 이미지 오브젝트 인덱스

    void Start()
    {
        // 모든 버튼에 대해 리스너를 추가
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => AssignImageObjectToButton(button));
        }

        // 시작 시 모든 이미지 오브젝트를 비활성화
        foreach (GameObject imageObject in imageObjects)
        {
            imageObject.SetActive(false);
        }
    }

    void AssignImageObjectToButton(Button button)
    {
        if (currentIndex < imageObjects.Length)
        {
            // 현재 인덱스의 이미지 오브젝트를 활성화
            imageObjects[currentIndex].SetActive(true);
            currentIndex++; // 인덱스 증가
        }
    }
}