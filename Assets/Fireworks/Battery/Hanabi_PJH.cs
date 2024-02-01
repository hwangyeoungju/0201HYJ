using UnityEngine;

public class Hanabi_PJH : MonoBehaviour
{
    // Ȱ��ȭ�� ���� ������Ʈ���� ������ �迭
    public GameObject[] objectsToActivate;

    // Ȱ��ȭ ���� �ð�
    public float activationDuration = 25f;

    // �浹�� �Ͼ�� �� ȣ��Ǵ� �Լ�
    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� "Torch" �±׸� ������ �ִ��� Ȯ��
        if (collision.gameObject.CompareTag("Torch"))
        {
            // Ȱ��ȭ�� ���� ������Ʈ �迭�� �����Ǿ� �ִ��� Ȯ��
            if (objectsToActivate != null && objectsToActivate.Length > 0)
            {
                // �迭�� �ִ� ��� ������Ʈ�� Ȱ��ȭ�ϰ� ���� �ð� �Ŀ� ��Ȱ��ȭ�� �Լ��� ȣ��
                foreach (GameObject obj in objectsToActivate)
                {
                    if (obj != null)
                    {
                        obj.SetActive(true);
                    }
                }
                Invoke("DeactivateObjects", activationDuration);
            }
        }
    }

    // ���� ������Ʈ���� ��Ȱ��ȭ�ϴ� �Լ�
    private void DeactivateObjects()
    {
        // Ȱ��ȭ�� ���� ������Ʈ �迭�� �����Ǿ� �ִ��� Ȯ���ϰ� ��� ��Ȱ��ȭ
        if (objectsToActivate != null && objectsToActivate.Length > 0)
        {
            foreach (GameObject obj in objectsToActivate)
            {
                if (obj != null)
                {
                    obj.SetActive(false);
                }
            }
        }
    }
}
