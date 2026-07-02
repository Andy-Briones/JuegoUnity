using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject panelMenu;
    public GameObject panelNiveles;
    public GameObject panelPj;
    public GameObject panelGameOver;
    public GameObject hud;
    public GameObject vidaboss;

    void Start()
    {
        panelMenu.SetActive(true);
        panelNiveles.SetActive(false);
        panelPj.SetActive(false);
        hud.SetActive(false);
        vidaboss.SetActive(false);
        Time.timeScale = 0f; // Pausa el juego
    }

    public void Jugar()
    {
        panelMenu.SetActive(false);
        panelGameOver.SetActive(false);
        hud.SetActive(true);
        vidaboss.SetActive(false);

        Time.timeScale = 1f;
    }
    //Niveles
    public void CargarNivel1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Nivel1");
    }

    public void CargarNivel2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Nivel2");
    }

    public void CargarNivel3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Nivel3");
    }
    public void MostrarNiveles()
    {
        hud.SetActive(false);

        panelMenu.SetActive(false);

        panelNiveles.SetActive(true);
    }
    public void MostrarPjs()
    {
        hud.SetActive(false);
        panelMenu.SetActive(false);
        panelPj.SetActive(true);
    }

    public void VolverMenu()
    {
        panelGameOver.SetActive(false);
        panelMenu.SetActive(true);
        hud.SetActive(false);

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
