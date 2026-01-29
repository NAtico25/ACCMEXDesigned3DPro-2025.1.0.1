using UnityEngine.UI;
using UnityEngine;
using System.Runtime.Remoting.Messaging;

public class Foldout_Inspector : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject contenido; //Scroll view aqui iria
    public RectTransform flecha; //imagen de flecha

    bool abierto = false;

    public void Start()
    {
        contenido.SetActive(false);
    }

    public void AccionFoldout()
    {
        abierto = !abierto;

        //Muestra y oculta
        contenido.SetActive(abierto);

        //Rotar felcha
        if (flecha != null)
        {
            flecha.localRotation = Quaternion.Euler(0,0, abierto ? -90f : 0f);
        }
    }
}
