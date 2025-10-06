using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjetoInteragivel : MonoBehaviour
{
    #region Variáveis e Componentes

    [Header("Elemento Visual da UI")]
    [Tooltip("Elemento visual que aparece quando o jogador pode interagir.")]
    public GameObject promptVisual;

    [Header("Configuração da Cena")]
    [Tooltip("Nome da cena que será carregada ao interagir com o objeto.")]
    public string nomeDaCenaParaCarregar;

    [Header("Fade")]
    [Tooltip("Imagem preta usada para o efeito de transição de tela.")]
    public Image fadePreto;

    [Tooltip("Duração da transição antes de trocar de cena.")]
    public float duracaoFade = 2f;

    private bool jogadorEstaNaArea = false;
    private bool emTransicao = false;

    #endregion

    #region Detecção de Área

    // Detecta quando o jogador entra na área de interação
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorEstaNaArea = true;
            promptVisual.SetActive(true);
        }
    }

    // Detecta quando o jogador sai da área de interação
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorEstaNaArea = false;
            promptVisual.SetActive(false);
        }
    }

    #endregion

    #region Lógica de Interação

    // Verifica se o jogador pressiona "F" enquanto está na área de interação
    private void Update()
    {
        if (!emTransicao && jogadorEstaNaArea && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(FazerFadeECarregarCena());
        }
    }

    // Realiza o fade na tela e troca de cena com transição suave
    private IEnumerator FazerFadeECarregarCena()
    {
        emTransicao = true;

        // Inicia o fade da música, se o gerenciador de música estiver presente
        MusicaManager mm = FindObjectOfType<MusicaManager>();
        if (mm != null)
        {
            mm.FadeOutMusica(duracaoFade);
        }

        float t = 0f;
        Color c = fadePreto.color;

        // Aumenta gradualmente a opacidade da tela preta (fade-in)
        while (t < duracaoFade)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(0f, 1f, t / duracaoFade);
            fadePreto.color = c;
            yield return null;
        }

        // Garante que o fade fique totalmente preto antes de trocar de cena
        c.a = 1f;
        fadePreto.color = c;

        // Carrega a nova cena configurada
        SceneManager.LoadScene(nomeDaCenaParaCarregar);
    }

    #endregion
}
