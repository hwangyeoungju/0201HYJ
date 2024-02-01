using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorButton : MonoBehaviour
{
    // ī�޶�� UI�� ��ġ�� �����ϱ� ���� Transform ������
    public Transform CameraTr;
    public Transform UiTr;

    // UI�� Ȱ��ȭ�Ǵ� �Ÿ� (����: Unity units)
    public float OnDist = 4f;
    // UI�� ��Ȱ��ȭ�Ǵ� �Ÿ� (����: Unity units)
    public float OffDist = 4f;
    // �Ÿ� üũ ���� (�� ����)
    public float UpdateInterval = 0.5f;

    // �Ÿ� üũ�� ������� ���θ� �����ϴ� bool ����
    private bool CheckDist = false;

    // ��ũ��Ʈ�� Ȱ��ȭ�� �� ���� ȣ��Ǵ� �Լ�
    void Start()
    {
        // �Ÿ� üũ�� �����ϴ� �ڷ�ƾ �Լ�
        StartCoroutine(CheckPlayerDistance());
    }

    // �÷��̾�� UI ��� ������ �Ÿ��� �ֱ������� üũ�ϴ� �ڷ�ƾ
    IEnumerator CheckPlayerDistance()
    {
        CheckDist = true;

        while (CheckDist)
        {
            // ī�޶�� UI ��� ������ �Ÿ� ���
            float distance = Vector3.Distance(CameraTr.transform.position, UiTr.transform.position);

            // �Ÿ��� OnDist���� ������ UI�� Ȱ��ȭ
            if (distance < OnDist)
            {
                UiTr.gameObject.SetActive(true);
                //Debug.Log("ON");
            }
            // �Ÿ��� OffDist �̻��̸� UI�� ��Ȱ��ȭ
            else if (distance >= OffDist)
            {
                UiTr.gameObject.SetActive(false);
                //Debug.Log("OFF");
            }
            // �� ���� ��� (�� �κ��� �����δ� ���ʿ��� ���Դϴ�. ���ѷ����� ������ �ʴ� �̻� 'else' ���� ������� ���� ���Դϴ�.)
            else
            {
                StopCheckingDistance();
                //Debug.Log("ELSE");
            }
            // ������ ����(UpdateInterval)��ŭ ���
            yield return new WaitForSeconds(UpdateInterval);
        }
    }

    // �Ÿ� üũ�� �����ϴ� �Լ�
    public void StopCheckingDistance()
    {
        CheckDist = false;
    }
}