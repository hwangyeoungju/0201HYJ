using UnityEngine;
using UnityEngine.UI;

public class TorchController : MonoBehaviour
{
    public ParticleSystem fireEffect; 
    public Transform TorchFirePoint;
 
    void Start()
    {
        if (TorchFirePoint == null)
        {
            Debug.LogError("����");
            return;
        }
    }

    public void OnOnButtonClicked()
    {
        // Yes ��ư�� Ŭ���ϸ� �� ����Ʈ�� TorchFirePoint ��ġ�� ����
        ParticleSystem newFireEffect = Instantiate(fireEffect, TorchFirePoint.position, Quaternion.identity).GetComponent<ParticleSystem>();

        // ������ �� ����Ʈ�� ��ġ�� �ڽ����� ����
        if (newFireEffect != null)
        {
            newFireEffect.transform.parent = TorchFirePoint;
        }
    }

    public void OnOffButtonClicked()
    {
        ParticleSystem fireEffect = TorchFirePoint.GetComponentInChildren<ParticleSystem>();

        if (fireEffect != null)
        {
            // ����Ʈ�� ��Ȱ��ȭ�մϴ�.
            fireEffect.gameObject.SetActive(false);

        }
    }

}
