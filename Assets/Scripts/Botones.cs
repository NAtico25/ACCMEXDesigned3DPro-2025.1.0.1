using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Botones : MonoBehaviour
{
    /*Version 1.0: SE AGREGA LA SILLETA MANAGER PARA AGREGAR LOS BOTONES*/
    public SileltaManager sileltaManager;
    /*---Version 1.1: SE AGREGA EL TABLERO MANAGER PARA AGREGAR LOS BOTONES CORRESPONDIENTES*/
    public TableroManager tableroManager;

    public void OnColocarTipo1()
    {
        sileltaManager.ColocarSilletaAuto(sileltaManager.silletaTipo1, 1, new Vector3(0.256f, 0.135f, 0.539f));
    }

    public void OnColocarTipo2()
    {
        sileltaManager.ColocarSilletaAuto(sileltaManager.silletaTipo2, 2, new Vector3(0.2552f, 0.2614f, 0.5419f));
    }

    public void OnColocarTipo3()
    {
        sileltaManager.ColocarSilletaAuto(sileltaManager.silletaTipo3, 4, new Vector3(0.256f, 0.512f, 0.5388f));
    }

    public void OnColocarTipo4()
    {
        sileltaManager.ColocarSilletaAuto(sileltaManager.silletaTipo4, 3, new Vector3(-0.0018f, -0.15f, 0.0231f));
    }

    public void OnColocarTipo5()
    {
        sileltaManager.ColocarSilletaAuto(sileltaManager.silletaTipo5, 4, new Vector3(-0.05f, -0.207f, 0.785f));
    }

    public void OnColocarPlatina1()
    {
        tableroManager.ColocarTableroAuto(tableroManager.componenteTipo1, 7, new Vector3(0.27f, -0.953f, 0.1f));
    }

    public void OnEliminarUltima()
    {
        sileltaManager.EliminarUltimaSilleta();
    }

    /*-----VERSION 1.0: PUEBA DE COMO AGREGAR CON EL BOTON LOS COMPONENTES-------*/
    /*public void OnColocarTipo1()
    {
        sileltaManager.ColocarSilletaAuto(sileltaManager.silletaTipo1, 1);
    }

    public void OnColocarTipo2()
    {
        sileltaManager.ColocarSilletaAuto(sileltaManager.silletaTipo2, 2);
    }

    public void OnColocarTipo3()
    {
        sileltaManager.ColocarSilletaAuto(sileltaManager.silletaTipo3, 4);
    }*/
}
