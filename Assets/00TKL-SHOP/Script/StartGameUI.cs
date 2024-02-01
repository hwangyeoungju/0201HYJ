using UnityEngine;
using UnityEngine.UI;

public class StartGameUI : MonoBehaviour
{
    public GameObject gameExplanationUI; // ù ��° ���� UI ������Ʈ
    public GameObject nextUI; // Ȱ��ȭ�� ���� UI ������Ʈ
    public float displayTime = 5.0f; // ù ��° UI ǥ�� �ð�
    public float nextUIDisplayTime = 5.0f; // �� ��° UI ǥ�� �ð�

    void Start()
    {
        gameExplanationUI.SetActive(true); // ���� ���� �� ù ��° UI Ȱ��ȭ
        nextUI.SetActive(false); // ���� UI�� �ʱ⿡ ��Ȱ��ȭ
        Invoke("ActivateNextUI", displayTime); // ������ �ð� �� ù ��° UI ����� �� ��° UI Ȱ��ȭ
    }

    void ActivateNextUI()
    {
        gameExplanationUI.SetActive(false); // ù ��° UI ��Ȱ��ȭ
        nextUI.SetActive(true); // ���� UI Ȱ��ȭ
        Invoke("HideNextUI", nextUIDisplayTime); // �߰��� �κ�: ������ �ð� �� �� ��° UI �����
    }

    void HideNextUI()
    {
        nextUI.SetActive(false); // �� ��° UI ��Ȱ��ȭ
    }
}
