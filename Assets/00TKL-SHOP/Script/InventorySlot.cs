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
            UpdateImage(data.Icon); // 아이템이 있는 경우, 아이콘으로 이미지 업데이트
            UpdatePrefab(data.Prefab);
        }
        else
        {
            ClearImage(); // 아이템이 없는 경우, 이미지를 비우거나 기본 이미지로 설정
        }
    }

    private void UpdateImage(Sprite sprite)
    {
        image.sprite = sprite;
        image.enabled = true; // 이미지 활성화
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
        image.sprite = null; // 스프라이트를 비움
        image.enabled = false; // 이미지 비활성화
    }
}