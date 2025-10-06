using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ColisaoEspinho : MonoBehaviour
{
    public enum ModoMorte { ReiniciarCena, Respawn }
    public ModoMorte modoMorte = ModoMorte.ReiniciarCena;

    [Header("Configurações Gerais")]
    public string nomeCena = "Capitulo 1";
    public Transform SpawnPoint;
    public Image flashImage;
    public float flashDuration = 0.1f;
    public float tempoMorte = 1f;

    private Animator animatorPersonagem;
    private Personagem movimentoScript;
    private Rigidbody2D rbPersonagem;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Pega os componentes do personagem
            animatorPersonagem = collision.gameObject.GetComponent<Animator>();
            movimentoScript = collision.gameObject.GetComponent<Personagem>();
            rbPersonagem = collision.gameObject.GetComponent<Rigidbody2D>();

            // Desativa o controle do jogador pra evitar bugs
            if (movimentoScript != null)
            {
                movimentoScript.enabled = false;
            }

            // Para o personagem no lugar, zerando a física
            if (rbPersonagem != null)
            {
                rbPersonagem.velocity = Vector2.zero;
                rbPersonagem.gravityScale = 0; // Congela ele no ar
            }

            // Ativa a animação de morte
            if (animatorPersonagem != null)
            {
                // 1. Cancela a animaçao de Pular
                animatorPersonagem.SetBool("Jump", false);

                // 2. Inicia a animação de morte
                animatorPersonagem.SetTrigger("Dead");
            }

            // Inicia os efeitos visuais e a lógica de morte
            StartCoroutine(FlashScreen());

            if (modoMorte == ModoMorte.ReiniciarCena)
            {
                StartCoroutine(ReiniciarDepois());
            }
            else if (modoMorte == ModoMorte.Respawn)
            {
                StartCoroutine(RespawnDepois(collision.gameObject));
            }
        }
    }

    IEnumerator FlashScreen()
    {
        if (flashImage != null)
        {
            Color originalColor = flashImage.color;
            flashImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.7f);
            yield return new WaitForSeconds(flashDuration);
            flashImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        }
    }

    IEnumerator ReiniciarDepois()
    {
        yield return new WaitForSeconds(tempoMorte);
        SceneManager.LoadScene(nomeCena);
    }

    IEnumerator RespawnDepois(GameObject player)
    {
        yield return new WaitForSeconds(tempoMorte);

        // Teleporta o jogador para o ponto de respawn
        player.transform.position = SpawnPoint.position;

        // Restaura a física do personagem para que ele possa se mover novamente
        if (rbPersonagem != null)
        {
            // A gravidade padrão no meu script de personagem é 3. Se eu mudar la, tenho que mudar aqui também.
            rbPersonagem.gravityScale = 3f;
        }

        // Garante que o personagem olhe para a direita
        SpriteRenderer spriteRendererPersonagem = player.GetComponent<SpriteRenderer>();
        if (spriteRendererPersonagem != null)
        {
            spriteRendererPersonagem.flipX = false;
        }

        // Reseta o gatilho da animação para que ele possa morrer de novo
        if (animatorPersonagem != null)
        {
            animatorPersonagem.ResetTrigger("Dead");
        }
    }
}