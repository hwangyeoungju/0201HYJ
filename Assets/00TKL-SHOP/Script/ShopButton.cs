using UnityEngine;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private ScriptableItemData equipment;
    [SerializeField] private InventorySlot inventorySlot;

    public void PickUp()
    {
        bool result = Inventory.Instance.AddEquipment(equipment);
        if (result)
        {
            Debug.Log("성공");
            // 담기 성공!
        }
        else
        {
            Debug.Log("실패");
            // 이미 아이템이 있거나 등등
        }
    }

    public void PickOut()
    {
        if (inventorySlot != null)
        {
            GameObject updatedPrefab = inventorySlot.GetPrefab(); // InventorySlot에서 업데이트된 프리팹을 가져옴
            if (updatedPrefab != null)
            {
                // 여기서 업데이트된 프리팹을 사용하여 아이템 생성
                GameObject spawnedItem = Instantiate(updatedPrefab, transform.position, Quaternion.identity);

                // 아이템을 인벤토리에서 제거
                bool result = Inventory.Instance.RemoveEquipment(inventorySlot.GetData());
                if (result)
                {
                    Debug.Log("Delete Item");
                }
                else
                {
                    Debug.Log("No Prefab in Inventroy");
                }
            }
            else
            {
                Debug.LogError("No Updated Prefab");
            }
        }
        else
        {
            Debug.LogError("No InventorySlot");
        }
    }
    public void Remove()
    {
        bool result = Inventory.Instance.RemoveEquipment(equipment);
        if (result)
        {
            Debug.Log("제거 성공"); // 제거 성공!
        }
        else
        {
            Debug.Log("제거 실패"); // 제거할 아이템이 없거나 등등
        }
    }
    public void RemoveAll()
    {
        bool result = Inventory.Instance.RemoveAllEquipments();
        if (result)
        {
            Debug.Log("모든 아이템 제거 성공"); // 모든 아이템 제거 성공!
        }
        else
        {
            Debug.Log("제거 실패 - 인벤토리가 비어있음"); // 인벤토리가 이미 비어있음
        }
    }
}