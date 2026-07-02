using UnityEngine;

public class PausaManager : MonoBehaviour
{
    public GameObject panelPausa;

    public void Pausar()
    {
        panelPausa.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Reanudar()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
    }
}
