using UnityEngine;
using UnityEngine.UI;

public class IceboxDoorController2 : MonoBehaviour
{
    public Animator doorAnimator;
    private bool isOpen = false;

    public GameObject PiecePrefab;
    public float splitForce = 2.0f;
    void Start()
    {
        // 버튼 클릭 이벤트 등록
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    // 버튼 클릭 시 호출되는 메서드
    public void OnButtonClick()
    {
        if (!isOpen)
        {
            // 문이 닫혀있는 상태이면 열리는 애니메이션 재생
            doorAnimator.Play("stick ani");
            isOpen = true;

            Debug.Log("open");
        }
    }
    public void stickprefab()
    {
        Vector3 splitPosition = transform.position;
        GameObject woodPiece1 = Instantiate(PiecePrefab, splitPosition, Quaternion.identity);
        

        Rigidbody rb1 = woodPiece1.GetComponent<Rigidbody>();
        

        Vector3 splitDirection = Random.insideUnitSphere;
        rb1.AddForce(splitDirection * splitForce, ForceMode.Impulse);
    }
}




