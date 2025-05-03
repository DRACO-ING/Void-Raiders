using System.Collections;
using UnityEngine;

public class IAZigZag : MonoBehaviour
{
    [Header("Movimiento")]
    Vector3 puntoA;
    Vector3 puntoB;
    Vector3 objetivo;
    bool devolviendose = false;
    private float umbralDistancia = 0.1f;
    [SerializeField] public float velocidad = 8f;
    [SerializeField] public int bordeArriba;
    [SerializeField] public int bordeAbajo;
    [SerializeField] public int bordeIzquierda;
    [SerializeField] public int bordeDerecha;
    [Header("Disparo")]
    [SerializeField] public float velDisparo = 1f;

    private Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
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
        // Genera una Y aleatoria entre los bordes verticales
        float yAleatorio = Random.Range(bordeAbajo + 1, bordeArriba - 1);

        // Establece un objetivo aleatorio en Y, pero en X siempre bordeDerecha-1
        objetivo = new Vector3(bordeDerecha - 1, yAleatorio, 0);

        StartCoroutine(MoverseHaciaObjetivo());
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
                if(puntoA.x <= bordeIzquierda){
                    devolviendose = true;
                }
                else if(puntoA.x >= bordeDerecha){
                    devolviendose = false;
                }

                // Ahora el desplazamiento horizontal va en la dirección correcta
                puntoA = devolviendose ? new Vector3(puntoB.x+10,puntoA.y,0) : new Vector3(puntoB.x-10, puntoA.y, 0);
                objetivo = puntoB;
            }
            else if (objetivo == puntoB)
            {
                // ¡OJO! Aquí deberías usar X, no comparar con bordeAbajo (que es vertical)
                if(puntoB.x <= bordeIzquierda){
                    devolviendose = true;
                }
                else if(puntoB.x >= bordeDerecha){
                    devolviendose = false;
                }

                puntoB = devolviendose ? new Vector3(puntoA.x+10,puntoB.y,0) : new Vector3(puntoA.x-10, puntoB.y, 0);
                objetivo = puntoA;
            }

        }
    }

    private IEnumerator MoverseHaciaObjetivo()
    {
        // Mueve el objeto hasta la posición aleatoria
        while (Vector3.Distance(transform.position, objetivo) > umbralDistancia)
        {
            transform.position = Vector3.MoveTowards(transform.position, objetivo, velocidad * Time.deltaTime);
            yield return null;
        }

        // Una vez que llega a la posición aleatoria, comienza a patrullar entre A y B
        puntoA = new Vector3(bordeDerecha - 1, bordeArriba - 1, 0); // Arriba
        puntoB = new Vector3(bordeDerecha - 1, bordeAbajo + 1, 0);  // Abajo
        objetivo = puntoA; // El primer objetivo es ir hacia puntoA
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
