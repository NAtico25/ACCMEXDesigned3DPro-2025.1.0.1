using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class prefap_usuario : MonoBehaviour
{
    public CanvasRenderer usuarioActivo;
    public TextMeshProUGUI usuario;
    public TextMeshProUGUI fechaUsuario;
    public TextMeshProUGUI tipoUsuario;
    public int idUsuario;

    //public Button botonActivo;
    //public Sprite iconoFavoritoOn;
    //public Sprite iconoFavoritoOff;

    public void SetData(int id, string nombre, string fecha, string tipo_usuario)
    {
        idUsuario = id;
        usuario.text = nombre;
        fechaUsuario.text = fecha;
        tipoUsuario.text = tipo_usuario;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
