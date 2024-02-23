using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // 충돌 감지
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MeatPiece") || collision.gameObject.CompareTag("Marsh"))
        {
            SoundManager.instance.PlaySfx(SoundManager.Sfx.EAT);
            Destroy(collision.gameObject);
        }
    }
     private void OnCollisionStay(Collision collision)
     {
         if (collision.gameObject.CompareTag("Can"))
         {
             SoundManager.instance.PlaySfx(SoundManager.Sfx.Drink);
    Destroy(collision.gameObject);
         }
     }
}
