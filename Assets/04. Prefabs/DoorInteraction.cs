using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public string handTag = "Hand"; // hand 오브젝트의 태그
    public Animator doorAnimator; // 문을 제어하는 Animator

    private void OnTriggerEnter(Collider other)
    {
        // hand 오브젝트와 충돌한 경우
        if (other.CompareTag(handTag))
        {
            // 문을 여는 애니메이션 실행
            doorAnimator.SetBool("isOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // hand 오브젝트와 충돌이 끝난 경우
        if (other.CompareTag(handTag))
        {
            // 문을 닫는 애니메이션 실행
            doorAnimator.SetTrigger("Close");
        }
    }
}

