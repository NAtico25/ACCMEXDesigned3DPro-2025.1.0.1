using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using UnityEngine;

public class proyectos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private async Task<DataTable> CargarProyectos()
    {
        DataTable dt_Proyectos = null;
        try
        {
            dt_Proyectos = await neg_proyectos.neg_obtenerProyectos();
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error al cargar proyectos: " + ex.Message);
        }
        return dt_Proyectos;
    }
}
