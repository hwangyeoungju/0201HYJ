using UnityEngine;
using UnityEngine.UI;

public class ImageControl : MonoBehaviour
{
    public Image targetImage;
    private bool isImageActive; // 이미지 활성화 상태를 추적하는 변수

    void Start()
    {
        // 초기에 이미지 상태를 설정 (예: 비활성화)
        isImageActive = false;
        targetImage.gameObject.SetActive(isImageActive);
    }

    // 이미지 상태를 토글하는 함수
    public void ToggleImage()
    {
        isImageActive = !isImageActive; // 현재 상태를 반전
        targetImage.gameObject.SetActive(isImageActive);
    }
}