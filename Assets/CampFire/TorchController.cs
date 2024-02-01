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
            Debug.LogError("에러");
            return;
        }
    }

    public void OnOnButtonClicked()
    {
        // Yes 버튼을 클릭하면 불 이펙트를 TorchFirePoint 위치에 생성
        ParticleSystem newFireEffect = Instantiate(fireEffect, TorchFirePoint.position, Quaternion.identity).GetComponent<ParticleSystem>();

        // 생성된 불 이펙트를 토치의 자식으로 설정
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
            // 이펙트를 비활성화합니다.
            fireEffect.gameObject.SetActive(false);

        }
    }

}
