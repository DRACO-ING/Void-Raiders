using UnityEngine;

public class movimiento : MonoBehaviour
{
    //SCRIPT DE MOVIMIENTO TEMPORAL
    public float speed = 15f;

    void Update()
    {
        float moveVertical = (Input.GetKey(KeyCode.W) ? 1 : 0) + (Input.GetKey(KeyCode.S) ? -1 : 0);
        float moveHorizontal = (Input.GetKey(KeyCode.A) ? -1 : 0) + (Input.GetKey(KeyCode.D) ? 1 : 0);
        
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0) * speed * Time.deltaTime;
        transform.position += movement;
    }
}

