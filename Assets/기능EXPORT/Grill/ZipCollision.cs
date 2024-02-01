using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ZipCollision : MonoBehaviour
{
    private bool isSplit = false;
    //private new AudioSource audio;
    private bool hasCollided = false; 
    private XRSocketInteractor socketInteractor;

    private void Start()
    {
     
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isSplit && collision.gameObject.CompareTag("Zip") && !hasCollided)
        {
 
            hasCollided = true;


            socketInteractor = collision.gameObject.GetComponentInChildren<XRSocketInteractor>();
            if (socketInteractor != null)
            {
                socketInteractor.enabled = false;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (hasCollided && collision.gameObject.CompareTag("Zip"))
        {
            if (socketInteractor != null)
            {
                socketInteractor.enabled = true;
            }

            hasCollided = false;
        }
    }
}
