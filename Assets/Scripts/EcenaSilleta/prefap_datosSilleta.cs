using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class prefap_datosSilleta : MonoBehaviour
{
    public TMP_InputField inputFieldNombre;
    public TMP_InputField inputFieldNumeroParte;
    public TMP_Dropdown dropdownTipoSilleta;
    public TMP_Dropdown dropdownCapacidadSilleta;
    public TMP_Dropdown dropdownPiso;
    public prefap_datosSilletaMinimizar Clemas;
    public prefap_datosSilletaMinimizar PortaClemas;
    public prefap_datosSilletaMinimizar GuiaDeSilletas;
    public prefap_datosSilletaMinimizar Carretillas;
    public prefap_datosSilletaMinimizar AcrilicosSeparadores;
    public prefap_datosSilletaMinimizar ClemasFuerza;
    public prefap_datosSilletaInterruptoresBotones InterruptoresBotones;

    // Start is called before the first frame update
    void Start()
    {
        //if (ProyectoManager.Instance.ent_silleta != null)
        //{
        //    Silleta silleta = ProyectoManager.Instance.ent_silleta;
        //    silleta.guiaSilleta.cantidad = 0;
        //    silleta.carretillas.cantidad = 0;
        //    silleta.acrilicosSeparadores.cantidad = 0;
        //    silleta.clemas_fuerza.cantidad = 0;
        //    inputFieldNombre.text = silleta.Nombre;
        //    inputFieldNumeroParte.text = silleta.NumeroParte;
        //    dropdownTipoSilleta.value = (int)silleta.tipoSilleta;
        //    dropdownCapacidadSilleta.value = (int)silleta.capacidad;
        //    dropdownPiso.value = (int)silleta.piso;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        Silleta silleta = new Silleta((Silleta.TipoSilleta)dropdownTipoSilleta.value);
        dropdownCapacidadSilleta.value = (int)silleta.AsignarCapacidadTipoSilleta((Silleta.TipoSilleta)dropdownTipoSilleta.value);
        //CargarDatosSilleta();

        //GuardarDatosSilleta();
    }

    public Silleta GuardarDatosSilleta()
    {
        Silleta nuevaSilleta = new Silleta((Silleta.TipoSilleta)dropdownTipoSilleta.value)
        {
            Nombre = inputFieldNombre.text,
            NumeroParte = inputFieldNumeroParte.text,
            piso = (Mat_piso.piso)dropdownPiso.value,
           
            portaClemas = new Mat_porta_clemas
            {
                Numero_Parte = PortaClemas.inputFieldNumeroParte.text,
                cantidad = PortaClemas.inputFieldCantidad.text != "" ? int.Parse(PortaClemas.inputFieldCantidad.text) : 0,
                Precio = PortaClemas.inputFieldPrecio.text != "" ? double.Parse(PortaClemas.inputFieldPrecio.text) : 0,
                descripcion = PortaClemas.inputFieldDescripcion.text
            },
            clemas = new Mat_clemas
            {
                Numero_Parte = Clemas.inputFieldNumeroParte.text,
                cantidad = Clemas.inputFieldCantidad.text != "" ? int.Parse(Clemas.inputFieldCantidad.text) : 0,
                Precio = Clemas.inputFieldPrecio.text != "" ? double.Parse(Clemas.inputFieldPrecio.text) : 0,
                descripcion = Clemas.inputFieldDescripcion.text
            },
            guiaSilleta = new Mat_guia_silleta
            {
                Numero_Parte = GuiaDeSilletas.inputFieldNumeroParte.text,
                cantidad = GuiaDeSilletas.inputFieldCantidad.text != "" ? int.Parse(GuiaDeSilletas.inputFieldCantidad.text) : 0,
                Precio = GuiaDeSilletas.inputFieldPrecio.text != "" ? double.Parse(GuiaDeSilletas.inputFieldPrecio.text) : 0,
                descripcion = GuiaDeSilletas.inputFieldDescripcion.text
            },
            carretillas = new Mat_carretillas
            {
                Numero_Parte = Carretillas.inputFieldNumeroParte.text,
                cantidad = Carretillas.inputFieldCantidad.text != "" ? int.Parse(Carretillas.inputFieldCantidad.text) : 0,
                Precio = Carretillas.inputFieldPrecio.text != "" ? double.Parse(Carretillas.inputFieldPrecio.text) : 0,
                descripcion = Carretillas.inputFieldDescripcion.text
            },
            acrilicosSeparadores = new Mat_acrilicos_separadores
            {
                Numero_Parte = AcrilicosSeparadores.inputFieldNumeroParte.text,
                cantidad = AcrilicosSeparadores.inputFieldCantidad.text != "" ? int.Parse(AcrilicosSeparadores.inputFieldCantidad.text) : 0,
                Precio = AcrilicosSeparadores.inputFieldPrecio.text != "" ? double.Parse(AcrilicosSeparadores.inputFieldPrecio.text) : 0,
                descripcion = AcrilicosSeparadores.inputFieldDescripcion.text
            },
            clemas_fuerza = new Mat_clemas_fuerza
            {
                Numero_Parte = ClemasFuerza.inputFieldNumeroParte.text,
                cantidad = ClemasFuerza.inputFieldCantidad.text != "" ? int.Parse(ClemasFuerza.inputFieldCantidad.text) : 0,
                Precio = ClemasFuerza.inputFieldPrecio.text != "" ? double.Parse(ClemasFuerza.inputFieldPrecio.text) : 0,
                descripcion = ClemasFuerza.inputFieldDescripcion.text
            },
            interruptores = InterruptoresBotones.ObtenerDatosInterruptoresBotones()

        };
        
        Debug.Log("Datos de silleta guardados: " + nuevaSilleta.Nombre + ", " + nuevaSilleta.NumeroParte + ", " + nuevaSilleta.tipoSilleta + ", " + nuevaSilleta.capacidad + ", " + nuevaSilleta.piso);
        return nuevaSilleta;
    }

    public void CargarDatosSilleta()
    {
        if (ProyectoManager.Instance.ent_silleta == null)
        {
            Clemas.Minimizar();
            PortaClemas.Minimizar();
            GuiaDeSilletas.Minimizar();
            Carretillas.Minimizar();
            AcrilicosSeparadores.Minimizar();
            ClemasFuerza.Minimizar();
        }
        else
        {
            if (ProyectoManager.Instance.ent_silleta.clemas != null)
            {
                if (ProyectoManager.Instance.ent_silleta.clemas.cantidad > 0)
                    Clemas.Maximizar();
                else
                    Clemas.Minimizar();
            }
            else
                Clemas.Minimizar();



            if (ProyectoManager.Instance.ent_silleta.portaClemas != null)
            {
                if (ProyectoManager.Instance.ent_silleta.portaClemas.cantidad > 0)
                    PortaClemas.Maximizar();
                else
                    PortaClemas.Minimizar();

            }
            else
                PortaClemas.Minimizar();

            if (ProyectoManager.Instance.ent_silleta.guiaSilleta != null)
            {
                if (ProyectoManager.Instance.ent_silleta.guiaSilleta.cantidad > 0)
                    GuiaDeSilletas.Maximizar();
                else
                    GuiaDeSilletas.Minimizar();
            }

            if (ProyectoManager.Instance.ent_silleta.carretillas != null)
            {
                if (ProyectoManager.Instance.ent_silleta.carretillas.cantidad > 0)
                    Carretillas.Maximizar();
                else
                    Carretillas.Minimizar();
            }
            else
                Carretillas.Minimizar();

            if (ProyectoManager.Instance.ent_silleta.acrilicosSeparadores != null)
            {
                if (ProyectoManager.Instance.ent_silleta.acrilicosSeparadores.cantidad > 0)
                    AcrilicosSeparadores.Maximizar();
                else
                    AcrilicosSeparadores.Minimizar();
            }
            else
                AcrilicosSeparadores.Minimizar();

            if (ProyectoManager.Instance.ent_silleta.clemas_fuerza != null)
            {
               if (ProyectoManager.Instance.ent_silleta.clemas_fuerza.cantidad > 0)
                    ClemasFuerza.Maximizar();
                else
                    ClemasFuerza.Minimizar();
            }
            else
                ClemasFuerza.Minimizar();
        }
    }

}
