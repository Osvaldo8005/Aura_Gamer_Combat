# Unidad 3 - Actividad 3.1: La escena principal y la estructura del personaje

Proyecto Unity **Aura Gamer Combat** - juego 2D de plataformas con personaje animado.

## Objetivo

Crear la escena principal y la estructura de un personaje para un juego en 2D.

## Criterios cumplidos

1. **Personaje principal con animacion de estado por teclado**
   - **Idle** (quieto) - cuando no se presiona ninguna tecla
   - **Run** (correr) - cuando se presionan las flechas izquierda/derecha
   - **Jump** (saltar) - cuando se presiona la barra espaciadora
   - Las animaciones cambian automaticamente segun el evento de teclado detectado.

2. **Estructura del personaje**
   - Componente `Rigidbody2D` con `Gravity Scale = 3`
   - Componente `Box Collider 2D` ajustado al sprite
   - Componente `Animator` con 3 estados y 4 transiciones
   - Script `PlayerController.cs` que lee el input y actualiza los parametros `Speed` e `IsGrounded`
   - Objeto hijo `GroundCheck` para detectar si el personaje esta en el suelo

3. **Escena principal 2D**
   - Camara ortografica (`Main Camera`)
   - Luz global 2D (`Global Light 2D`)
   - Fondo de cielo (`Background`)
   - Suelo con tierra (`Suelo`) y pasto (`Pasto`)
   - 5 rocas decorativas (`Roca_1` a `Roca_5`)
   - Musica de fondo con boton de mute

4. **Repositorio publico en GitHub**
   - URL: https://github.com/Osvaldo8005/Aura_Gamer_Combat

## Controles

| Tecla | Accion |
| :--- | :--- |
| **Izquierda / Derecha** | Caminar izquierda/derecha |
| **Espacio** | Saltar |
| **Boton de nota** | Activar/silenciar musica |

## Como abrir el proyecto en Unity

1. Instala **Unity Hub** y la version del editor indicada (Unity 6 / `6000.6.x`).
2. En Unity Hub: **Open** - selecciona la carpeta del repositorio clonado.
3. Abre la escena `Assets/Scenes/SampleScene.unity`.
4. Pulsa **Play** para probar el personaje.

## Archivos principales

- `Assets/Scripts/PlayerController.cs` - Movimiento y animaciones del jugador
- `Assets/Scripts/MusicController.cs` - Control de musica (activar/silenciar)
- `Assets/Sprites/Character/` - Sprites y animaciones del personaje (Idle, Run, Jump)
- `Assets/Sprites/Escenario/` - Fondo, suelo, rocas y decoracion
- `Assets/Audio/` - Musica de fondo


---

# Unidad 3 - Actividad 3.2: Los prefabs

Se agrego un sistema de disparo con prefab de proyectil y efectos de sonido.

## Criterios cumplidos

1. **El personaje dispara al detectar el evento del teclado**
   - Se presiona **Ctrl + F** para disparar.
   - Cooldown de 0.5 segundos entre disparos.

2. **La bala no sale del centro del personaje**
   - El proyectil sale desde la **punta de la espada** (`PuntoDisparo`).
   - `PuntoDisparo` esta alineado con el sprite del personaje.

3. **La bala sale en direccion del personaje**
   - Si el personaje mira a la derecha, el proyectil va a la derecha.
   - Si mira a la izquierda, va a la izquierda.

4. **Prefab del proyectil**
   - `Assets/Sprites/Proyectil/Proyectil.prefab`
   - Contiene: Sprite Renderer, Rigidbody 2D (Kinematic), Box Collider 2D (Is Trigger), Audio Source, Script `Projectile.cs`.
   - El proyectil crece mientras avanza y explota al final (o al impactar).
   - Al explotar, reproduce el sonido `magic58-vapor`.

5. **Musica de fondo con control de mute**
   - Musica: `11. Celestial Path` (loop).
   - Boton de nota para activar/silenciar.

## Controles

| Tecla | Accion |
| :--- | :--- |
| **Izquierda / Derecha** | Caminar |
| **Espacio** | Saltar |
| **Ctrl + F** | Disparar proyectil |
| **Boton de nota** | Activar/silenciar musica |

## Archivos nuevos

- `Assets/Scripts/Projectile.cs` - Comportamiento del proyectil (movimiento, crecimiento, explosion, sonido)
- `Assets/Sprites/Proyectil/Proyectil.prefab` - Prefab del proyectil
- `Assets/Sprites/Proyectil/instanceportal_385x385.png` - Sprite del proyectil (onda de aura)
- `Assets/Audio/magic58-vapor.flac` - Sonido de explosion

## Repositorio

https://github.com/Osvaldo8005/Aura_Gamer_Combat


---

# Unidad 3 - Actividad 3.3: Programacion de mecanicas y fisicas

Se configuraron las mecanicas de fisicas para el personaje del juego 2D.

## Criterios cumplidos

1. **El personaje simula gravedad dentro de la escena**
   - El `Rigidbody2D` del jugador tiene `Gravity Scale = 3`.
   - El personaje cae hacia el suelo automaticamente al iniciar.
   - No flota ni queda suspendido en el aire.

2. **El personaje puede saltar desde el evento designado**
   - Al presionar la **barra espaciadora**, el personaje salta.
   - Solo puede saltar cuando esta en el suelo (`isGrounded = true`).
   - La fuerza de salto es `jumpForce = 12`.
   - La animacion cambia a **Jump** mientras esta en el aire.

3. **El personaje colisiona con el suelo de la escena**
   - El `Suelo` tiene un `Box Collider 2D` en la capa `Ground`.
   - El jugador tiene un `Box Collider 2D` ajustado a su sprite.
   - El `GroundCheck` (hijo del jugador) detecta la colision con el suelo usando `Physics2D.OverlapCircle`.

4. **Enlace del repositorio publico**
   - URL: https://github.com/Osvaldo8005/Aura_Gamer_Combat

5. **Puntualidad en la entrega**

## Mecanicas implementadas

| Mecanica | Como funciona |
| :--- | :--- |
| **Gravedad** | `Rigidbody2D` con `Gravity Scale = 3` jala al personaje hacia abajo |
| **Salto** | Al presionar Espacio, se aplica una fuerza vertical (`jumpForce = 12`) |
| **Deteccion de suelo** | `Physics2D.OverlapCircle` en el `GroundCheck` verifica si toca la capa `Ground` |
| **Colision** | `Box Collider 2D` en el personaje + `Box Collider 2D` en el suelo |
| **Movimiento horizontal** | `rb.linearVelocity` con `moveSpeed = 8` |

## Controles

| Tecla | Accion |
| :--- | :--- |
| **Izquierda / Derecha** | Caminar |
| **Espacio** | Saltar |
| **Ctrl + F** | Disparar proyectil |
| **Boton de nota** | Activar/silenciar musica |

## Archivos relevantes

- `Assets/Scripts/PlayerController.cs` - Movimiento, salto, gravedad y deteccion de suelo
- `Assets/Scripts/Projectile.cs` - Comportamiento del proyectil
- `Assets/Scenes/SampleScene.unity` - Escena con todas las mecanicas configuradas

## Repositorio

https://github.com/Osvaldo8005/Aura_Gamer_Combat