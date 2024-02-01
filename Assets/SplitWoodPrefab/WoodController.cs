using UnityEngine;

public class WoodLogController : MonoBehaviour
{
    public GameObject woodPiecePrefab; // 반쪽 장작 프리팹
    public float splitForce = 2.0f; // 분할 힘
                                    //public AudioClip woodAudio; // 나무 쪼갤 때 사운드



    private bool isSplit = false;
    //private new AudioSource audio;
    private bool hasCollided = false; // 충돌 여부 확인용

    private void Start()
    {
        // audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isSplit && collision.gameObject.CompareTag("Axe") && !hasCollided)
        {
            //audio.Play();
            SoundManager.instance.PlaySfx(SoundManager.Sfx.SplitWood);
            SplitWood();
            hasCollided = true;



            // 컨트롤러에 진동을 주기
            OVRInput.SetControllerVibration(0.5f, 1.0f, OVRInput.Controller.RTouch); // 오른손 컨트롤러 진동
        }
    }

    private void SplitWood()
    {

        // 장작과 도끼가 충돌했을 때 사운드 재생
        //audio.PlayOneShot(woodAudio, 1.0f);

        //audio.enabled = true; // 오디오 소스 활성화
        // 분할된 장작 조각들을 생성
        Vector3 splitPosition = transform.position;
        GameObject woodPiece1 = Instantiate(woodPiecePrefab, splitPosition, Quaternion.identity);
        GameObject woodPiece2 = Instantiate(woodPiecePrefab, splitPosition, Quaternion.identity);


        // 각각의 장작 조각에 Rigidbody 컴포넌트 추가
        Rigidbody rb1 = woodPiece1.GetComponent<Rigidbody>();
        Rigidbody rb2 = woodPiece2.GetComponent<Rigidbody>();


        // 두 조각을 독립적으로 분할하고 약간 회전
        Vector3 splitDirection = Random.insideUnitSphere;
        rb1.AddForce(splitDirection * splitForce, ForceMode.Impulse);
        rb2.AddForce(-splitDirection * splitForce, ForceMode.Impulse);


        // 기존 장작 오브젝트 파괴
        Destroy(gameObject);

        isSplit = true; // 중복 분할 방지
    }


}