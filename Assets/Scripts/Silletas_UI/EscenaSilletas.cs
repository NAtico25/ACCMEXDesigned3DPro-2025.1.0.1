using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaSilletas : MonoBehaviour
{
    // Cargar escena por nombre
    public void CargarEscena(string CrearSilleta)
    {
        SceneManager.LoadScene(CrearSilleta);
    }

    // Cargar escena por índice (Build Settings)
    public void CargarEscenaPorIndice(int indice)
    {
        SceneManager.LoadScene(indice);
    }

    // Recargar escena actual
    public void RecargarEscena()
    {
        Scene escenaActual = SceneManager.GetActiveScene();
        SceneManager.LoadScene(escenaActual.name);
    }
}
