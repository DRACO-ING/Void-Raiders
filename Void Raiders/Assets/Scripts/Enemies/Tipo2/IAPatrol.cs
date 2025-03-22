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

    void Start()
    {
        puntoA = new Vector3(39, 18, -3);
        puntoB = new Vector3(39, -13, -3);

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
                if(puntoA.x <=-34){
                    devolviendose = true;
                }
                else if(puntoA.x >= 39){
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
            Debug.Log("Disparo");
        }
    }
}
