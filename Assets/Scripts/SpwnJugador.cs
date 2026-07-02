using UnityEngine;

public class SpwnJugador : MonoBehaviour
{
    public GameObject mapachePrefab;
    public GameObject gatoPrefab;
    public GameObject cuyPrefab;

    void Start()
    {
        int personaje = PlayerPrefs.GetInt("Personaje", 0);
        if (personaje == 0)
        {
            Instantiate(mapachePrefab, transform.position, Quaternion.identity);
        }
        else if (personaje == 1)
        {
            Instantiate(gatoPrefab, transform.position, Quaternion.identity);
        }
        else if (personaje == 2)
        {
            Instantiate(cuyPrefab, transform.position, Quaternion.identity);
        }
    }
}
