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
    public Camera digitalCamera; // 디지털 카메라를 Inspector에서 설정

    // 스크린샷을 찍는 메소드
    public void TakeScreenshot()
    {
        if (digitalCamera == null)
        {
            Debug.LogWarning("No digital camera assigned.");
            return;
        }

        // 파일 이름 생성
        string fileName = "screenshot-" + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png";

        // 디지털 카메라의 스크린샷 찍기
        digitalCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        digitalCamera.Render();
        RenderTexture.active = digitalCamera.targetTexture;
        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();

        // 파일로 저장
        byte[] bytes = screenshot.EncodeToPNG();
        System.IO.File.WriteAllBytes(fileName, bytes);

        // 리소스 정리
        RenderTexture.active = null;
        digitalCamera.targetTexture = null;

        Debug.Log("Screenshot captured from digital camera: " + fileName);
    }
}
/*using UnityEngine;

public class Screenshot : MonoBehaviour
{
    public Camera digitalCamera; // 디지털 카메라를 Inspector에서 설정

    // 스크린샷을 찍는 메소드
    public void TakeScreenshot()
    {
        if (digitalCamera == null)
        {
            Debug.LogWarning("No digital camera assigned.");
            return;
        }

        // 파일 이름 생성
        string fileName = "screenshot-" + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png";

        // 스크린샷을 찍을 때만 targetTexture 설정
        digitalCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);

        // 디지털 카메라의 스크린샷 찍기
        digitalCamera.Render();
        RenderTexture.active = digitalCamera.targetTexture;
        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();

        // targetTexture 및 리소스 정리
        digitalCamera.targetTexture = null;
        RenderTexture.active = null;

        // 파일로 저장
        byte[] bytes = screenshot.EncodeToPNG();
        System.IO.File.WriteAllBytes(fileName, bytes);

        Debug.Log("Screenshot captured from digital camera: " + fileName);
    }
}*/
