# Bubble Trials - Global Game Jam Jujuy 2025

Bubble Trials es un juego desarrollado en **Unity 6** durante la **Global Game Jam Jujuy 2025**. La temática de la jam fue **"burbujas"**, y el juego consiste en una serie de **minijuegos** donde el jugador controla una burbuja enfrentando diferentes desafíos.

## Características principales
- **Desarrollado en Unity 6**
- **Plataforma:** Windows PC
- **Varios minijuegos interconectados**
- **Sistema de puntajes y vidas**
- **Interfaz gráfica mejorada**
- **Transiciones animadas entre escenas**

## Minijuegos implementados
### **Game01 - Bubble Shooter** (Estilo Asteroids)
- Inspirado en **Asteroids**, pero con burbujas.
- El jugador controla una burbuja que puede **disparar** para destruir burbujas rojas enemigas.
- Se gana puntos al eliminar burbujas enemigas.

### **Game03 - Flappy Bubble** (Estilo Flappy Bird)
- El jugador debe **saltar** para evitar obstáculos (tubos).
- Cada vez que pasa entre los tubos, gana puntos.
- Si choca contra un tubo o el suelo, **pierde una vida**.
- Cuando se acaban las vidas, el juego muestra la pantalla de Game Over.

### **Game02 (No completado)**
- No se llegó a implementar debido al tiempo limitado de la jam.

## Programación y estructura
El código del juego está estructurado de la siguiente manera:

- **`GameManager`**: Controla el flujo del juego, cambios de escena y actualiza la UI.
- **`SceneTransitionController`**: Gestiona las transiciones entre escenas con efectos de animación.
- **`LifeManager`**: Administra las vidas del jugador.
- **`ScoreManager`**: Maneja el sistema de puntuaciones.
- **`PlayerController`** (en Game03): Controla el movimiento del jugador y la detección de colisiones.
- **`TubeSpawner`**: Genera obstáculos en Game03.
- **`PlayerCollision`**: Controla las colisiones y efectos visuales de invulnerabilidad.
- **`ScoreZone`**: Detecta cuando el jugador pasa entre los tubos y suma puntos.

## Presentación en la Global Game Jam
El juego fue completado y presentado en la **Global Game Jam Jujuy 2025**, donde se destacó por su jugabilidad sencilla pero desafiante, su estética con **sprites hechos en Aseprite**, y la variedad de minijuegos implementados en el tiempo disponible.

---
**Desarrollado por:** Trident Games
 Gabriel Flores, Jonathan Calapeña y Evelyn Ramos.

¡Gracias por jugar Bubble Trials! 🚀

