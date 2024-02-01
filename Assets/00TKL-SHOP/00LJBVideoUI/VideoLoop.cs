using UnityEngine;
using UnityEngine.Video;

public class VideoLoop : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        // 현재 GameObject에 있는 VideoPlayer 컴포넌트를 찾습니다.
        videoPlayer = GetComponent<VideoPlayer>();

        // VideoPlayer 컴포넌트가 있다면 설정합니다.
        if (videoPlayer != null)
        {
            // 비디오가 끝날 때 호출될 콜백 함수를 설정합니다.
            videoPlayer.loopPointReached += EndReached;
        }
    }

    void EndReached(VideoPlayer vp)
    {
        // 비디오가 끝에 도달하면 처음부터 다시 재생합니다.
        vp.Play();
    }
}