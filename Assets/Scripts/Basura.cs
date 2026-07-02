using UnityEngine;
using System.Collections;

public class Basura : MonoBehaviour
{
    private bool jugadorCerca = false;
    private Animator animator;

    private void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(RecogerBasura());
            //GameManager.instance.SumarBasura();
            //Destroy(gameObject);
        }
    }
    private IEnumerator RecogerBasura()
    {
        // Activar animación del player
        if (animator != null)
        {
            animator.SetTrigger("Coger");
        }

        // Pequeño delay para sincronizar con animación
        yield return new WaitForSeconds(0.3f);

        // Sumar basura
        GameManager.instance.SumarBasura();

        // Destruir objeto
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;

            animator = other.GetComponent<Animator>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;

            animator = null;
        }
    }
}
