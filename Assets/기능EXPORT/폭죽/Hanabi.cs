using UnityEngine;

public class Hanabi : MonoBehaviour
{
    public GameObject objectToActivate;
    public float activationDuration = 5f;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Torch"))
        {

            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);


                Invoke("DeactivateObject", activationDuration);
            }

        }
    }


    private void DeactivateObject()
    {

        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false);
        }

    }
}

