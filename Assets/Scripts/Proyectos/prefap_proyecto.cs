using System;
using System.Data;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class prefap_proyecto : MonoBehaviour
{
    public CanvasRenderer favoritoProyecto;
    public TextMeshProUGUI nombreProyecto;
    public TextMeshProUGUI ultimaModificacionProyecto;
    public TextMeshProUGUI fechaProyecto;
    public int idProyecto;
    // Start is called before the first frame update

    public void SetData(int id, string nombre, string fecha)
    {
        idProyecto = id;
        nombreProyecto.text = nombre;
        fechaProyecto.text = fecha;
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
