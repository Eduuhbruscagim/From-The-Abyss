# 🌑 From the Abyss

![Menu Principal](Screenshot%20Menu.jpg)

> **Status:** Concluído (Projeto de TCC) | **Engine:** Unity 2022.3.62f2

## 📜 Sobre o Projeto

**From the Abyss** é um jogo de plataforma 2D desenvolvido como Trabalho de Conclusão de Curso (TCC). O projeto explora mecânicas clássicas de precisão e coleta, implementadas na **Unity Engine** com foco em fluidez de movimentação e estruturação de sistemas em C#.

O jogador controla um protagonista que deve superar obstáculos verticais e inimigos, utilizando habilidades progressivas para avançar entre as fases.

## 🎮 Mecânicas e Funcionalidades

O gameplay foi construído focando na responsividade dos controles (Input System):

* **Sistema de Movimentação:** Controle horizontal com inércia ajustada.
* **Pulo e Pulo Duplo:** Lógica de detecção de solo (Ground Check) para permitir ou bloquear saltos aéreos.
* **Dash:** Habilidade de impulso rápido para esquiva e travessia de obstáculos.
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

## 🕹️ Controles

| Ação | Teclado |
| :--- | :--- |
| **Mover** | `W` / `A` / `S` / `D` ou `Setas` |
| **Pular** | `Espaço` (Pressione 2x para Pulo Duplo ou pressione por mais tempo para pular mais alto) |
| **Dash** | `Shift Esquerdo` |

## 🗂 Estrutura do Projeto

* `Assets/Scripts`: Lógica principal (PlayerController, GameManager, UI).
* `Assets/Scenes`: Fluxo do jogo (Menu, Fase 1, Splash).
* `Assets/Prefabs`: Objetos instanciáveis (Moedas, Inimigos, Player).
* `Assets/Animations`: Controladores de animação (Animator).

## 👨‍💻 Autor

**Eduardo Guilherme Bruscagim**
* [GitHub](https://github.com/Eduuhbruscagim)

---
*Desenvolvido para fins acadêmicos e aprimoramento em desenvolvimento de jogos.*
