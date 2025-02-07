# CONTRIBUTING - Void Raiders

Gracias por contribuir a *Void Raiders*. Sigue estas instrucciones para asegurar un flujo de trabajo eficiente y ordenado.

## Flujo de Trabajo
1. **Clona el repositorio:**
   ```sh
   git clone <iojaness/Void-Reaiders>
   ```
2. **Crea una nueva rama desde `dev`** siguiendo estas convenciones:
   - Funcionalidad nueva: `feature/nombre-feature`
   - Corrección de errores: `bugfix/nombre-bug`
   - Solución urgente: `hotfix/nombre-hotfix`
   - Lanzamientos: `release/numero-version`
3. **Realiza tus cambios** y comenta tu código adecuadamente.
4. **Prueba tu código** antes de hacer un *commit*.
5. **Crea un *pull request*** para fusionar tu rama en `dev`.
6. **Espera revisión** de al menos un compañero antes de fusionar.

## Reglas de Commit y Merge
- Usa mensajes de commit descriptivos en tiempo presente (Ej: "Agrega funcionalidad de disparo").
- Asegúrate de que los cambios no rompan funcionalidades existentes.
- No hagas *commits* de cambios no relacionados en la misma rama.
- Siempre usa *pull requests* para fusionar cambios en `dev` o `main`.

## Estructura del Código en Unity
Para mantener el proyecto organizado:
- **Scripts:**
  - `Player/` → Lógica del jugador.
  - `Enemies/` → IA y comportamiento de enemigos.
  - `UI/` → Scripts de interfaz de usuario.
  - `Network/` → Funciones multijugador.
- **Prefabs:** Todos los objetos reutilizables deben estar en `Prefabs/`.
- **Mensajes de consola:** Incluye `Debug.Log()` en puntos clave para facilitar depuración.

## Código de Conducta
- Evita cambios innecesarios en archivos que no estés modificando.
- Comenta tu código para que otros puedan entenderlo fácilmente.

Siguiendo estas reglas, garantizamos un desarrollo eficiente y organizado para *Void Raiders*. ¡Gracias por tu aporte!
