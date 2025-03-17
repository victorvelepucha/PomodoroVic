# PomodoroVic Desktop Application
## Instrucciones:
- Se inicia y se coloca por defecto en modo minimalista en la pantalla en la parte inferior derecha, cerca de la hora del sistema.
	- Se puede mover la ventana a cualquier lugar de la pantalla arrastrando la ventana.
- Al dar doble clic, se inicia por default en Pomodoro de 25 minutos:
	- los minutos configurados pueden cambiar al seleccionar la opción de menú o por el archivo de configuración.
- Al dar nuevamente doble clic inicia por en Pomodoro de 5 minutos o los minutos configurados.
- Por default la opacidad esta configurada al 75% de transparencia, pero se puede cambiar:
	- por archivo de configuración 
	- o por opciones de menú.
- Habilitada la funcion AlwaysOnTop, y Parpadeo a 1 minuto de finalizar por defecto pero configurable.
- Si el pomodoro esta a 1 minuto de finalizar se alterna:
	- el contador de tiempo en color azul osculo y marron para pomodoro 25.
	- y celeste y marron para pomodoro 5.
	- Se reproduce sonido cada 10 segundos, si esta habilitado la reproducción de sonido.
- Al finalizar el tiempo, aparecerá una ventana de alerta indicando el pomodoro finalizado. 
	- Esta ventana desaparece automáticamente.
- Se puede pausar el contador de tiempo con la barra espaciadora.


Requerimientos SW:
- Podría funcionar en cualquier versión de Windows con Framework 4.8 como:
	- Windows 7 con SP1, Windows 8.1, Windows 10, Windows 11.
	- Windows Server 2008 R2 con SP1, 2012, 2012 R2, 2016, 2019, 2022.

Requerimientos HW:
- Procesador Intel Core i5, i7, AMD Ryzen con frecuencia mínima de 2 GHz o superior.
- 8 GB de RAM para sistemas operativos de 64 bits.
- 53KB ocupa en disco el programa.

Licencia: 
- Este programa se distribuye bajo la licencia MIT que quiere decir:
	- Se permite que cualquiera use, copie, modifique y distribuya este código incluso para usos comerciales.
	- La única condición es que incluyan la licencia original y den crédito al autor.

Funcionalidad futura:
- Que se generen graficos estadísticos guardando información de LOGs grabados en BDD SQL Compact o algun otro motor de BDD

---

## Pomodoro application V2.4
- Se añade funcionalidad de pausa de tiempo con barra espaciadora, y posibilidad de activar/desactivar sonidos.

---
## Pomodoro application V2.3
- Se incorpora ambos pomodoros: 5/25 y 17/52 para tener ambas funcionalidades para su uso.

---
## Pomodoro application V2.2
- Se corrige bug que presenta la ventana de notificación en 1ra pantalla cuando la ventana de la hora esta en la 2da pantalla (extendida).

---
## Pomodoro application V2.1
- Se añade log de historial de uso de pomodoro. 
- Este archivo de texto se genera en la misma ruta del ejecutable. 
- Esta opción puede desactivarse con menu al hacer clic derecho, o desde archivo de configuración.

---
## Pomodoro application V2.0
- Se añade appconfig para poder personalizar variables como tiempo, opacidad, etc.

---
## Pomodoro application V1.9
- Se añade en label de hora fin, el pomodoro finalizado, con formato P: 5 o P:25

---
## Pomodoro application V1.8
- Cambio mayor para añadir funcionalidades como blink, tooltip, context menu.
- Se reorganiza opciones de menu mostradas al hacer clic derecho.
- Se crea opción AutoSwitch para que cuando termine un pomodoro automáticamente comience otro (ej, si termina el pomodoro 25 comienza uno nuevo en 5).
- Se crea opción Blink (seleccionado por default) para que alterne en colores si esta a 1 minuto o menos por finalizar el pomodoro.
- Se añade ventana tipo tooltip la cual se presenta en forma de alerta no intrusiva cuando tiempo a finalizado.
- Se elimina Mensaje (MessageBox) de fin de pomodoro con cierre automático.
- Se elimina botones de tiempo, para tener solo vía botón derecho. 
- Se elimina función mostrar título. 
- Se elimina funcionalidad de resize, ahora al hacer doble clic se alterna entre tiempo 25 y tiempo 5.

---
## Pomodoro application V1.7
- Cambio en dialogo que presenta cuando termina 1 pomodoro (de fin de tiempo), para presentar 2 botones, continuar o cancelar. 
- Dialogo se cierra luego de 10 segundos. 
- Si se presiona Si, se continua con otro pomodoro en modo inverso.

---
## Pomodoro application V1.6
- Se rediseña para que por default se inicie en modo minimalista. 
- Algunas opciones se mueven/desaparecen para mostrarse solo con clic derecho. 
- Se coloca ventana en la parte inferior derecha por default.

---
## Pomodoro application V1.5
- Cuando este minimalista, no mostrar en TaskBar. Menu contextual en label Tiempo, para restaurar/salir.

---
## Pomodoro application V1.4
- Se incorpora resize, doble click minimalista, drag window, ventana centrada.

---
## Pomodoro application V1.3
- Se coloca icono en título de ventana principal y envío a TraySystem.

---
## Pomodoro application V1.2
- Se incorpora opción AlwaysOnTop y Opacidad.

---
## Pomodoro application V1.1
- Se incorpora botón 5 minutos, y detener.

---
## Pomodoro application V1.0
- Versión inicial, solo con botón de 25 minutos.



