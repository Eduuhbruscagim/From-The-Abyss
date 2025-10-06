using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicaManager : MonoBehaviour
{
    #region Variáveis e Componentes

    public AudioClip musicaSplashMenu;
    public AudioClip musicaCapitulo1;

    private AudioSource audioSource;
    private static MusicaManager instancia;

    #endregion

    #region Ciclo de Vida da Unity

    private void Awake()
    {
        if (instancia != null)
        {
            Destroy(gameObject);
            return;
        }

        instancia = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;

        // Configuro a música ao iniciar dentro da Unity
        DefinirMusica(SceneManager.GetActiveScene().name);

        // Continua reagindo a mudanças de cena
        SceneManager.sceneLoaded += OnCenaCarregada;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnCenaCarregada;
    }

    #endregion

    #region Gerenciamento de Música

    private void OnCenaCarregada(Scene cena, LoadSceneMode modo)
    {
        DefinirMusica(cena.name);
    }

    private void DefinirMusica(string nomeCena)
    {
        if (nomeCena == "Capitulo 1")
        {
            if (audioSource.clip != musicaCapitulo1)
            {
                TrocarMusicaComFade(musicaCapitulo1, 1.5f);
            }
        }
        else if (nomeCena == "Splash" || nomeCena == "Menu")
        {
            if (audioSource.clip != musicaSplashMenu)
            {
                TrocarMusicaComFade(musicaSplashMenu, 1.5f);
            }
        }
        else if (nomeCena == "Final")
        {
            FadeOutMusica(5f);
        }
    }

    private void TrocarMusicaComFade(AudioClip novaMusica, float duracao)
    {
        StartCoroutine(FadeTrocaMusica(novaMusica, duracao));
    }

    private IEnumerator FadeTrocaMusica(AudioClip novaMusica, float duracao)
    {
        if (audioSource.isPlaying)
        {
            // Fade-out
            float startVolume = audioSource.volume;

            for (float t = 0; t < duracao; t += Time.deltaTime)
            {
                audioSource.volume = Mathf.Lerp(startVolume, 0, t / duracao);
                yield return null;
            }

            audioSource.Stop();
        }

        // Troca e dá fade-in
        audioSource.clip = novaMusica;
        audioSource.Play();

        for (float t = 0; t < duracao; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0, 1, t / duracao);
            yield return null;
        }

        audioSource.volume = 1f;
    }

    public void FadeOutMusica(float duracao)
    {
        StartCoroutine(FadeOutCoroutine(duracao));
    }

    private IEnumerator FadeOutCoroutine(float duracao)
    {
        float startVolume = audioSource.volume;

        for (float t = 0; t < duracao; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / duracao);
            yield return null;
        }

        audioSource.volume = 0f;
        audioSource.Stop();
        audioSource.clip = null;
    }

    #endregion
}
