using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public Image targetImage;

    // 이미지 UI를 활성화하는 함수
    public void ActivateImage()
    {
        targetImage.gameObject.SetActive(true);
    }

    // 이미지 UI를 비활성화하는 함수
    public void DeactivateImage()
    {
        targetImage.gameObject.SetActive(false);
    }
}
