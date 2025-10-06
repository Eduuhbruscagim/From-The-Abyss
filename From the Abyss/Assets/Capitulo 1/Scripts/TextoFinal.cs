using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextoFinal : MonoBehaviour
{
    #region Referências de UI

    [Header("Referências")]
    public TextMeshProUGUI caixaDeTexto;
    public Image imagemNormal;
    public Image imagemBlur;
    public TextMeshProUGUI avisoEnter;
    public Image fadePreto;

    #endregion

    #region Configurações de Texto e Transições

    [Header("Configurações")]
    public string[] frases;
    public float velocidade = 0.05f;
    public float pausaEntreFrases = 2f;
    public float tempoImagem = 3f;
    public float tempoTransicao = 2f;
    public float duracaoFadeAviso = 1f;
    public float duracaoFadeCena = 2f;

    [Header("Após o fim do texto")]
    public string nomeCenaMenu = "Menu";

    #endregion

    #region Estado Interno

    private bool textoTerminado = false;
    private Coroutine sequenciaCoroutine;

    #endregion

    #region Inicialização

    private void Start()
    {
        // Inicializa aviso e fade invisíveis
        if (avisoEnter != null)
        {
            Color c = avisoEnter.color;
            c.a = 0f;
            avisoEnter.color = c;
        }

        if (fadePreto != null)
        {
            Color c = fadePreto.color;
            c.a = 0f;
            fadePreto.color = c;
        }

        // Inicia a sequência final de imagens e texto
        sequenciaCoroutine = StartCoroutine(SequenciaFinal());
    }

    private void Update()
    {
        // Se o jogador apertar Enter, já pula para o texto finalizado
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!textoTerminado)
            {
                // Para a sequência atual e já mostra o texto finalizado
                if (sequenciaCoroutine != null)
                    StopCoroutine(sequenciaCoroutine);

                MostrarTextoFinalizado();
            }
            else
            {
                // Se o texto já terminou, inicia a transição de cena
                StartCoroutine(TransicaoCena());
            }
        }
    }

    #endregion

    #region Sequência de Texto e Imagem

    private IEnumerator SequenciaFinal()
    {
        // Estado inicial
        caixaDeTexto.text = "";
        SetAlpha(imagemNormal, 1f);
        SetAlpha(imagemBlur, 0f);

        // Mantém a imagem normal visível
        yield return new WaitForSeconds(tempoImagem);

        // Fade da imagem normal para blur
        float t = 0f;
        while (t < tempoTransicao)
        {
            t += Time.deltaTime;
            float alpha = t / tempoTransicao;
            SetAlpha(imagemNormal, 1f - alpha);
            SetAlpha(imagemBlur, alpha);
            yield return null;
        }

        // Texto letra por letra
        foreach (string frase in frases)
        {
            caixaDeTexto.text = "";
            foreach (char letra in frase)
            {
                caixaDeTexto.text += letra;
                yield return new WaitForSeconds(velocidade);
            }
            yield return new WaitForSeconds(pausaEntreFrases);
        }

        // Texto finalizado e inicia aviso piscante
        textoTerminado = true;
        if (avisoEnter != null)
            StartCoroutine(FadeAvisoLoop());
    }

    #endregion

    #region Mostrar Texto Imediatamente

    private void MostrarTextoFinalizado()
    {
        // Mostra todas as frases de uma vez
        caixaDeTexto.text = string.Join("\n", frases);

        // Deixa imagem normal invisível e blur totalmente visível
        SetAlpha(imagemNormal, 0f);
        SetAlpha(imagemBlur, 1f);

        // Marca como texto terminado e inicia aviso piscante
        textoTerminado = true;
        if (avisoEnter != null)
            StartCoroutine(FadeAvisoLoop());
    }

    #endregion

    #region Aviso Piscante

    private IEnumerator FadeAvisoLoop()
    {
        while (true)
        {
            yield return StartCoroutine(FadeAviso(0f, 1f)); // fade in
            yield return StartCoroutine(FadeAviso(1f, 0f)); // fade out
        }
    }

    private IEnumerator FadeAviso(float startAlpha, float endAlpha)
    {
        float t = 0f;
        Color c = avisoEnter.color;

        while (t < duracaoFadeAviso)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, t / duracaoFadeAviso);
            c.a = alpha;
            avisoEnter.color = c;
            yield return null;
        }

        c.a = endAlpha;
        avisoEnter.color = c;
    }

    #endregion

    #region Transição de Cena

    private IEnumerator TransicaoCena()
    {
        // Bloqueia múltiplos triggers
        textoTerminado = false;

        float t = 0f;
        Color c = fadePreto.color;

        // Fade para preto
        while (t < duracaoFadeCena)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(0f, 1f, t / duracaoFadeCena);
            fadePreto.color = c;
            yield return null;
        }

        c.a = 1f;
        fadePreto.color = c;

        // Carrega a cena do menu
        SceneManager.LoadScene(nomeCenaMenu);
    }

    #endregion

    #region Funções Auxiliares

    private void SetAlpha(Image img, float alpha)
    {
        Color c = img.color;
        c.a = alpha;
        img.color = c;
    }

    #endregion
}
