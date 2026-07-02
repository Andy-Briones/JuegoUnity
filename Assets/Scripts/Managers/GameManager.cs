using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI Contador;

    private int basuraRecolectada = 0;

    private void Awake()
    {
        instance = this;
    }

    public void SumarBasura()
    {
        basuraRecolectada++;

        if (Contador != null)
        {
            Contador.text = "x " + basuraRecolectada;
        }
    }
}
