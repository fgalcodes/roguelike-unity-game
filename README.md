# Epidemic-Game
![Captura de Pantalla 1](/screenshots/screenshot4.png)

## Descripción

¡Bienvenido a Epidemic! Este emocionante juego RogueLike TopDown te sumerge en una mazmorra procedural llena de desafíos. Enfréntate a oleadas de zombies, esquiva torretas mortales, descubre trampas ocultas y desafía a jefes temibles mientras exploras las profundidades del laberinto.


## Características Principales

🧟 Enfréntate a oleadas de zombies hambrientos, torretas mortales, enemigos explosivos y formidables jefes.

🛒 Explora la tienda de recursos para comprar pociones curativas, llaves para abrir puertas misteriosas y más.

🗣️ Interactúa con mercaderes y NPC's que te contarán historias intrigantes y te ofrecerán elecciones difíciles.

📜 Descubre carteles informativos que revelan secretos sobre la mazmorra y su pasado misterioso.

🎒 Administra tu inventario con diversas armas, desde letales ataques cuerpo a cuerpo hasta poderosas armas de fuego y escopetas.



## Estilo Visual

El juego está desarrollado en Unity 2D, presentando gráficos pixelard, con una vista TopDown, que ofrece una perspectiva envolvente en la exploración de las diferentes salas del juego.


## Controles

Movimiento:
Utiliza las teclas (A, W, D, S) para mover al jugador por la mazmorra.

Ataque:
Controla tus armas con clics de ratón, para disparar o para atacar cuerpo a cuerpo.
Utiliza las teclas (Q, E) para cambiar entre armas: Melee, Gun, Shotgun, Fusil.

Interacción:
Acércate a los NPC's, tiendas y carteles para explorar y obtener información.

Inventario:
Administra tu inventario utilizando las teclas (1, 2, 3, 4 Y 5) para equipar y utilizar diferentes armas y objetos.

## Capturas de Pantalla

![Captura de Pantalla 2](/screenshots/screenshot1.png)

## Género y Temática

Género: RogueLike - TopDown

Temática: Mazmorra procedural pixelart 2D

## Requisitos Principales:

Mapa Procedural:
Hemos creado un mapa procedural utilizando prefabs de las diferentes salas, donde al iniciar el juego se crean con una estructura cada vez distinta.

Player:
Hemos creado las animaciones de: Idle, Walk, Attack, Dead.
El personaje puede equipar diferentes armas.

Enemigos:
Zombie Explosivo: Este enemigo te persigue y explota al contacto.
Torreta: Tiene un rango de detección, y dispara hacia el jugador, con una rotación de 360 grados y con un intervalo de disparo.

Puertas y llaves:
Hemos implementado puertas “lasers” en las diferentes salas.
Requieren una llave para abrirse.

Niveles Transitable/No Transitable:
Hemos puesto diferentes áreas transitables y obstáculos que el jugador y enemigos deben evitar.

Scrolling de Fondo:
Hemos creado un fondo dinámico (de lava) con movimiento relativo al personaje.

Audio:
El juego tiene música de fondo.
También hemos puesto varios efectos de sonido (rugido zombies, tienda, disparo).

Sistema de Diálogo:
En el juego podrás encontrar un mercader donde hemos implementado un sistema de diálogo con 2 opciones que afecten el juego.

Inventario:
Tenemos un UI para gestionar y equipar armas.

HUD y Vida:
En la parte superior de la pantalla “en un HUD”, se puede mostrar la vida del jugador y la cantidad de dinero y llaves que tiene.
Los enemigos a pie, tienen barras de vida sobre ellos.


## Instalación

1. Clona o descarga el repositorio.
2. Abre el proyecto en Unity.
3. Ejecuta el juego desde el editor o compila para la plataforma de tu elección.

## Requisitos del Sistema

- Unity 2022.3.9f1
- Sistema Operativo: Windows 10 o macOS 10.14


## Licencia

[![CC0](https://licensebuttons.net/p/zero/1.0/88x31.png)](https://creativecommons.org/publicdomain/zero/1.0/)  

Este juego se distribuye con Licencia pública.
