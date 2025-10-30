using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cantidad_TableroComp : MonoBehaviour
{
    public TableroManager manager;
    // Start is called before the first frame update
    void Start()
    {
        // Colocar una silleta tipo 1 en el primer espacio
        manager.PlaceTablero(0, manager.componenteTipo1, 1, new Vector3(0.27f, -0.953f, 0.1f));

        // Colocar una silleta tipo 2 en el slot 2
        manager.PlaceTablero(2, manager.componenteTipo2, 2, new Vector3(0.2552f, 0.2614f, 0.5419f));

        // Colocar una silleta tipo 3 en el slot 6
        manager.PlaceTablero(6, manager.componenteTipo3, 4, new Vector3(0.256f, 0.512f, 0.5388f));

        // Colocar una silleta tipo 4
        manager.PlaceTablero(3, manager.componenteTipo4, 3, new Vector3(-0.0018f, -0.15f, 0.0231f));

        // Colocar una silleta tipo 5
        manager.PlaceTablero(2, manager.componenteTipo5, 4, new Vector3(-0.05f, -0.207f, 0.785f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
