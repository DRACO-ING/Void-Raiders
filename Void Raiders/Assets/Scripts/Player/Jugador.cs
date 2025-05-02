using UnityEngine;

public class Jugador : MonoBehaviour
{
    // Velocidad de movimiento del cubo
    public float velocidad = 5f;
    public float posX, posY;

    void Update()
    {
        MovimientoDelJugador();
    }

    void MovimientoDelJugador()
    {
        posX = transform.position.x;
        posY = transform.position.y;

        if (Input.GetKey(KeyCode.D) && posX <= 16) // Derecha
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);

        if (Input.GetKey(KeyCode.A) && posX >= -16) // Izquierda
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);

        if (Input.GetKey(KeyCode.W) && posY <= 9.7) // Arriba
            transform.Translate(Vector3.up * velocidad * Time.deltaTime);

        if (Input.GetKey(KeyCode.S) && posY >= -8) // Abajo
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Se Activo el Trigger");
    }
}
