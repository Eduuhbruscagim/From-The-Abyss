using UnityEngine;

public class ParedeFalsaController : MonoBehaviour
{
    #region Configurações

    [Tooltip("Tag usada no Personagem para detectar colisão.")]
    public string playerTag = "Player";

    [Tooltip("Indica se esta parede é falsa (ja criada no Tiled. NAO MEXER NISSO AQUI DE JEITO NENHUM, OU O JOGO INTEIRO QUEBRA.")]
    public bool isFakeWall = false;

    #endregion

    #region Detecção de Colisão

    // Chamado quando algum objeto entra no collider da parede
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que entrou é o jogador e se a parede é falsa
        if (other.CompareTag(playerTag) && isFakeWall)
        {
            // Pega o componente SpriteRenderer para controlar a visibilidade
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            // Desativa a renderização, fazendo a parede "sumir"
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false;
            }
        }
    }

    #endregion
}
