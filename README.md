# Unidad 3 - Actividad 3.1: La escena principal y la estructura del personaje

Proyecto Unity **Aura Gamer Combat** — juego 2D de plataformas con personaje animado.

## Objetivo

Crear la escena principal y la estructura de un personaje para un juego en 2D.

## Criterios cumplidos

1. **Personaje principal con animación de estado por teclado**
   - **Idle** (quieto) → cuando no se presiona ninguna tecla
   - **Run** (correr) → cuando se presionan las flechas izquierda/derecha
   - **Jump** (saltar) → cuando se presiona la barra espaciadora
   - Las animaciones cambian automáticamente según el evento de teclado detectado.

2. **Estructura del personaje**
   - Componente `Rigidbody2D` con `Gravity Scale = 3`
   - Componente `Box Collider 2D` ajustado al sprite
   - Componente `Animator` con 3 estados y 4 transiciones
   - Script `PlayerController.cs` que lee el input y actualiza los parámetros `Speed` e `IsGrounded`
   - Objeto hijo `GroundCheck` para detectar si el personaje está en el suelo

3. **Escena principal 2D**
   - Cámara ortográfica (`Main Camera`)
   - Luz global 2D (`Global Light 2D`)
   - Fondo de cielo (`Background`)
   - Suelo con tierra (`Suelo`) y pasto (`Pasto`)
   - 5 rocas decorativas (`Roca_1` a `Roca_5`)
   - Música de fondo con botón de mute

4. **Repositorio público en GitHub**
   - URL: https://github.com/Osvaldo8005/Aura_Gamer_Combat

## Controles

| Tecla | Acción |
| :--- | :--- |
| **← / →** | Caminar izquierda/derecha |
| **Espacio** | Saltar |
| **Botón ♪** | Activar/silenciar música |

## Cómo abrir el proyecto en Unity

1. Instala **Unity Hub** y la versión del editor indicada (Unity 6 / `6000.6.x`).
2. En Unity Hub: **Open** → selecciona la carpeta del repositorio clonado.
3. Abre la escena `Assets/Scenes/SampleScene.unity`.
4. Pulsa **Play** para probar el personaje.

## Archivos principales

- `Assets/Scripts/PlayerController.cs` → Movimiento y animaciones del jugador
- `Assets/Scripts/MusicController.cs` → Control de música (activar/silenciar)
- `Assets/Sprites/Character/` → Sprites y animaciones del personaje (Idle, Run, Jump)
- `Assets/Sprites/Escenario/` → Fondo, suelo, rocas y decoración
- `Assets/Audio/` → Música de fondo

## Repositorio

https://github.com/Osvaldo8005/Aura_Gamer_Combat