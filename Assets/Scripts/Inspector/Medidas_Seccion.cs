using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Medida
{
    public class Medidas_Seccion : MonoBehaviour
    {
        public static Medidas_Seccion Instance;

        [Header("Referencia a los datos")]
        public ent_seccion seccion;

        [Header("InputFields")]
        public TMP_InputField inputLargo;
        public TMP_InputField inputAncho;
        public TMP_InputField inputProfundidad;
        public TMP_InputField inputTotal;


        [Header("UI")]
        public TMP_InputField inputTotalAncho;

        private List<ent_seccion> secciones = new List<ent_seccion>();

        void Awake()
        {
            CargarDatosEnUI();
            Instance = this;
        }


        void CargarDatosEnUI()
        {
            if (seccion == null) return;

            inputLargo.text = seccion.largo_Seccion.ToString();
            inputAncho.text = seccion.ancho_Seccion.ToString();
            inputProfundidad.text = seccion.profundidad_Seccion.ToString();
        }

        public void RegistrarSeccion(ent_seccion seccion)
        {
            if (!secciones.Contains(seccion))
            {
                secciones.Add(seccion);
                RecalcularTotales();
            }
        }

        public void EliminarSeccion(ent_seccion seccion)
        {
            if (secciones.Remove(seccion))
            {
                RecalcularTotales();
            }
        }

        public void RecalcularTotales()
        {

            int count = secciones.Count;

            if (count == 0)
            {
                inputTotalAncho.text = "0";
                return;
            }

            double totalAncho = -60;

            for (int i = 0; i < count; i++)
            {
                double ancho = secciones[i].ancho_Seccion;

                // SOLO si hay más de una sección
                if (count > 1)
                {
                    if (i == 0)
                        ancho += 2;

                    if (i == count - 1)
                        ancho += 2;
                }

                totalAncho += ancho;
            }

            inputTotalAncho.text = totalAncho.ToString();

            /*double totalAncho = -60;

            foreach (ent_seccion s in secciones)
                totalAncho += s.ancho_Seccion;

            inputTotalAncho.text = totalAncho.ToString();*/
        }
    }

}