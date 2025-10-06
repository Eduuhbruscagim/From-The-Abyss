using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuTransition : MonoBehaviour
{
    #region Variáveis de Transição

    public CanvasGroup CanvasGroup;
    public float fadeDuration = 1.2f;

    #endregion

    #region Métodos Públicos

    public void LoadCapitulo1()
    {
        StartCoroutine(FadeOutAndLoad("Capitulo 1"));
    }

    #endregion

    #region Corrotinas de Transição

    private IEnumerator FadeOutAndLoad(string sceneName)
    {
        float elapsed = 0f;

        CanvasGroup.interactable = false;
        CanvasGroup.blocksRaycasts = false;

        float startAlpha = CanvasGroup.alpha;
        float endAlpha = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.SmoothStep(0f, 1f, elapsed / fadeDuration);
            CanvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, t);
            yield return null;
        }

        CanvasGroup.alpha = endAlpha;

        SceneManager.LoadScene(sceneName);
    }

    #endregion
}
