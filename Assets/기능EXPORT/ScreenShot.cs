/*using UnityEngine;
using System;

public class Screenshot : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            ScreenCapture.CaptureScreenshot("screenshot-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png", 4);
        }
    }
}*/
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    public Camera digitalCamera; // ������ ī�޶� Inspector���� ����

    // ��ũ������ ��� �޼ҵ�
    public void TakeScreenshot()
    {
        if (digitalCamera == null)
        {
            Debug.LogWarning("No digital camera assigned.");
            return;
        }

        // ���� �̸� ����
        string fileName = "screenshot-" + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png";

        // ������ ī�޶��� ��ũ���� ���
        digitalCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        digitalCamera.Render();
        RenderTexture.active = digitalCamera.targetTexture;
        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();

        // ���Ϸ� ����
        byte[] bytes = screenshot.EncodeToPNG();
        System.IO.File.WriteAllBytes(fileName, bytes);

        // ���ҽ� ����
        RenderTexture.active = null;
        digitalCamera.targetTexture = null;

        Debug.Log("Screenshot captured from digital camera: " + fileName);
    }
}
/*using UnityEngine;

public class Screenshot : MonoBehaviour
{
    public Camera digitalCamera; // ������ ī�޶� Inspector���� ����

    // ��ũ������ ��� �޼ҵ�
    public void TakeScreenshot()
    {
        if (digitalCamera == null)
        {
            Debug.LogWarning("No digital camera assigned.");
            return;
        }

        // ���� �̸� ����
        string fileName = "screenshot-" + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png";

        // ��ũ������ ���� ���� targetTexture ����
        digitalCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);

        // ������ ī�޶��� ��ũ���� ���
        digitalCamera.Render();
        RenderTexture.active = digitalCamera.targetTexture;
        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();

        // targetTexture �� ���ҽ� ����
        digitalCamera.targetTexture = null;
        RenderTexture.active = null;

        // ���Ϸ� ����
        byte[] bytes = screenshot.EncodeToPNG();
        System.IO.File.WriteAllBytes(fileName, bytes);

        Debug.Log("Screenshot captured from digital camera: " + fileName);
    }
}*/
