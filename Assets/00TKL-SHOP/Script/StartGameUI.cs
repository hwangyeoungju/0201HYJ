using UnityEngine;
using UnityEngine.UI;

public class StartGameUI : MonoBehaviour
{
    public GameObject gameExplanationUI; // 첫 번째 설명 UI 오브젝트
    public GameObject nextUI; // 활성화될 다음 UI 오브젝트
    public float displayTime = 5.0f; // 첫 번째 UI 표시 시간
    public float nextUIDisplayTime = 5.0f; // 두 번째 UI 표시 시간

    void Start()
    {
        gameExplanationUI.SetActive(true); // 게임 시작 시 첫 번째 UI 활성화
        nextUI.SetActive(false); // 다음 UI는 초기에 비활성화
        Invoke("ActivateNextUI", displayTime); // 설정한 시간 후 첫 번째 UI 숨기고 두 번째 UI 활성화
    }

    void ActivateNextUI()
    {
        gameExplanationUI.SetActive(false); // 첫 번째 UI 비활성화
        nextUI.SetActive(true); // 다음 UI 활성화
        Invoke("HideNextUI", nextUIDisplayTime); // 추가된 부분: 설정한 시간 후 두 번째 UI 숨기기
    }

    void HideNextUI()
    {
        nextUI.SetActive(false); // 두 번째 UI 비활성화
    }
}
