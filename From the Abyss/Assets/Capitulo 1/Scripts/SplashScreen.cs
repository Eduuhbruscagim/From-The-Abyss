using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashScreen : MonoBehaviour
{
    #region Configurações da Splash

    [Header("Imagem do Título")]
    [Tooltip("Imagem que será exibida na splash screen.")]
    public Image titleImage;

    [Header("Tempos de Transição")]
    [Tooltip("Duração do fade-in inicial.")]
    public float fadeInDuration = 1.0f;

    [Tooltip("Tempo que a imagem permanece visível.")]
    public float displayDuration = 1.3f;

    [Tooltip("Duração do fade-out final.")]
    public float fadeOutDuration = 1.1f;

    [Header("Escala e Overshoot")]
    [Tooltip("Escala final após o fade-in.")]
    public float fadeInScale = 1.08f;

    [Tooltip("Escala máxima durante o fade-out.")]
    public float fadeOutOvershoot = 1.12f;

    [Header("Cores")]
    [Tooltip("Cor inicial da imagem no fade-in.")]
    public Color startColor = new Color(1f, 0.9f, 0.7f, 0f);

    [Tooltip("Cor final da imagem no fade-out.")]
    public Color endColor = new Color(1f, 1f, 1f, 1f);

    #endregion


    #region Inicialização

    private void Start()
    {
        // Configura cor e escala inicial da imagem
        titleImage.color = startColor;
        titleImage.transform.localScale = Vector3.one * 0.92f;

        // Inicia sequência de animação
        StartCoroutine(FadeSequence());
    }

    #endregion


    #region Sequência de Fade

    private IEnumerator FadeSequence()
    {
        // Fade-in com aumento de escala
        yield return StartCoroutine(Fade(0f, 1f, fadeInDuration, Vector3.one * 0.92f, Vector3.one * fadeInScale, true));

        // Mantém a imagem visível por um tempo
        yield return new WaitForSeconds(displayDuration);

        // Fade-out com overshoot de escala
        yield return StartCoroutine(Fade(1f, 0f, fadeOutDuration, Vector3.one * fadeInScale, Vector3.one * 1.1f, false));

        // Carrega o menu principal
        SceneManager.LoadScene("Menu");
    }

    #endregion


    #region Função de Fade

    private IEnumerator Fade(float startAlpha, float endAlpha, float duration, Vector3 startScale, Vector3 endScale, bool fadeIn)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);

            // Curvas de easing: ease-in para fade-in, ease-out para fade-out
            t = fadeIn ? t * t : 1f - Mathf.Pow(1f - t, 3f);

            // Interpolação da cor e alpha
            Color c = Color.Lerp(startColor, endColor, t);
            c.a = Mathf.Lerp(startAlpha, endAlpha, t);
            titleImage.color = c;

            // Escala com overshoot no fade-out
            Vector3 scaleTarget = fadeIn ? endScale : Vector3.Lerp(endScale, Vector3.one * fadeOutOvershoot, Mathf.Sin(t * Mathf.PI * 0.5f));
            titleImage.transform.localScale = Vector3.Lerp(startScale, scaleTarget, t);

            yield return null;
        }

        // Define valores finais pra garantir nenhuma margem de erro
        Color finalColor = Color.Lerp(startColor, endColor, 1f);
        finalColor.a = endAlpha;
        titleImage.color = finalColor;
        titleImage.transform.localScale = fadeIn ? endScale : Vector3.one * 1.1f;
    }

    #endregion
}
