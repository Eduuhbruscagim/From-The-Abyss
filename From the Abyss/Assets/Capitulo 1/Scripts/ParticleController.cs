using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    #region Configurações de Partículas

    [Header("Sistema de Partículas")]
    [Tooltip("Particle System usado para o efeito de poeira.")]
    [SerializeField] private ParticleSystem DustTrail;

    [Header("Configurações de Movimento")]
    [Tooltip("Velocidade mínima do personagem para ativar as partículas.")]
    [SerializeField] private int occurAfterVelocity;

    [Tooltip("Intervalo mínimo entre cada emissão de partículas.")]
    [SerializeField] private float dustFormatioPeriod;

    [Header("Referências")]
    [Tooltip("Rigidbody2D do personagem para verificar velocidade.")]
    [SerializeField] private Rigidbody2D rbPersonagem;

    [Tooltip("Referência ao script Personagem para verificar se está no chão.")]
    [SerializeField] private Personagem personagem;

    private float counter;

    #endregion
    

    #region Atualização

    private void Update()
    {
        counter += Time.deltaTime;

        // Se o personagem está no chão e se move acima da velocidade mínima
        if (personagem.EstaNoChao && Mathf.Abs(rbPersonagem.velocity.x) > occurAfterVelocity)
        {
            // Se já passou o tempo de intervalo, emite partículas
            if (counter > dustFormatioPeriod)
            {
                DustTrail.Play();
                counter = 0f;
            }
        }
    }

    #endregion
}
