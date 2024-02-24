
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class Hook : MonoBehaviour
{
    public GameObject fish;

    // 물고기를 훅에 붙일 때 호출되는 메서드
    public void AttachFish(GameObject fishObject)
    {
        fish = fishObject;
        // 물고기가 훅에 붙는다면 해당 물고기의 이름을 사용할 수 있습니다.
        string fishName = fish.GetComponent<NewFish>().fishName;
        Debug.Log("Caught fish: " + fishName);
    }

    // 다른 메서드들...
}

