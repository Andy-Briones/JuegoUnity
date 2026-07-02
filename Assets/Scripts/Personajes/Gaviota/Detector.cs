using UnityEngine;

public class Detector : MonoBehaviour
{
    public Gaviota gaviota;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gaviota.Caer();
        }
    }
}
