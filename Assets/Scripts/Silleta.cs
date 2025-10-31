using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using System.IO.Compression;
using System.IO;

public class Silleta : MonoBehaviour
{
    public string PosicionSilleta { get; set; }

    public string path;

    private string Nombre { get; set; }
    private string NumeroParte { get; set; }
    private string Descripcion { get; set; }
    private double Precio { get; set; }
    private Vector3 Coordenadas { get; set; }
    private Quaternion Rotacion { get; set; }

    public DataTable TablaSilleta { get; set; }
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

    public Silleta ObtenerDatosPorID(int id)
    {
       for (int i = 0; i < TablaSilleta.Rows.Count; i++)
       {
            if ((int)TablaSilleta.Rows[i]["Id"] == id)
            {
                Silleta silleta = new Silleta
                {
                    Nombre = (string)TablaSilleta.Rows[i]["Nombre"],
                    NumeroParte = (string)TablaSilleta.Rows[i]["NumeroParte"],
                    Descripcion = (string)TablaSilleta.Rows[i]["Descripcion"],
                    Precio = (double)TablaSilleta.Rows[i]["Precio"],
                    Coordenadas = (Vector3)TablaSilleta.Rows[i]["Coordenadas"],
                    Rotacion = (Quaternion)TablaSilleta.Rows[i]["Rotacion"]
                };
                return silleta;
            }
       }
         return null;
    }

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

    public byte[] ConvertirGameObjectToByte(GameObject obj)
    {
        // Esta función es un placeholder. La conversión real dependerá de cómo se quiera serializar el GameObject.
        return System.Text.Encoding.UTF8.GetBytes(obj.name);
    }

    public GameObject ConvertirByteToGameObject(byte[] data)
    {
        // Esta función es un placeholder. La conversión real dependerá de cómo se quiera deserializar el GameObject.
        string name = System.Text.Encoding.UTF8.GetString(data);
        GameObject obj = new GameObject(name);
        return obj;
    }

    // --- Nota: Métodos para buscar en DB y descargar localmente no implementados ---
}
