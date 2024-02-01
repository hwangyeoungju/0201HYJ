using UnityEngine;
using UnityEngine.UI;

public class ImageControl : MonoBehaviour
{
    public Image targetImage;
    private bool isImageActive; // �̹��� Ȱ��ȭ ���¸� �����ϴ� ����

    void Start()
    {
        // �ʱ⿡ �̹��� ���¸� ���� (��: ��Ȱ��ȭ)
        isImageActive = false;
        targetImage.gameObject.SetActive(isImageActive);
    }

    // �̹��� ���¸� ����ϴ� �Լ�
    public void ToggleImage()
    {
        isImageActive = !isImageActive; // ���� ���¸� ����
        targetImage.gameObject.SetActive(isImageActive);
    }
}