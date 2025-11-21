using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class prefapAdmin_proyecto : MonoBehaviour, IPointerClickHandler
{
    public CanvasRenderer estadoProyecto;
    public TextMeshProUGUI nombreProyecto;
    public TextMeshProUGUI ultimaModificacionProyecto;
    public TextMeshProUGUI fechaProyecto;
    public int idProyecto;

    public Button botonEstadoProyecto;
    public Sprite spriteProyectoActivo;
    public Sprite spriteProyectoInactivo;

    
    private float lastClickTime = 0f;
    private const float doubleClickThreshold = 0.25f;
    private ent_proyecto ent_Proyecto = new ent_proyecto();


    public void SetData(int id, string nombre, string fecha, bool estado)
    {
        idProyecto = id;
        nombreProyecto.text = nombre;
        fechaProyecto.text = fecha;

        if (estado)
            botonEstadoProyecto.image.sprite = spriteProyectoActivo;
        else
            botonEstadoProyecto.image.sprite = spriteProyectoInactivo;

    }

    // Start is called before the first frame update
    async void Start()
    {
        ultimaModificacionProyecto.text = VerificarTiempoPasado();

        botonEstadoProyecto.onClick.AddListener(async () =>
        {
            try
            {
                ent_Proyecto.idProyecto = idProyecto;
                DataTable dt_estadoProyecto = await neg_proyectos.neg_cambiarEstadoProyecto(ent_Proyecto);

                if (dt_estadoProyecto != null && dt_estadoProyecto.Rows.Count > 0)
                {
                    bool nuevoEstado = (bool)dt_estadoProyecto.Rows[0]["DadoAlta"];
                    if (nuevoEstado)
                        botonEstadoProyecto.image.sprite = spriteProyectoActivo;
                    else
                        botonEstadoProyecto.image.sprite = spriteProyectoInactivo;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error al cambiar estado de favorito: {ex.Message}");
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        float timeSinceLastClick = Time.time - lastClickTime;

        if (timeSinceLastClick <= doubleClickThreshold)
        {
            // Doble clic detectado
            Debug.Log($"Doble clic en proyecto: {idProyecto} - {nombreProyecto.text}");
            OnClick();
        }

        lastClickTime = Time.time;
    }

    private void OnClick()
    {
        Debug.Log($"Proyecto seleccionado: {idProyecto} - {nombreProyecto.text}");
        UltimaVezInteract();
    }


    private void UltimaVezInteract()
    {
        PlayerPrefs.SetString($"UltimaInteraccion_{idProyecto}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

    }

    private string VerificarTiempoPasado()
    {
        string ultimaInteraccion = PlayerPrefs.GetString($"UltimaInteraccion_{idProyecto}", "");
        string tiempoPasadoStr = "";
        if (!string.IsNullOrEmpty(ultimaInteraccion))
        {
            DateTime ultimaFecha = DateTime.Parse(ultimaInteraccion);
            TimeSpan tiempoPasado = DateTime.Now - ultimaFecha;
            tiempoPasadoStr = $"{tiempoPasado.TotalMinutes} minutos";
            if (tiempoPasado.TotalSeconds < 60)
                tiempoPasadoStr = "Hace unos segundos";
            else if (tiempoPasado.TotalMinutes < 60)
                tiempoPasadoStr = $"Hace {Math.Floor(tiempoPasado.TotalMinutes)} minutos";
            else if (tiempoPasado.TotalHours < 24)
                tiempoPasadoStr = $"Hace {Math.Floor(tiempoPasado.TotalHours)} horas";
            else
                tiempoPasadoStr = $"Hace {Math.Floor(tiempoPasado.TotalDays)} días";


            Debug.Log($"Tiempo pasado desde la última interacción con el proyecto {idProyecto}: {tiempoPasado.TotalMinutes} minutos.");
        }
        return tiempoPasadoStr;
    }


    
}
