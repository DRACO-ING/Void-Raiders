using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movimiento : MonoBehaviour{
    [Header ("Movimiento")]
    [SerializeField] public float velocidad = 10f;

    [Header ("Disparo")]
    [SerializeField] public GameObject disparoPrefab;
    public float cadenciaDisparo = 1f;

    private float tiempoUltDisparo;
    private Rigidbody rb;

    void Start(){
        rb = GetComponent<Rigidbody>();
        
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation |
        RigidbodyConstraints.FreezePositionZ;
        tiempoUltDisparo = 0f;
    }

    void FixedUpdate(){
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movHorizontal, movVertical, 0f) * velocidad;

        rb.linearVelocity = movimiento;
    }
}