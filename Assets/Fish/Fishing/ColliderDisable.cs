using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDisabler : MonoBehaviour
{
    public string tagToDetect = "Fish"; // �±׸� �Է��ϼ���.

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagToDetect))
        {
            // �浹�� ������Ʈ�� �ݶ��̴� ��Ȱ��ȭ
            Collider collider = this.gameObject.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = false;
            }
        }
    }
}
