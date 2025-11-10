using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CloseEscene : MonoBehaviour
{
    public Button botonQuit;

    public void salirAplicacion()
    {
        Application.Quit();
        Debug.Log("Aplicación cerrada.");
    }

    private void Start()
    {
        botonQuit.onClick.AddListener(() => salirAplicacion());
    }
}
