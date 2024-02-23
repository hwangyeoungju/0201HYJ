using UnityEngine;

public class PlayerActivator : MonoBehaviour
{
    public GameObject activePlayer;
    public GameObject inactivePlayer;

    private void Start()
    {
        // 처음에는 activePlayer가 활성화되어 있고, inactivePlayer가 비활성화되어 있도록 설정
        activePlayer.SetActive(true);
        inactivePlayer.SetActive(false);
    }

    public void SwitchPlayers()
    {
        // activePlayer를 비활성화하고 inactivePlayer를 활성화
        activePlayer.SetActive(false);
        inactivePlayer.SetActive(true);

        // 변수들을 교환
        GameObject temp = activePlayer;
        activePlayer = inactivePlayer;
        inactivePlayer = temp;
    }

    // 예를 들어 어떤 조건에서 호출할 메서드
    //  private void SomeCondition()
    //  {
    // 플레이어를 교체
    //      SwitchPlayers();
    //  }
}