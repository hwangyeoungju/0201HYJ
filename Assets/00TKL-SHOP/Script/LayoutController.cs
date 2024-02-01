using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutController : MonoBehaviour
{
    public GameObject basketPanel; // ��ٱ��� �г� ������Ʈ

    // ��ٱ��� �г��� ���̾ƿ��� �����ϴ� �޼���
    public void UpdateBasketLayout()
    {
        // GridLayoutGroup ������Ʈ�� ã�Ƽ� ���� ��û
        GridLayoutGroup grid = basketPanel.GetComponent<GridLayoutGroup>();
        if (grid != null)
        {
            grid.enabled = false;
            grid.enabled = true; // �� ����� GridLayoutGroup�� �����Ͽ� ���̾ƿ��� �����մϴ�.
        }
    }
}
