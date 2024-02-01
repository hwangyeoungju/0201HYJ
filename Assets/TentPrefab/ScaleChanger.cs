using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    public float scaleIncrement = 0.1f; // Y축 스케일 증가량
    public GameObject targetObject; // 증가시킬 다른 물체(B)를 지정할 변수
    public int maxCollisions = 5; // 최대 충돌 횟수

    private int collisionCount = 0; // 충돌 횟수를 세는 변수

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hammer") && collisionCount < maxCollisions)
        {
            SoundManager.instance.PlaySfx(SoundManager.Sfx.Hammer);
            IncreaseScale(targetObject); // 스케일 증가 함수 호출, B를 인자로 전달
            collisionCount++;

            if (collisionCount >= maxCollisions)
            {
                // 충돌 횟수가 최대치에 도달하면 스크립트 비활성화
                // enabled = false;
                Destroy(gameObject);  // 이건 파괴
            }
        }
    }

    private void IncreaseScale(GameObject target)
    {
        if (target != null)
        {
            Vector3 newScale = target.transform.localScale;
            newScale.y += scaleIncrement; // Y축 스케일 증가
            target.transform.localScale = newScale;
        }
    }
}
