using System.Collections;
using UnityEngine;

public class IAPatrol : MonoBehaviour
{
    [Header("Movimiento")]
    Vector3 puntoA;
    Vector3 puntoB;
    Vector3 objetivo;
    bool devolviendose = false;
    private float umbralDistancia = 0.1f;
    [SerializeField] public float velocidad = 8f;

    [Header("Disparo")]
    [SerializeField] public float velDisparo = 1f;

    private Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
    }
    private void OnEnable()
    {
        // Reiniciar el estado del objeto al activarse
        devolviendose = false;
        objetivo = puntoA;
    }
    private void OnDisable()
    {
        // Detener la corutina de disparo al desactivarse
        StopCoroutine(Disparar());
    }

    void Start()
    {
        puntoA = new Vector3(15, 9, -3);
        puntoB = new Vector3(15, -5, -3);

        // Primero, el objeto se mueve hacia A
        objetivo = puntoA;

        // Iniciar la corutina de disparo solo una vez
        StartCoroutine(Disparar());
    }

    void Update()
    {
        // Se mueve hacia el objetivo actual
        transform.position = Vector3.MoveTowards(transform.position, objetivo, velocidad * Time.deltaTime);

        // Cuando esté lo suficientemente cerca del objetivo...
        if (Vector3.Distance(transform.position, objetivo) < umbralDistancia)
        {
            // Si el objetivo era A, se actualiza A y se cambia el objetivo a B
            if (objetivo == puntoA)
            {
                if(puntoA.x <=-16){
                    devolviendose = true;
                }
                else if(puntoA.x >= 15){
                    devolviendose = false;
                }
                puntoA += devolviendose ? new Vector3(5,0,0) : new Vector3(-5, 0, 0);
                objetivo = puntoB;
            }
            // Si el objetivo era B, se actualiza B y se cambia el objetivo a A
            else if (objetivo == puntoB)
            {
                if(puntoB.x <=-34){
                    devolviendose = true;
                }
                else if(puntoB.x >= 39){
                    devolviendose = false;
                }
                puntoB += devolviendose ? new Vector3(5,0,0) : new Vector3(-5, 0, 0);
                objetivo = puntoA;
            }
        }
    }

    public IEnumerator Disparar()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f / velDisparo);
            Debug.Log("IA Dispara");
        }
    }
}
