using UnityEngine;

public class Seleecionarpj : MonoBehaviour
{
    public GameObject bordeMapache;
    public GameObject bordeGato;
    public GameObject bordeCuy;

    public void SeleccionarMapache()
    {
        PlayerPrefs.SetInt("Personaje",0);

        bordeMapache.SetActive(true);
        bordeGato.SetActive(false);
        bordeCuy.SetActive(false);
    }

    public void SeleccionarGato()
    {
        PlayerPrefs.SetInt("Personaje", 1);

        bordeMapache.SetActive(false);
        bordeGato.SetActive(true);
        bordeCuy.SetActive(false);
    }
    public void SeleccionarCuy()
    {
        PlayerPrefs.SetInt("Personaje", 2);

        bordeMapache.SetActive(false);
        bordeGato.SetActive(false);
        bordeCuy.SetActive(true);
    }
}
