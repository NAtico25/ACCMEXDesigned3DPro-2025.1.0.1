using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    public bool estado;

    public Button botonActivo;
    public Sprite spriteEstadoON;
    public Sprite spriteEstadoOff;
    ent_usuario ent_Usuario = new ent_usuario();

    public void SetData(int id, string nombre, string fecha, string tipo_usuario, bool estado_usuario)
    {
        idUsuario = id;
        usuario.text = nombre;
        fechaUsuario.text = fecha;
        tipoUsuario.text = tipo_usuario;
        estado = estado_usuario;

        if (estado)
            botonActivo.image.sprite = spriteEstadoON;
        else
            botonActivo.image.sprite = spriteEstadoOff;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        botonActivo.onClick.AddListener(ActivarUsuario);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async void ActivarUsuario()
    {
        try
        {
            ent_Usuario.id_usuario = idUsuario;
            DataTable dt_estadoProyecto = await neg_usuarios.neg_cambiarEstadoUsuario(ent_Usuario);

            if (dt_estadoProyecto != null && dt_estadoProyecto.Rows.Count > 0)
            {
                bool nuevoEstado = (bool)dt_estadoProyecto.Rows[0]["Estado"];
                if (nuevoEstado)
                    botonActivo.image.sprite = spriteEstadoON;
                else
                    botonActivo.image.sprite = spriteEstadoOff;

                Debug.Log($"Estado de usuario cambiado correctamente a {nuevoEstado}.");
            }
            
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error al cambiar estado de favorito: {ex.Message}");
        }

    }
}
