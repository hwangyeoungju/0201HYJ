using UnityEngine;
using UnityEngine.UI;

public class HealthBarFiller : MonoBehaviour
{
    public Slider healthBar;
    public float fillSpeed = 10f; // Slider�� ä������ �ӵ�

    private void Start()
    {
        if (healthBar == null)
        {
            Debug.LogError("HealthBarFiller requires a reference to a Slider.");
        }
    }

    private void Update()
    {
        // Slider�� ���� ������ŵ�ϴ�.
        if (healthBar.value < healthBar.maxValue)
        {
            healthBar.value += fillSpeed * Time.deltaTime;
        }
        else
        {
            // �ִ밪�� �����ϸ� �ٽ� 0���� �����մϴ�.
            healthBar.value = 0;
        }
    }
}
