using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private Animator doorAnimator;

    void Start()
    {
        // Assuming the Animator component is attached to the same GameObject as this script
        doorAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Call the OnOpenButtonClicked method when any collision occurs
        OnOpenButtonClicked();
    }

    public void OnOpenButtonClicked()
    {
        if (doorAnimator != null)
        {
            doorAnimator.SetBool("isOpen", true);
        }
        else
        {
            Debug.LogError("Animator component not found.");
        }
    }

    public void OnCloseButtonClicked()
    {
        if (doorAnimator != null)
        {
            doorAnimator.SetBool("isOpen", false);
        }
        else
        {
            Debug.LogError("Animator component not found.");
        }
    }
}


