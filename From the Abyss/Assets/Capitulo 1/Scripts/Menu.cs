using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    #region Carregamento de Cenas

    public void LoadScenes(string cena)
    {
        SceneManager.LoadScene(cena);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
    }

    #endregion

    #region Encerramento do Jogo

    public void Quit()
    {
        Application.Quit();
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
    }

    #endregion

    #region Créditos

    public void AbrirCreditos(string LinkCreditos)
    {
        Application.OpenURL(LinkCreditos);
        Debug.Log("Abrindo link: " + LinkCreditos);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
    }

    #endregion
}
