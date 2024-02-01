using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public Button yourButton; // 할당할 버튼
    public Sprite newImage; // 교체할 새 이미지
    private bool isButtonPressed = false; // 버튼 상태

    void Start()
    {
        yourButton.onClick.AddListener(ChangeButtonState);
    }

    void ChangeButtonState()
    {
        isButtonPressed = !isButtonPressed; // 버튼 상태 변경
        yourButton.image.sprite = isButtonPressed ? newImage : yourButton.image.sprite; // 이미지 교체
    }
}