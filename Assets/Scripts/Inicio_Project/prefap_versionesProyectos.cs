using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class prefap_versionesProyectos : MonoBehaviour
{
    public TMP_InputField inputVersion;
    public int numeroVersion;
    public int id_Version;
    public string fechaCreacion;
    public ent_proyecto _Proyecto;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetData(int version, int id, string fecha, ent_proyecto ent_Proyecto)
    {
        numeroVersion = version;
        id_Version = id;
        fechaCreacion = fecha;
        inputVersion.text = "Versión: " + numeroVersion + " - " + fechaCreacion;
        _Proyecto = ent_Proyecto;
    }

    //Colocar todo este codigo de abajo donde se controlara todo
    public GameObject prefabItem;
    public Transform content;
    public async void CargarVersionesProyectos(ent_proyecto ent_Proyecto)
    {
        DataTable versiones = await neg_proyectos.neg_datosVersionesProyecto(ent_Proyecto);
        foreach (DataRow row in versiones.Rows)
        {
            // Instanciar prefab
            GameObject nuevo = Instantiate(prefabItem, content);

            // Obtener el script del prefab
            Debug.Log("Creando item para proyecto: " + row["Nombre"].ToString());
            prefap_versionesProyectos item = nuevo.GetComponent<prefap_versionesProyectos>();

            // Asignar datos de la BD
            int id = int.Parse(row["IdVersion"].ToString());
            int version = int.Parse(row["NumeroVersion"].ToString());
            DateTime fechadate = (DateTime)row["Fecha"];
            string fecha = fechadate.ToString("dd/MM/yyyy");
            byte[] archivoVersion = (byte[])row["Layout"];
            ent_proyecto ent_Proyecto1 = convertidor.ConvertirDesdeBytes(archivoVersion);

            Debug.Log($"Asignando datos al item: Id={id}, version ={version}, Fecha={fecha}");
            item.SetData(version, id, fecha, ent_Proyecto1);
        }
    }
}
