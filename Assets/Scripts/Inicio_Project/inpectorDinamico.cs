using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class inpectorDinamico : MonoBehaviour
{
    public GameObject textPrefap;
    public Transform contentPanel;

    
    public void MostrarObjeto(object obj)
    {
        Limpiar();

        if (obj == null)
        {
            CrearLinea("Objeto es NULL");
            return;
        }

        CrearLinea($"<b>{obj.GetType().Name}</b>");

        MostrarPropiedades(obj, 1);
    }

    void MostrarPropiedades(object obj, int indentLevel)
    {
        var properties = obj.GetType().GetProperties();  //Nota: igual se puede probar con BindingFlags.Public | BindingFlags.Instance dentro de GetProperties() pero aun no estoy seguro de como funciona asi que de momento lo dejo asi
        foreach (var property in properties) 
        {
            object propertyValue = property.GetValue(obj);
            if (propertyValue != null)
            {
                CrearLinea($"{Indent(indentLevel)}{property.Name}: NULL");
                continue;
            }

            if (propertyValue is Enumerable && propertyValue.GetType() != typeof(string))
            {
                CrearLinea($"{Indent(indentLevel)}{property.Name}: (Lista)");
                IEnumerable lista = (IEnumerable)propertyValue;
                int index = 0;
                foreach (var item in lista)
                {
                    CrearLinea($"{Indent(indentLevel + 1)}[{index}]");
                    MostrarSubObjeto(item, indentLevel + 2);
                    index++;
                }
                continue;
            }

            // En caso de que sea un objeto derivado de otra clase Mat_Nombre de la clase se mostraran sus propiedades
            if (!property.PropertyType.IsPrimitive && property.PropertyType != typeof(string) && !property.PropertyType.IsEnum)
            {
                CrearLinea($"{Indent(indentLevel)}{property.Name}:");
                MostrarSubObjeto(propertyValue, indentLevel + 1);
                continue;
            }

            CrearLinea($"{Indent(indentLevel)}{property.Name}: {propertyValue}");
        }
    }

    void MostrarSubObjeto(object subObj, int indent)
    {
        if (subObj == null)
        {
            CrearLinea($"{Indent(indent)}NULL");
            return;
        }

        var subProps = subObj.GetType().GetProperties();

        foreach (var prop in subProps)
        {
            object valor = prop.GetValue(subObj);

            CrearLinea($"{Indent(indent)}{prop.Name}: {valor}");
        }
    }

    void CrearLinea(string texto)
    {
        var go = Instantiate(textPrefap, contentPanel);
        go.GetComponent<Text>().text = texto;
    }

    string Indent(int level)
    {
        return new string(' ', level * 4);
    }

    void Limpiar()
    {
        foreach (Transform t in contentPanel)
            Destroy(t.gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
