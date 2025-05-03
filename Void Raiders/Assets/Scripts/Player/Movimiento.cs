using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movimiento : MonoBehaviour{
    [Header ("Movimiento")]
    [SerializeField] public float velocidad = 10f;

    private Rigidbody rb;

    void Start(){
        rb = GetComponent<Rigidbody>();
        
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation |
        RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;    }

    void FixedUpdate()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");

        Vector3 direccion = new Vector3(movHorizontal, movVertical, 0f).normalized;
        Vector3 nuevaPosicion = Vector3.MoveTowards(transform.position, transform.position + direccion, velocidad * Time.fixedDeltaTime);

        transform.position = nuevaPosicion;
    }

}