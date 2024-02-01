using UnityEngine;

public class ResizeCollider : MonoBehaviour
{
    // 크기 변경을 위한 메서드
    public void ResizeColliderManually()
    {
        BoxCollider boxCollider = GetComponent<BoxCollider>();

        if (boxCollider != null)
        {
            //Debug.Log("메뉴얼리작동중");
            // 원하는 크기로 수동 조절
            Vector3 newSize = new Vector3(0.005f, 0.005f, 0.005f);
            boxCollider.size = newSize;
        }
    }

    // 새로 추가한 메서드: 크기 수동 조절
    public void ChangeColliderSizeToDefault()
    {
        BoxCollider boxCollider = GetComponent<BoxCollider>();

        if (boxCollider != null)
        {
            // 기본 크기로 변경
            Vector3 defaultSize = new Vector3(0.0143f, 0.0168f, 0.0097f);
            boxCollider.size = defaultSize;
        }
    }
}
