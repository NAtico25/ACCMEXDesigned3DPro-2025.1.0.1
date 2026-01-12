using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ent_usuario : MonoBehaviour
{
    public int id_usuario { get; set; }
    public string usuario { get; set; }
    public string contrasena { get; set; }
    public string rol { get; set; }
}

[System.Serializable]
public class json_usuario
{
    public int id_usuario;
    public string usuario;
    public string contrasena;
    public string rol;
}
