using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public Image targetImage;

    // �̹��� UI�� Ȱ��ȭ�ϴ� �Լ�
    public void ActivateImage()
    {
        targetImage.gameObject.SetActive(true);
    }

    // �̹��� UI�� ��Ȱ��ȭ�ϴ� �Լ�
    public void DeactivateImage()
    {
        targetImage.gameObject.SetActive(false);
    }
}
