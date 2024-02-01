using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private ScriptableItemData data;
    [SerializeField] private Image image;
    [SerializeField] private GameObject prefab;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void UpdateEquipment(ScriptableItemData equipment)
    {
        data = equipment;
        if (equipment != null)
        {
            UpdateImage(data.Icon); // �������� �ִ� ���, ���������� �̹��� ������Ʈ
            UpdatePrefab(data.Prefab);
        }
        else
        {
            ClearImage(); // �������� ���� ���, �̹����� ���ų� �⺻ �̹����� ����
        }
    }

    private void UpdateImage(Sprite sprite)
    {
        image.sprite = sprite;
        image.enabled = true; // �̹��� Ȱ��ȭ
    }

    public void UpdatePrefab(GameObject newPrefab)
    {
        prefab = newPrefab;
        if (prefab != null)
        {
            prefab.SetActive(true);

        }
    }

    public GameObject GetPrefab()
    {
        return prefab;
    }

    public ScriptableItemData GetData()
    {
        return data;
    }

    private void ClearImage()
    {
        image.sprite = null; // ��������Ʈ�� ���
        image.enabled = false; // �̹��� ��Ȱ��ȭ
    }
}