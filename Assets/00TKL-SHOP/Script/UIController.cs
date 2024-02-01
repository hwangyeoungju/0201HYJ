using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject uiElement; // 비활성화하려는 UI 요소
    public Button yourButton; // 버튼

    void Start()
    {
        yourButton.onClick.AddListener(ShowUI); // 버튼에 이벤트 리스너 추가
    }

    void ShowUI()
    {
        uiElement.SetActive(true); // UI 요소 활성화
        StartCoroutine(DisableUIAfterSeconds(5)); // 5초 후에 UI 요소 비활성화
    }

    IEnumerator DisableUIAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds); // 지정된 시간(초) 동안 대기
        uiElement.SetActive(false); // UI 요소 비활성화
    }
}
