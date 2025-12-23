# 🌑 From the Abyss

![Banner do Jogo](https://placehold.co/600x200?text=Screenshot+do+Jogo)

> **Status:** Concluído (Projeto de TCC) | **Engine:** Unity 2022.3.62f2

## 📜 Sobre o Projeto

**From the Abyss** é um jogo de plataforma 2D desenvolvido como Trabalho de Conclusão de Curso (TCC). O projeto explora mecânicas clássicas de precisão e coleta, implementadas na **Unity Engine** com foco em fluidez de movimentação e estruturação de sistemas em C#.

O jogador controla um protagonista que deve superar obstáculos verticais e inimigos, utilizando habilidades progressivas para avançar entre as fases.

## 🎮 Mecânicas e Funcionalidades

O gameplay foi construído focando na responsividade dos controles (Input System):

* **Sistema de Movimentação:** Controle horizontal com inércia ajustada.
* **Pulo e Pulo Duplo:** Lógica de detecção de solo (Ground Check) para permitir ou bloquear saltos aéreos.
* **Dash:** Habilidade de impulso rápido para esquiva e travessia de obstaculos.
* **Coleta de Itens:** Sistema de moedas com feedback visual.
* **Gestão de Cenas:** Transições suaves entre Menu, Fases e Telas de Fim de Jogo.

## 🛠️ Tecnologias e Ferramentas

* **Motor Gráfico:** Unity 2022.3.62f2 (LTS)
* **Linguagem:** C#
* **Design & Arte:** Photoshop, Pixilart, Aseprite, Figma
* **Versionamento:** Git

## 🚀 Como Jogar (Instalação)

### Opção 1: Jogar a Build (Recomendado)
Você pode baixar a versão compilada para Windows através do link abaixo:

👉 **https://from-the-abyss.vercel.app/**

### Opção 2: Executar o Projeto (Para Devs)
1.  Clone este repositório.
2.  Abra o **Unity Hub** e adicione a pasta do projeto.
3.  Certifique-se de ter a versão **2022.3.62f2** instalada.
4.  Abra a cena `Assets/Scenes/Menu.unity` e dê Play.

## 🕹️ Controles

| Ação | Teclado |
| :--- | :--- |
| **Mover** | `A` / `D` ou `Setas` |
| **Pular** | `Espaço` (Pressione 2x para Pulo Duplo) |
| **Dash** | `Shift Esquerdo` |

## 🗂 Estrutura do Projeto

* `Assets/Scripts`: Lógica principal (PlayerController, GameManager, UI).
* `Assets/Scenes`: Fluxo do jogo (Menu, Fase 1, Splash).
* `Assets/Prefabs`: Objetos instanciáveis (Moedas, Inimigos, Player).
* `Assets/Animations`: Controladores de animação (Animator).

## 👨‍💻 Autor

**Eduardo Guilherme Bruscagim**
* [LinkedIn](https://www.linkedin.com/in/eduardo-guilherme-bruscagim-8051a3233/) * [GitHub](https://github.com/Eduardo-Bruscagim)

---
*Desenvolvido para fins acadêmicos e aprimoramento em desenvolvimento de jogos.*
