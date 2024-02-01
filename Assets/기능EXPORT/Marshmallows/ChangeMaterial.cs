/*
public class ChangeMaterial : MonoBehaviour
{
    public Material brownMaterial; // 갈색 메테리얼을 Inspector에서 설정

    // 충돌 감지
    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 물체의 태그가 "Fire"인 경우
        if (collision.gameObject.CompareTag("Fire"))
        {
            // 물체의 Renderer 컴포넌트 가져오기
            Renderer objectRenderer = GetComponent<Renderer>();

            // Renderer 컴포넌트가 있을 경우
            if (objectRenderer != null)
            {
                // 메테리얼 변경
                objectRenderer.material = brownMaterial;
            }
        }
    }
}*/
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material brownMaterial; // 갈색 메테리얼을 Inspector에서 설정

    // 파티클 충돌 감지
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Fire"))
        {
            // 일정 시간 후에 메테리얼 변경
            Invoke("ChangeMaterialDelayed", 5f);
        }
    }

    // 일정 시간 후에 호출되는 메소드
    private void ChangeMaterialDelayed()
    {
        // 물체의 Renderer 컴포넌트 가져오기
        Renderer objectRenderer = GetComponent<Renderer>();

        // Renderer 컴포넌트가 있을 경우
        if (objectRenderer != null)
        {
            // 메테리얼 변경
            objectRenderer.material = brownMaterial;


        }
    }
}