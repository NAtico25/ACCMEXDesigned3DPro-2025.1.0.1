using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prefap_datosSilletaMinimizar : MonoBehaviour
{
    public GameObject ObjetoMaximizarMinimizar;
    public Button botonMaximiazarMininmizar;
    public Sprite iconoMaximizar;
    public Sprite iconoMinimizar;
    public bool estaMinimizada = false;
    // Start is called before the first frame update
    void Start()
    {
        botonMaximiazarMininmizar.onClick.AddListener(CambiarEstado);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CambiarEstado()
    {
        if (estaMinimizada)
        {
            Maximizar();
           
        }
        else
        {
            Minimizar();
            
        }
    }

    public void Maximizar()
    {
        ObjetoMaximizarMinimizar.SetActive(true);
        botonMaximiazarMininmizar.image.sprite = iconoMinimizar;
        estaMinimizada = false;
    }

    public void Minimizar()
    {
        ObjetoMaximizarMinimizar.SetActive(false);
        botonMaximiazarMininmizar.image.sprite = iconoMaximizar;
        estaMinimizada = true;
    }
}
