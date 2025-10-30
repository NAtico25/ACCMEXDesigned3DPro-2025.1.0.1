using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cantidad_silletas : MonoBehaviour
{
    public SileltaManager manager;
    // Start is called before the first frame update
    void Start()
    {

        // Colocar una silleta tipo 1 en el primer espacio
        manager.PlaceSilleta(0, manager.silletaTipo1, 1, new Vector3(0.256f, 0.135f, 0.539f));

        // Colocar una silleta tipo 2 en el slot 2
        manager.PlaceSilleta(2, manager.silletaTipo2, 2, new Vector3(0.2552f, 0.2614f, 0.5419f));

        // Colocar una silleta tipo 3 en el slot 6
        manager.PlaceSilleta(6, manager.silletaTipo3, 4, new Vector3(0.256f, 0.512f, 0.5388f));

        // Colocar una silleta tipo 4
        manager.PlaceSilleta(3, manager.silletaTipo4, 3, new Vector3(-0.0018f, -0.15f, 0.0231f));

        // Colocar una silleta tipo 5
        manager.PlaceSilleta(2, manager.silletaTipo5, 4, new Vector3(-0.05f, -0.207f, 0.785f));

        /*
        // Colocar una silleta tipo 1 en el primer espacio
        manager.PlaceSilleta(0, manager.silletaTipo1, 1);

        // Colocar una silleta tipo 2 en el slot 2
        manager.PlaceSilleta(2, manager.silletaTipo2, 2);

        // Colocar una silleta tipo 3 en el slot 6
        manager.PlaceSilleta(6, manager.silletaTipo3, 4);
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
