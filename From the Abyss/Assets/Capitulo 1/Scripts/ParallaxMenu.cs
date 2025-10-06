using UnityEngine;

public class ParallaxMenu : MonoBehaviour
{
    #region Configurações

    [Header("Configurações do Parallax")]
    [Tooltip("Define o quanto a imagem se move conforme o movimento do mouse.")]
    public float intensidade = 30f;

    [Tooltip("Controla a suavidade da movimentação.")]
    public float suavizacao = 5f;

    [Header("Configurações do Zoom")]
    [Tooltip("Intensidade do efeito de zoom")]
    public float intensidadeZoom = 0.05f;

    [Tooltip("Velocidade do zoom")]
    public float velocidadeZoom = 1f;

    private RectTransform rect;
    private Vector3 posicaoInicial;
    private Vector3 escalaInicial;

    #endregion

    #region Inicialização

    // Guarda a posição e escala iniciais do elemento
    void Start()
    {
        rect = GetComponent<RectTransform>();
        posicaoInicial = rect.anchoredPosition;
        escalaInicial = rect.localScale;
    }

    #endregion

    #region Atualização do Efeito

    void Update()
    {
        // ===== EFEITO PARALLAX =====
        // Converte a posição do mouse em valores normalizados
        Vector2 mouseNormalizado = new Vector2(
            Input.mousePosition.x / Screen.width,
            Input.mousePosition.y / Screen.height
        );

        // Centraliza o ponto de referência no meio da tela
        mouseNormalizado -= new Vector2(0.5f, 0.5f);

        // Calcula o deslocamento baseado na intensidade configurada
        Vector3 deslocamento = new Vector3(
            mouseNormalizado.x * intensidade,
            mouseNormalizado.y * intensidade,
            0f
        );

        // Aplica o movimento suavizado de Parallax
        rect.anchoredPosition = Vector3.Lerp(
            rect.anchoredPosition,
            posicaoInicial + deslocamento,
            Time.deltaTime * suavizacao
        );

        // ===== EFEITO DE ZOOM ANIMADO =====
        // Cria uma oscilação suave (efeito de respiração)
        float fator = 1f + Mathf.Sin(Time.time * velocidadeZoom) * intensidadeZoom * 0.5f;
        rect.localScale = escalaInicial * fator;
    }

    #endregion
}
