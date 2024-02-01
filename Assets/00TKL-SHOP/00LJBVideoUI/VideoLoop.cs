using UnityEngine;
using UnityEngine.Video;

public class VideoLoop : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        // ���� GameObject�� �ִ� VideoPlayer ������Ʈ�� ã���ϴ�.
        videoPlayer = GetComponent<VideoPlayer>();

        // VideoPlayer ������Ʈ�� �ִٸ� �����մϴ�.
        if (videoPlayer != null)
        {
            // ������ ���� �� ȣ��� �ݹ� �Լ��� �����մϴ�.
            videoPlayer.loopPointReached += EndReached;
        }
    }

    void EndReached(VideoPlayer vp)
    {
        // ������ ���� �����ϸ� ó������ �ٽ� ����մϴ�.
        vp.Play();
    }
}