using UnityEngine;

public class Uimanager : MonoBehaviour
{
    public static Uimanager Instance;

    public Animator[] gems;
    public GameObject panelGameOver;

    private void Awake()
    {
        Instance = this;
    }

    public void RomperGema(int indice)
    {
        if (indice >= 0 && indice < gems.Length)
        {
            gems[indice].SetTrigger("Break");
        }
    }

    public void MostrarGameOver()
    {
        panelGameOver.SetActive(true);
        Time.timeScale = 0f;
    }
}
