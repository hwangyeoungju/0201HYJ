using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    public List<ScriptableItemData> Equipments
    {
        get
        {
            return equipments;
        }
        set
        {
            equipments = value;
            Debug.Log("이벤트 실행");
        }
    }
    private List<ScriptableItemData> equipments = new List<ScriptableItemData>();

    public event Action OnInventoryChangedEvent;

    public bool AddEquipment(ScriptableItemData equipment)
    {
        if (Equipments.Contains(equipment)) return false;

        Equipments.Add(equipment);
        OnInventoryChangedEvent?.Invoke();

        return true;
    }

    public bool RemoveEquipment(ScriptableItemData equipment)
    {
        if (Equipments.Contains(equipment))
        {
            Equipments.Remove(equipment);
            OnInventoryChangedEvent?.Invoke();
            return true; // 제거 성공
        }
        return false; // 제거 실패
    }
    public bool RemoveAllEquipments()
    {
        if (Equipments.Count > 0)
        {
            Equipments.Clear(); // 모든 아이템 제거
            OnInventoryChangedEvent?.Invoke(); // 인벤토리 변경 이벤트 발생
            return true; // 제거 성공
        }
        return false; // 제거 실패 (인벤토리가 비어있음)
    }




}
