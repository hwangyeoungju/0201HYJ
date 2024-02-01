/*using UnityEngine;
using UnityEngine.UI;

public class ToggleImagesAndButtonState : MonoBehaviour
{
    public Button controlButton; // 이미지와 다른 버튼의 상태를 변경할 버튼
    public Button targetButton; // 상태가 변경될 버튼

    public GameObject imageToDeactivate; // 비활성화할 이미지 오브젝트
    public GameObject imageToActivate; // 활성화할 이미지 오브젝트

    void Start()
    {
        controlButton.onClick.AddListener(ToggleImagesAndTargetButton);
    }

    void ToggleImagesAndTargetButton()
    {
        // 이미지 오브젝트 상태 변경
        bool isImageActive = imageToActivate.activeSelf;
        imageToDeactivate.SetActive(isImageActive);
        imageToActivate.SetActive(!isImageActive);

        // 대상 버튼(targetButton)의 클릭 가능 여부 변경
        targetButton.interactable = !targetButton.interactable;
    }
}*/
using UnityEngine;
using UnityEngine.UI;

public class ToggleImagesAndButtonState : MonoBehaviour
{
    public Button controlButton; // 이미지와 다른 버튼의 상태를 변경할 버튼
    public Button targetButton; // 상태가 변경될 버튼

    public GameObject imageToDeactivate; // 비활성화할 이미지 오브젝트
    public GameObject imageToActivate; // 활성화할 이미지 오브젝트

    void Start()
    {
        // 처음에 targetButton을 비활성화
        targetButton.interactable = false;

        // controlButton에 이벤트 리스너 추가
        controlButton.onClick.AddListener(ToggleImagesAndEnableTargetButton);
    }

    void ToggleImagesAndEnableTargetButton()
    {
        // 이미지 오브젝트 상태 변경
        bool isImageActive = imageToActivate.activeSelf;
        imageToDeactivate.SetActive(isImageActive);
        imageToActivate.SetActive(!isImageActive);

        // targetButton을 활성화
        targetButton.interactable = true;
    }
}