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
    public float distanciaDeLamicois;
    public GameObject lamicoiDoble;
    public GameObject prefabLamicoiDoble;
    public GameObject lamicoiTriple;
    public GameObject prefabLamicoiTriple;
    public GameObject mandoReenviado;
    public List<GameObject> listaComponentesAgregados;
    

    #region Getters y Setters publicos
    public TipoSilleta tipoSilleta { get; set; }
    public Capacidad capacidad { get; private set; }
    public string PosicionSilleta { get; set; }
    public Mat_piso.piso piso { get; set; }
    public Mat_porta_clemas portaClemas { get; set; }
    public Mat_clemas clemas { get; set; }
    public Mat_guia_silleta guiaSilleta { get; set; }
    public Mat_carretillas carretillas { get; set; }
    public Mat_acrilicos_separadores acrilicosSeparadores { get; set; }
    public Mat_clemas_fuerza clemas_fuerza { get; set; }
    public List<Mat_interruptor> interruptores { get; set; }
    public List<Mat_lamicoi> lamicois { get; set; }
    public List<Mat_adicionales> adicionales { get; set; }

   


    public string Nombre { get; set; }
    public string NumeroParte { get; set; }
    public string Descripcion { get; set; }
    public double Precio { get; set; }
    public Vector3 Coordenadas { get; set; }
    public Quaternion Rotacion { get; set; }
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
        Red,
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
            case TipoSilleta.Stratix: return Capacidad.Red;
            default: return Capacidad.Invalido;
        }

    }
    public Silleta(TipoSilleta tipo)
    {
        tipoSilleta = tipo;
        capacidad = AsignarCapacidadTipoSilleta(tipo);
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

    public void AplicarCambiosVisibles(Silleta silleta)
    {
        int cantidadLamicoi = 0;
        //int cantidadLamicoiTriple = 0;
        //int cantidadLamicoiCuadruple;
        //int cantidadLamicoiQuituple; 
        int cantidadInterruptores;

        //recorrer la lista de lamicois y destruir los objetos de la lista  
        foreach (GameObject componente in listaComponentesAgregados)
        {
            Destroy(componente);
        }

        //La cantidad sera igual a la cantidad de lamicois que tenga la silleta pero de tipo lamicoiDoble, si no tiene ninguno de ese tipo, la cantidad sera 0
        if (silleta.lamicois != null || silleta.lamicois.Count != 0)
        {

            //Recorrer todos los lamicois de la silleta   
            foreach (Mat_lamicoi lamicoi in silleta.lamicois)
            {
                if (lamicoi.TipoComponenteLamicoi == Mat_lamicoi.TipoLamicoi.Doble)
                {
                    cantidadLamicoi++;
                    AgregarLamicoiDoble(lamicoi, cantidadLamicoi);
                }
                else if (lamicoi.TipoComponenteLamicoi == Mat_lamicoi.TipoLamicoi.Triple)
                {
                    cantidadLamicoi++;
                    AgregarLamicoiTriple(lamicoi, cantidadLamicoi);
                }
            }
        }
        else
        {
            cantidadLamicoi = 0;
        }

        if (silleta.interruptores != null)
        {
            cantidadInterruptores = silleta.interruptores.Count;
            if(cantidadInterruptores > 0)
            {
                mandoReenviado.SetActive(true);
                // Se colocaran interruptores en la silleta dependiendo de la cantidad que se indique, se colocaran un poco mas abajo de lamicoiDoble
                //Vector3 PosicionLamicoiDoble = lamicoiDoble.transform.position;
                //for (int i = 0; i < cantidadInterruptores; i++)
                //{
                //    GameObject nuevoInterruptor = Instantiate(mandoReenviado);
                //    nuevoInterruptor.transform.SetParent(transform, false);
                //    nuevoInterruptor.transform.position = new Vector3(PosicionLamicoiDoble.x, PosicionLamicoiDoble.y - ((cantidadLamicoiDoble * 0.5f) + (i * 0.5f)), PosicionLamicoiDoble.z);
                //    nuevoInterruptor.transform.rotation = mandoReenviado.transform.rotation;
                //    nuevoInterruptor.name = "MandoReenviado_" + (i + 1);
                //    listaComponentesAgregados.Add(nuevoInterruptor);
                //}
            }
        }
        else
        {
            cantidadInterruptores = 0;
        }


    }

    
    public void AgregarLamicoiDoble(Mat_lamicoi lamicoi, int numeroLamicoi)
    {
        if (lamicoi.TipoComponenteLamicoi == Mat_lamicoi.TipoLamicoi.Doble)
        {
            if (numeroLamicoi == 1)
            {
                lamicoiDoble.SetActive(true);
                prefap_lamicoi scripLamicoiDoble = lamicoiDoble.GetComponent<prefap_lamicoi>();
                scripLamicoiDoble.ConfigurarSuperior(lamicoi);
                scripLamicoiDoble.ConfigurarInferior(lamicoi);
            }
            else
            {
                Vector3 PosicionLamicoiDoble = lamicoiDoble.transform.position;
            
                GameObject nuevoLamicoiDoble = Instantiate(prefabLamicoiDoble);
                nuevoLamicoiDoble.transform.SetParent(transform, false);
                nuevoLamicoiDoble.transform.position = new Vector3(PosicionLamicoiDoble.x, PosicionLamicoiDoble.y - (numeroLamicoi * distanciaDeLamicois), PosicionLamicoiDoble.z);
                nuevoLamicoiDoble.transform.rotation = lamicoiDoble.transform.rotation;
                nuevoLamicoiDoble.name = "LamicoiDoble_" + (numeroLamicoi);
                listaComponentesAgregados.Add(nuevoLamicoiDoble);
                prefap_lamicoi scripLamicoiDoble = nuevoLamicoiDoble.GetComponent<prefap_lamicoi>();
                scripLamicoiDoble.ConfigurarSuperior(lamicoi);
                scripLamicoiDoble.ConfigurarInferior(lamicoi);
            }
        }
        else
        {
            
        }
    }

    public void AgregarLamicoiTriple(Mat_lamicoi lamicoi, int numeroLamicoi)
    {
        if (lamicoi.TipoComponenteLamicoi == Mat_lamicoi.TipoLamicoi.Triple)
        {
            if (numeroLamicoi == 1)
            {
                lamicoiTriple.SetActive(true);
                prefap_lamicoiTriple scripLamicoiTriple = lamicoiTriple.GetComponent<prefap_lamicoiTriple>();
                scripLamicoiTriple.ConfigurarSuperior(lamicoi);
                scripLamicoiTriple.ConfigurarCentral(lamicoi);
                scripLamicoiTriple.ConfigurarInferior(lamicoi);
            }
            else
            {


                Vector3 PosicionLamicoiTriple = lamicoiTriple.transform.position;
                GameObject nuevoLamicoiTriple = Instantiate(prefabLamicoiTriple);
                nuevoLamicoiTriple.transform.SetParent(transform, false);
                nuevoLamicoiTriple.transform.position = new Vector3(PosicionLamicoiTriple.x, PosicionLamicoiTriple.y - (numeroLamicoi * distanciaDeLamicois), PosicionLamicoiTriple.z);
                nuevoLamicoiTriple.transform.rotation = lamicoiTriple.transform.rotation;
                nuevoLamicoiTriple.name = "LamicoiTriple_" + (numeroLamicoi);
                listaComponentesAgregados.Add(nuevoLamicoiTriple);
                prefap_lamicoiTriple scripLamicoiTriple = nuevoLamicoiTriple.GetComponent<prefap_lamicoiTriple>();
                scripLamicoiTriple.ConfigurarSuperior(lamicoi);
                scripLamicoiTriple.ConfigurarCentral(lamicoi);
                scripLamicoiTriple.ConfigurarInferior(lamicoi);
            }
        }
        else
        {
        }
    }

    // --- Nota: Métodos para buscar en DB y descargar localmente no implementados ---
}
