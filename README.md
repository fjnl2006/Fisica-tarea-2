PARTE 1: Ejercicios de Fuerzas y Joints (Ejercicios 1 al 8)
Para evaluar los scripts individuales de físicas (Ejercicio2 al Ejercicio7, MovingCar y ExplosionController), los objetos deben tener el componente Player Input configurado en modo Invoke Unity Events.

Dependiendo del ejercicio a probar, vincula el evento correspondiente en la pestaña Events arrastrando el objeto y seleccionando la función de la lista dinámica (Dynamic CallbackContext):
Archivo de Script,Funcionalidad Evaluada,Acción de Input (Event),Función a seleccionar

MovingCar.cs,Ej. 1: AddForce (Force),Move,MovingCar.OnMove

Ejercice2.cs,Ej. 2: WASD AddForce,Move,Ejercice2.OnMove

Ejercicio3.cs,Ej. 3: Aceleración y Frenado,Move,Ejercicio3.OnMove

Ejercicio4.cs,Ej. 4: Control con Velocity,Move,Ejercicio4.OnMove

Ejercicio5.cs,Ej. 5: Salto (Impulse),Jump,Ejercicio5.OnJump

Ejercicio6.cs,Ej. 6: Aceleración continua,Move,Ejercicio6.OnMove

Ejercicio7.cs,Ej. 7: AddTorque (Rotación),Move,Ejercicio7.OnMove

ExplosionController.cs,Ej. 8: AddExplosionForce,Explosion,ExplosionController.OnExplosion

PARTE 2: Simulación de Bolos (Colliders y Físicas Aplicadas)
Esta escena es un minijuego funcional. La mecánica consiste en orientar la cámara con el ratón, mantener pulsada la tecla Espacio para cargar fuerza, y soltarla para lanzar la bola. Si la bola sale de la pista, reaparecerá en su punto de origen automáticamente.

Configuración requerida en Escena para el Profesor:
1. Etiquetas (Tags):

La bola de bolos debe tener asignada la etiqueta Player. Los scripts de reinicio y zona de lanzamiento dependen de esta etiqueta para funcionar.

2. La Bola de Bolos (BallLauncher.cs):

Input Actions: En el inspector del script, arrastra la referencia de la acción "Look" (ratón) a la variable Input System_Actions.

Lanzamiento: Añade un componente Player Input a la bola (modo Unity Events). Vincula el evento del botón de salto (Espacio) a la función dinámica BallLauncher.OnLaunch. El script calcula la fuerza basándose en el tiempo que se mantiene pulsado el botón (context.started hasta context.canceled).

3. La Cámara (LookBall.cs):

Se encarga de la rotación para apuntar. En el inspector, arrastra la referencia de la acción "Look" (ratón) a la variable Input System_Actions.

Opcionalmente, asigna el Transform de la bola a la variable Player para que el modelo rote visualmente con la cámara.

4. Zonas de Trigger (Mecánicas de Juego):

LaunchZone.cs: Debe estar en un objeto con un Collider en modo IsTrigger situado en la zona de inicio. Mientras la bola (Tag: Player) esté dentro, permitirá el lanzamiento cambiando el booleano canLaunch.

RestartBall.cs: Debe estar en un Collider gigante en modo IsTrigger debajo de toda la pista (zona de caída).

En el inspector de este script, es obligatorio asignar un Transform vacío en la variable Respawn Point. Cuando la bola caiga y toque este trigger, sus velocidades se pondrán a cero y se teletransportará a dicho punto para un nuevo intento.
