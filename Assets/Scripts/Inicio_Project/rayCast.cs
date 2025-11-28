using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Collections.Specialized.BitVector32;

public class rayCast : MonoBehaviour
{

    public inpectorDinamico inspector;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                var seccion = hit.collider.GetComponent<ent_seccion>();
                if (seccion != null)
                {
                    inspector.MostrarObjeto(seccion);
                    Debug.Log("Click detectado en " + seccion.name);
                }
            }
            Debug.Log("Click en la pantalla" );
        }
    }



}
