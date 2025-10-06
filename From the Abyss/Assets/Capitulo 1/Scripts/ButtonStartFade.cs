using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ButtonStartFade : MonoBehaviour
{
    [Header("Configuração da Cena")]
    public string nomeDaCenaParaCarregar = "Capitulo 1";

    [Header("Transição de Cena")]
    [Tooltip("Caixa de Seleçao dentro da Unity")]
    public Image fadeImage;
    [Tooltip("Duração da transição de fade.")]
    public float duracaoFade = 2f;

    // Chamado no evento OnClick do botão Start
    public void IniciarJogo()
    {
        StartCoroutine(TransicaoCena());
    }

    private IEnumerator TransicaoCena()
    {
        // Fade da música
        MusicaManager musica = FindObjectOfType<MusicaManager>();
        if (musica != null)
            musica.FadeOutMusica(duracaoFade);

        // Inicia o fade da tela preta
        float tempo = 0f;
        Color cor = fadeImage.color;
        cor.a = 0f;
        fadeImage.color = cor;

        while (tempo < duracaoFade)
        {
            tempo += Time.deltaTime;
            cor.a = Mathf.Lerp(0f, 1f, tempo / duracaoFade);
            fadeImage.color = cor;
            yield return null;
        }

        // Troca de cena após o término do fade
        SceneManager.LoadScene(nomeDaCenaParaCarregar);
    }
}
