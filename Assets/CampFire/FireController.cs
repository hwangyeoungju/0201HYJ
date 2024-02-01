using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireController : MonoBehaviour
{
    public ParticleSystem CampfireEffect;
    public ParticleSystem AuroraEffect;
    public Transform CampFirePoint;

    private ParticleSystem campfireInstance;  // 생성된 CampfireEffect의 인스턴스를 저장하기 위한 변수
    private bool isCampFireActive = false;
    private bool hasCollidedWithTorch = false;
    private bool hasCollidedWithAurora = false;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isCampFireActive && collision.gameObject.CompareTag("Torch") && !hasCollidedWithTorch)
        {
            ActivateCampFireEffect();
            hasCollidedWithTorch = true;
        }

        if (isCampFireActive && collision.gameObject.CompareTag("Aurora") && !hasCollidedWithAurora)
        {
            DeactivateCampFireEffect();
            ActivateAuroraEffect();
            hasCollidedWithAurora = true;
            Destroy(collision.gameObject);
        }
    }

    private void ActivateCampFireEffect()
    {
        campfireInstance = Instantiate(CampfireEffect, CampFirePoint.position, Quaternion.identity);
        campfireInstance.Play();
        isCampFireActive = true;

    }

    private void DeactivateCampFireEffect()
    {
        campfireInstance.Stop();
        Destroy(campfireInstance.gameObject);
        isCampFireActive = false;
    }

    private void ActivateAuroraEffect()
    {
        ParticleSystem auroraInstance = Instantiate(AuroraEffect, CampFirePoint.position, Quaternion.identity);

    }
}