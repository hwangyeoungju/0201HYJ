using UnityEngine;
using System.Collections;
public class GrillScript : MonoBehaviour
{
    public Material grilledMaterial; // 익힌 상태의 메테리얼을 Inspector에서 설정

    // 콜리전 이벤트
    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 물체가 MeatPiece 태그를 가지고 있는지 확인
        if (collision.gameObject.CompareTag("MeatPiece"))
        {
            SoundManager.instance.PlaySfx(SoundManager.Sfx.ROST);
            // Coroutine을 시작하여 일정 시간 후에 고기의 메테리얼 변경
            StartCoroutine(ChangeMeatMaterialDelayed(collision.gameObject, grilledMaterial, 5f));
        }
    }

    // 일정 시간 후에 호출되는 Coroutine
    private IEnumerator ChangeMeatMaterialDelayed(GameObject meat, Material newMaterial, float delay)
    {
        // 일정 시간 대기
        yield return new WaitForSeconds(delay);

        // 고기의 메테리얼 변경
        ChangeMeatMaterial(meat, newMaterial);
    }

    // 고기의 메테리얼 변경 메소드
    private void ChangeMeatMaterial(GameObject meat, Material newMaterial)
    {
        // 고기의 Renderer 컴포넌트 가져오기
        Renderer meatRenderer = meat.GetComponent<Renderer>();

        // Renderer 컴포넌트가 있을 경우
        if (meatRenderer != null)
        {
            // 메테리얼 변경
            meatRenderer.material = newMaterial;
        }
    }
}

/*using UnityEngine;

public class CookMeat : MonoBehaviour
{
    public Material grilledMaterial1; // 첫 번째 메테리얼
    public Material grilledMaterial2; // 두 번째 메테리얼
    public Material grilledMaterial3; // 세 번째 메테리얼

    private float collisionTime = 0f;
    private GameObject collidedMeatObject; // 충돌한 고기 오브젝트를 저장할 변수
    private bool isCooked = false;

    // 콜리전 이벤트
    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 물체가 MeatPiece 태그를 가지고 있는지 확인
        if (collision.gameObject.CompareTag("MeatPiece"))
        {
            collisionTime = Time.time; // 충돌한 시간 기록
            collidedMeatObject = collision.gameObject; // 충돌한 고기 오브젝트 저장
        }
    }

    // 콜리전 종료 이벤트
    private void OnCollisionExit(Collision collision)
    {
        // 충돌 종료 시간 초기화
        collisionTime = 0f;
        collidedMeatObject = null;
    }


    // 매 프레임마다 호출
    private void Update()
    {
        // 충돌 후 처리
        if (collisionTime > 0f)
        {
            float elapsedSeconds = Time.time - collisionTime;

            // 일정 시간마다 메테리얼 변경
            if (elapsedSeconds >= 3f && elapsedSeconds < 6f)
            {
                ChangeMeatMaterial(collidedMeatObject, grilledMaterial1);
            }
            else if (elapsedSeconds >= 6f && elapsedSeconds < 10f)
            {
                ChangeMeatMaterial(collidedMeatObject, grilledMaterial2);
            }
            else if (elapsedSeconds >= 10f && elapsedSeconds < 12f)
            {
                ChangeMeatMaterial(collidedMeatObject, grilledMaterial3);
            }
            else if (elapsedSeconds >= 12f)
            {
                // 12초가 지나면 고기를 파괴
                DestroyMeat(collidedMeatObject);
            }
        }
    }

    // 고기의 메테리얼 변경 메소드
    private void ChangeMeatMaterial(GameObject meat, Material newMaterial)
    {
        // 고기의 Renderer 컴포넌트 가져오기
        Renderer meatRenderer = meat.GetComponent<Renderer>();

        // Renderer 컴포넌트가 있을 경우
        if (meatRenderer != null)
        {
            // 메테리얼 변경
            meatRenderer.material = newMaterial;
        }
        else
        {
            Debug.LogError("MeatPiece 오브젝트에 Renderer 컴포넌트가 없습니다.");
        }
    }

    // 고기 파괴 메소드
    private void DestroyMeat(GameObject meat)
    {
        // 고기 오브젝트 파괴
        Destroy(meat);

        // 파괴 후에는 더 이상 Update에서 처리하지 않도록 설정
        isCooked = true;
    }
}*/