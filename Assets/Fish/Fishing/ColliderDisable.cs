using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDisabler : MonoBehaviour
{
    public string tagToDetect = "Fish"; // 태그를 입력하세요.

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagToDetect))
        {
            // 충돌한 오브젝트의 콜라이더 비활성화
            Collider collider = this.gameObject.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = false;
            }
        }
    }
}
