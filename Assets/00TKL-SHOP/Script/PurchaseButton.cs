using UnityEngine;
using UnityEngine.UI;

public class PurchaseButton : MonoBehaviour
{
    public Button button; // 버튼 컴포넌트
    public GameObject imageObject; // 버튼 위에 올릴 이미지 오브젝트

    void Start()
    {
        // 시작할 때 이미지를 숨깁니다.
        imageObject.SetActive(false);
    }

    public void ToggleImage()
    {
        // 이미지의 활성화 상태를 토글합니다.
        imageObject.SetActive(!imageObject.activeSelf);
    }
}
