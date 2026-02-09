using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class prefap_confirmarNuevaSilleta : MonoBehaviour
{
    public Button botonConfirmar;
    public Button botonCancelar;
    public agregarSilletaEcena agregarSilletaEcenaScript;
    private int tipoSilleta = 0;
    public Transform padre; 
    // Start is called before the first frame update
    void Start()
    {
        botonConfirmar.onClick.AddListener(() => AgregarSilletaEspecifica(tipoSilleta));
        botonCancelar.onClick.AddListener(DesactivarVentana);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarVentana(int tipo)
    {
        tipoSilleta = tipo;
        gameObject.SetActive(true);
    }

    public void DesactivarVentana()
    {
        gameObject.SetActive(false);
        tipoSilleta = 0;
    }

    public void AgregarSilletaEspecifica(int tipo)
    {
        foreach (Transform hijo in padre)
        {
            Destroy(hijo.gameObject);
        }
        switch (tipo)
        {
            case 1:
                agregarSilletaEcenaScript.agregarStratix();
                DesactivarVentana();
                return;
            case 2:
                agregarSilletaEcenaScript.agregarMedioFactor();
                DesactivarVentana();
                return;
            case 3:
                agregarSilletaEcenaScript.agregarFactor();
                DesactivarVentana();
                return;
            case 4:
                agregarSilletaEcenaScript.agregarFactorMedio();
                DesactivarVentana();
                return;
            case 5:
                agregarSilletaEcenaScript.agregarDosFactor();
                DesactivarVentana();
                return;

        }
    }
}
