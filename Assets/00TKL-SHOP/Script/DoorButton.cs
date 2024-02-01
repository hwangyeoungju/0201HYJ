using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorButton : MonoBehaviour
{
    // 카메라와 UI의 위치를 추적하기 위한 Transform 변수들
    public Transform CameraTr;
    public Transform UiTr;

    // UI가 활성화되는 거리 (단위: Unity units)
    public float OnDist = 4f;
    // UI가 비활성화되는 거리 (단위: Unity units)
    public float OffDist = 4f;
    // 거리 체크 간격 (초 단위)
    public float UpdateInterval = 0.5f;

    // 거리 체크를 계속할지 여부를 결정하는 bool 변수
    private bool CheckDist = false;

    // 스크립트가 활성화될 때 최초 호출되는 함수
    void Start()
    {
        // 거리 체크를 시작하는 코루틴 함수
        StartCoroutine(CheckPlayerDistance());
    }

    // 플레이어와 UI 요소 사이의 거리를 주기적으로 체크하는 코루틴
    IEnumerator CheckPlayerDistance()
    {
        CheckDist = true;

        while (CheckDist)
        {
            // 카메라와 UI 요소 사이의 거리 계산
            float distance = Vector3.Distance(CameraTr.transform.position, UiTr.transform.position);

            // 거리가 OnDist보다 작으면 UI를 활성화
            if (distance < OnDist)
            {
                UiTr.gameObject.SetActive(true);
                //Debug.Log("ON");
            }
            // 거리가 OffDist 이상이면 UI를 비활성화
            else if (distance >= OffDist)
            {
                UiTr.gameObject.SetActive(false);
                //Debug.Log("OFF");
            }
            // 그 외의 경우 (이 부분은 실제로는 불필요해 보입니다. 무한루프를 멈추지 않는 이상 'else' 절은 실행되지 않을 것입니다.)
            else
            {
                StopCheckingDistance();
                //Debug.Log("ELSE");
            }
            // 설정된 간격(UpdateInterval)만큼 대기
            yield return new WaitForSeconds(UpdateInterval);
        }
    }

    // 거리 체크를 중지하는 함수
    public void StopCheckingDistance()
    {
        CheckDist = false;
    }
}