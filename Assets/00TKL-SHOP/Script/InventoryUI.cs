using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private InventorySlot[] inventorySlots;

    private void Awake()
    {
        inventorySlots = GetComponentsInChildren<InventorySlot>(true);
        Debug.Log(inventorySlots.Length);
    }

    private void Start()
    {
        Inventory.Instance.OnInventoryChangedEvent += UpdateUI;
        Inventory.Instance.OnInventoryChangedEvent += DebugUI;
    }

    private void DebugUI()
    {
        var itemsString = "";
        foreach (var equipment in Inventory.Instance.Equipments)
        {
            itemsString += equipment.Name + " ";
        }
        Debug.Log(itemsString);
    }

    public void UpdateUI()
    {
        for (int index = 0; index < inventorySlots.Length; index++)
        {
            // 지금은 20개의 슬롯이 있고, 12개를 가지고 있다가 11개가 되는 경우가 없잖아요?
            // 12개 -> 11개 줄어들면 슬롯에 있던 이미지를 제거 해줘야됩니다.
            if (Inventory.Instance.Equipments.Count > index)
            {
                var equipment = Inventory.Instance.Equipments[index];
                inventorySlots[index].UpdateEquipment(equipment);
            }
            else
            {
                inventorySlots[index].UpdateEquipment(null);
            }
        }
    }
}