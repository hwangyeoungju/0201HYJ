using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator;
    public bool isOpen = false;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ToggleDoor);
    }

    void ToggleDoor()
    {
        isOpen = !isOpen; // 상태를 토글합니다.

        if (isOpen)
        {
            doorAnimator.Play("Door"); // 열리는 애니메이션 이름으로 변경하세요.
        }
    }
}
