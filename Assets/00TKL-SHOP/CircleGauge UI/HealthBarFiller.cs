using UnityEngine;
using UnityEngine.UI;

public class HealthBarFiller : MonoBehaviour
{
    public Slider healthBar;
    public float fillSpeed = 10f; // Slider가 채워지는 속도

    private void Start()
    {
        if (healthBar == null)
        {
            Debug.LogError("HealthBarFiller requires a reference to a Slider.");
        }
    }

    private void Update()
    {
        // Slider의 값을 증가시킵니다.
        if (healthBar.value < healthBar.maxValue)
        {
            healthBar.value += fillSpeed * Time.deltaTime;
        }
        else
        {
            // 최대값에 도달하면 다시 0으로 리셋합니다.
            healthBar.value = 0;
        }
    }
}
