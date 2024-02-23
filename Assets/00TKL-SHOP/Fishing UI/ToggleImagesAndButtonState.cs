/*using UnityEngine;
using UnityEngine.UI;

public class ToggleImagesOnButtonClick : MonoBehaviour
{
    public Button triggerButton; // 사용자가 클릭할 버튼
    public GameObject imageToDeactivate; // 비활성화할 이미지 오브젝트
    public GameObject imageToActivate; // 활성화할 이미지 오브젝트

    public Button otherButton; // 다른 버튼을 위한 변수 추가

    void Start()
    {
        triggerButton.onClick.AddListener(ToggleImages);
        otherButton.onClick.AddListener(EnableTriggerButtonClick); // 다른 버튼의 클릭 리스너 추가
    }

    void ToggleImages()
    {
        // 기존 이미지 비활성화
        imageToDeactivate.SetActive(false);

        // 새 이미지 활성화
        imageToActivate.SetActive(true);
    }

    void EnableTriggerButtonClick()
    {
        // triggerButton의 클릭 기능을 활성화 또는 비활성화
        triggerButton.interactable = !triggerButton.interactable;
    }
}*/
using UnityEngine;
using UnityEngine.UI;

public class ToggleImagesOnButtonClick : MonoBehaviour
{
    public Button triggerButton; // 사용자가 클릭할 버튼
    public GameObject imageToDeactivate; // 비활성화할 이미지 오브젝트
    public GameObject imageToActivate; // 활성화할 이미지 오브젝트

    public Button otherButton; // 다른 버튼을 위한 변수 추가

    void Start()
    {
        triggerButton.onClick.AddListener(ToggleImages);
        otherButton.onClick.AddListener(EnableTriggerButtonClick); // 다른 버튼의 클릭 리스너 추가
    }

    void ToggleImages()
    {
        // 기존 이미지 비활성화
        imageToDeactivate.SetActive(false);

        // 새 이미지 활성화
        imageToActivate.SetActive(true);
    }

    void EnableTriggerButtonClick()
    {
        // triggerButton의 클릭 기능을 활성화 또는 비활성화
        bool shouldEnable = !triggerButton.interactable;
        triggerButton.interactable = shouldEnable;

        // shouldEnable 값에 따라 적절한 이미지 활성화/비활성화
        if (shouldEnable)
        {
            // 기존 이미지를 비활성화하고 새 이미지를 활성화
            imageToDeactivate.SetActive(false);
            imageToActivate.SetActive(true);
        }
        else
        {
            // 선택적으로, 버튼을 비활성화할 때 이미지 상태를 되돌리려면 이 부분을 사용
            // imageToDeactivate.SetActive(true);
            // imageToActivate.SetActive(false);
        }
    }
}
