using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using System.IO.Compression;
using System.IO;

public class Silleta : MonoBehaviour
{
    public string path;

    #region Getters y Setters publicos
    public string PosicionSilleta { get; set; }
    public Mat_piso.piso piso { get; set; }
    public Mat_porta_clemas portaClemas { get; set; }
    public Mat_clemas clemas { get; set; }
    public Mat_guia_silleta guiaSilleta { get; set; }
    public Mat_carretillas carretillas { get; set; }
    public Mat_acrilicos_separadores acrilicosSeparadores { get; set; }
    public Mat_clemas_fuerza clemas_fuerza { get; set; }
    public TipoSilleta tipoSilleta { get; set; }
    public Capacidad capacidad { get; private set; }
    public DataTable TablaSilleta { get; set; }
    #endregion

    #region Getters y Setters privados
    private string Nombre { get; set; }
    private string NumeroParte { get; set; }
    private string Descripcion { get; set; }
    private double Precio { get; set; }
    private Vector3 Coordenadas { get; set; }
    private Quaternion Rotacion { get; set; }
    #endregion


    public enum TipoSilleta
    {
        FVNR,
        VFD, 
        SMC,
        FCB,
        MCB,
        FUR,
        Stratix
    }

    public enum Capacidad
    {
        HP,
        AMP,
        Invalido
    }

    public Capacidad AsignarCapacidadTipoSilleta(TipoSilleta tipoSilleta)
    {
        Capacidad capacidad;
        switch (tipoSilleta)
        {
            case TipoSilleta.FVNR: return Capacidad.HP;
            case TipoSilleta.VFD: return Capacidad.HP;
            case TipoSilleta.SMC: return Capacidad.HP;
            case TipoSilleta.FCB: return Capacidad.AMP;
            case TipoSilleta.MCB: return Capacidad.AMP;
            case TipoSilleta.FUR: return Capacidad.HP;
            case TipoSilleta.Stratix: return Capacidad.Invalido;
            default: return Capacidad.Invalido;
        }

    }

    public Silleta(TipoSilleta tipo)
    {
        tipoSilleta = tipo;
        capacidad = AsignarCapacidadTipoSilleta(tipo);
    }
    // Nota: Aun no se prueba esta parte dejar para despues
    // Nota 2: Se creo otro public Silleta() para asignar capacidad al crear el objeto, esto de aqui se probara y se integrara despues
    //public Silleta()
    //{

    //    TablaSilleta.Columns.Add("Id", typeof(int));
    //    TablaSilleta.Columns.Add("Nombre", typeof(string));
    //    TablaSilleta.Columns.Add("NumeroParte", typeof(string));
    //    TablaSilleta.Columns.Add("Descripcion", typeof(string));
    //    TablaSilleta.Columns.Add("Precio", typeof(double));
    //    TablaSilleta.Columns.Add("Coordenadas", typeof(Vector3));
    //    TablaSilleta.Columns.Add("Rotacion", typeof(Quaternion));
    //}

    //public Silleta ObtenerDatosPorID(int id)
    //{
    //   for (int i = 0; i < TablaSilleta.Rows.Count; i++)
    //   {
    //        if ((int)TablaSilleta.Rows[i]["Id"] == id)
    //        {
    //            Silleta silleta = new Silleta
    //            {
    //                Nombre = (string)TablaSilleta.Rows[i]["Nombre"],
    //                NumeroParte = (string)TablaSilleta.Rows[i]["NumeroParte"],
    //                Descripcion = (string)TablaSilleta.Rows[i]["Descripcion"],
    //                Precio = (double)TablaSilleta.Rows[i]["Precio"],
    //                Coordenadas = (Vector3)TablaSilleta.Rows[i]["Coordenadas"],
    //                Rotacion = (Quaternion)TablaSilleta.Rows[i]["Rotacion"]
    //            };
    //            return silleta;
    //        }
    //   }
    //     return null;
    //}

    public GameObject BuscarModelo3D(Silleta silleta)
    {
         int contador = 0;
        try
        {
            string path = "Modelos3D/Silletas/" + silleta.Nombre + silleta.NumeroParte;
            GameObject modelo3D = Resources.Load<GameObject>(path);
            return modelo3D;
        }
        catch (System.Exception ex)
        {
            contador++;
            if (contador == 1)
            {
                //buscarEnDB();
                //descargarLocalmente();
                return BuscarModelo3D(silleta);
            }
            else
            {
                Debug.LogError("Error al cargar el modelo 3D: " + ex.Message);
                return null;
            }
        }
    }
    public void ProbarComprimirDescomprimir()
    {
        try
        {
            Debug.LogWarning("Convirtiendo a byte[]");
            byte[] compressedData = ComprimirCarpeta();
            string outputPath = "Assets/Models/ModeloDescomprimidos";
            Debug.LogWarning("Descomprimiendo");
            DescomprimirCarpeta(compressedData, outputPath);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error durante la compresión/descompresión: " + ex.Message);
        }
        }
    public byte[] ComprimirCarpeta()
    {
        byte[] compressedData;
        using (MemoryStream memoryStream = new MemoryStream())
        {
            using (ZipArchive zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
            {
                string[] files = System.IO.Directory.GetFiles(path, "*", System.IO.SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    string entryName = System.IO.Path.GetRelativePath(path, file);
                    zipArchive.CreateEntryFromFile(file, entryName);
                }
            }
            compressedData = memoryStream.ToArray();
        }
        return compressedData;
    }
    public void DescomprimirCarpeta(byte[] compressedData, string outputPath)
    {

        using (MemoryStream memoryStream = new MemoryStream(compressedData))
        {
            using (ZipArchive zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Read))
            {
                zipArchive.ExtractToDirectory(outputPath);
                Debug.LogWarning("Completado");
            }
        }
    }


    // --- Nota: Métodos para buscar en DB y descargar localmente no implementados ---
}
