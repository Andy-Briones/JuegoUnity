using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static int personajeSeleccionado = 0;

    public void ElegirMapache()
    {
        personajeSeleccionado = 0;
    }

    public void ElegirGato()
    {
        personajeSeleccionado = 1;
    }
    public void ElegirCuy()
    {
        personajeSeleccionado = 2;
    }
}
