using System;
using System.Data;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class prefap_proyecto : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public CanvasRenderer favoritoProyecto;
    public TextMeshProUGUI nombreProyecto;
    public TextMeshProUGUI ultimaModificacionProyecto;
    public TextMeshProUGUI fechaProyecto;
    public int idProyecto;

    public Button botonFavorito;
    public Sprite iconoFavoritoOn;
    public Sprite iconoFavoritoOff;

    public Image fondo;    
    public Color normalColor = new Color(1, 1, 1, 0);      // transparente
    public Color hoverColor = new Color(0.8f, 0.8f, 0.8f, 0.3f);  // gris claro

    private float lastClickTime = 0f;
    private const float doubleClickThreshold = 0.25f;
    // Start is called before the first frame update

    public void SetData(int id, string nombre, string fecha)
    {
        idProyecto = id;
        nombreProyecto.text = nombre;
        fechaProyecto.text = fecha;
        
    }
    void Start()
    {
        if (fondo != null)
            fondo.color = normalColor;
        VerificarFavorito();

        ultimaModificacionProyecto.text = VerificarTiempoPasado();

        botonFavorito.onClick.AddListener(() =>
        {
            try
            {
                if (botonFavorito.image.sprite == iconoFavoritoOff)
                {
                    botonFavorito.image.sprite = iconoFavoritoOn;
                    AgregarFavorito();
                }
                else
                {
                    botonFavorito.image.sprite = iconoFavoritoOff;
                    QuitarFavorito();
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

    #region Eventos PunterosMouse
    public void OnPointerEnter(PointerEventData eventData)
    {
        fondo.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        fondo.color = normalColor;
    }
    #endregion

    #region Metodos  btn favorito

    private void AgregarFavorito()
    {
        PlayerPrefs.SetInt($"ProyectoFavorito_{idProyecto}", 1);
    }

    private void QuitarFavorito()
    {
        PlayerPrefs.SetInt($"ProyectoFavorito_{idProyecto}", 0);
    }
    private void VerificarFavorito()
    {
        try
        {
            if (PlayerPrefs.GetInt($"ProyectoFavorito_{idProyecto}") == 1)
                botonFavorito.image.sprite = iconoFavoritoOn;
            else
                botonFavorito.image.sprite = iconoFavoritoOff;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error al verificar favorito: {ex.Message}");
            botonFavorito.image.sprite = iconoFavoritoOff;
        }
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
            if(tiempoPasado.TotalSeconds < 60)
                tiempoPasadoStr = "Hace unos segundos";
            else if(tiempoPasado.TotalMinutes < 60)
                tiempoPasadoStr = $"Hace {Math.Floor(tiempoPasado.TotalMinutes)} minutos";
            else if(tiempoPasado.TotalHours < 24)
                tiempoPasadoStr = $"Hace {Math.Floor(tiempoPasado.TotalHours)} horas";
            else
                tiempoPasadoStr = $"Hace {Math.Floor(tiempoPasado.TotalDays)} días";


            Debug.Log($"Tiempo pasado desde la última interacción con el proyecto {idProyecto}: {tiempoPasado.TotalMinutes} minutos.");
        }
        return tiempoPasadoStr;
    }


    #endregion

}
