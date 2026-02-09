using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activar_prefap_menu_radial : MonoBehaviour
{
    public GameObject menuRadial;
    public agregarSilletaEcena agregarSilletaEcenaScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            menuRadial.SetActive(true);
            Vector2 mousePos = Input.mousePosition;
            menuRadial.transform.position = mousePos;
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            // usar getComponente de la clase prefap_menu_radial
            prefap_menu_radial menuRadialScript = menuRadial.GetComponent<prefap_menu_radial>();
            if(menuRadialScript.imagen1.isHovering)
                agregarSilletaEcenaScript.agregarStratix();
            if(menuRadialScript.imagen2.isHovering)
                agregarSilletaEcenaScript.agregarMedioFactor();
            if(menuRadialScript.imagen3.isHovering)
                agregarSilletaEcenaScript.agregarFactor();
            if(menuRadialScript.imagen4.isHovering)
                agregarSilletaEcenaScript.agregarFactorMedio();
            if(menuRadialScript.imagen5.isHovering)
                agregarSilletaEcenaScript.agregarDosFactor();

            menuRadial.SetActive(false);
        }
       // menuRadial.SetActive(Input.GetKey(KeyCode.Tab));
    }
}
