using UnityEngine;

public class SpawnGaviota : MonoBehaviour
{
    public GameObject gaviotaPrefab;

    public float tiempoEntreGaviotas = 20f;

    void Start()
    {
        InvokeRepeating(nameof(GenerarGaviota), 1f, tiempoEntreGaviotas);
    }

    void GenerarGaviota()
    {
        Vector3 posicion = transform.position;

        posicion.y += Random.Range(0f, 1f);

        Instantiate(
            gaviotaPrefab,
            posicion,
            Quaternion.identity
        );
    }
}
