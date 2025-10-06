using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControladorJogo : MonoBehaviour
{
    #region Variáveis e Componentes

    public static ControladorJogo Controlador;
    public TextMeshProUGUI TextoMoeda;
    public int Moedas;

    #endregion

    #region Ciclo de Vida da Unity

    private void Awake()
    {
        if (Controlador == null)
        {
            Controlador = this;
        }
        else if (Controlador != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {

    }

    #endregion
}
