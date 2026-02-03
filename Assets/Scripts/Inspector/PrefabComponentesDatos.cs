using TMPro;
using UnityEngine;

public class PrefabComponentesDatos : MonoBehaviour
{
    public TMP_Text txtNombre;
    public TMP_InputField inputValor;

    System.Action<string> onValueChanged;

    public void Configurar(string nombre, string valor, System.Action<string> callback)
    {
        txtNombre.text = nombre;
        inputValor.text = valor;

        onValueChanged = callback;
        inputValor.onEndEdit.AddListener(OnInputChanged);
    }

    void OnInputChanged(string nuevoValor)
    {
        onValueChanged?.Invoke(nuevoValor);
    }
}
