using UnityEngine;

public class Jugador : MonoBehaviour
{
    // Velocidad de movimiento del cubo
    public float velocidad = 5f;
    public float posX, posY;
    public float Vida = 3f;
    public GameObject jugador;


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
    //Codio de detector de Trigger
    void OnTriggerEnter(Collider other)
    {
        //Trigger de tiro
        if (other.gameObject.CompareTag("Tiro"))
        {
        Debug.Log("Se Activo el trigger de tiro");
        //Bajar vida cada rato que este Trigger se active
        Vida--;
        //Borrar el Objeto cuando la vida del jugador llege a 0
            if (Vida==0)
            {
            GameObject.Destroy(jugador);
            }
        //Trigger de Botin
        } 
        else if (other.gameObject.CompareTag("Botin"))
        {
        Debug.Log("Se Activo el Trigger de botin");
        }
    }
}
