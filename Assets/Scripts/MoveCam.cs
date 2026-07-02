using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Transform obj;
    public float vcamara = 0.025f;
    public Vector3 desplazamiento;

    void LateUpdate()
    {
        // Si todavía no encuentra al jugador, lo busca
        if (obj == null)
        {
            GameObject jugador = GameObject.FindGameObjectWithTag("Player");

            if (jugador != null)
            {
                obj = jugador.transform;
            }
            else
            {
                return;
            }
        }

        Vector3 posicionD = obj.position + desplazamiento;
        Vector3 posicionS = Vector3.Lerp(transform.position, posicionD, vcamara);

        transform.position = posicionS;
    }
}
