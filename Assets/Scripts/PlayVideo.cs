using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject cinematicPanel;
    public MenuManager menuManager;

    void Start()
    {
        videoPlayer.Stop();
        videoPlayer.loopPointReached += EndVideo;
    }
    void EndVideo(VideoPlayer vp)
    {
        cinematicPanel.SetActive(false);
        menuManager.FinCinematica();
    }
    public void IniciarCinematica()
    {
        cinematicPanel.SetActive(true);

        videoPlayer.Play();
    }
}
