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
        isOpen = !isOpen; // ���¸� ����մϴ�.

        if (isOpen)
        {
            doorAnimator.Play("Door"); // ������ �ִϸ��̼� �̸����� �����ϼ���.
        }
    }
}
