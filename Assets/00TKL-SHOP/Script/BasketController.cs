using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketController : MonoBehaviour
{
    public GameObject[] basketButtons; // 장바구니 버튼 배열
    private int currentButtonIndex = 0; // 현재 활성화할 버튼의 인덱스

    // 담기 버튼 이벤트 핸들러
    public void AddItemToBasket(Sprite itemSprite)
    {
        if (currentButtonIndex < basketButtons.Length)
        {
            // 현재 인덱스의 버튼에만 이미지를 할당하고 활성화합니다.
            GameObject button = basketButtons[currentButtonIndex];
            button.GetComponent<Image>().sprite = itemSprite;
            button.SetActive(true);

            currentButtonIndex++; // 다음 버튼을 위해 인덱스를 증가시킵니다.
        }
        else
        {
            // 모든 버튼이 이미 활성화되었다면, 추가 처리를 수행합니다. (예: 경고 메시지 등)
        }
    }
}