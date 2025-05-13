using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoNave : MonoBehaviour
{
    [Header("Punto de disparo y prefab")]
    public Transform FirePoint;
    public GameObject PrefabBala;

    [Header("Parámetros de bala")]
    public float VelocidadBala = 20f;

    [Header("Cadencia de disparo")]
    public float fireRate = 5f;      // Balas por segundo
    private float nextFireTime = 0f; // Próximo instante permitido para disparar

    void Update()
    {
        // Si el jugador mantiene presionado el botón de disparo
        // y ha pasado el tiempo mínimo desde el último disparo...
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            // Calcula el siguiente instante válido: 
            // tiempo actual + intervalo entre balas (1/fireRate)
            nextFireTime = Time.time + 1f / fireRate; 
        }
    }

    void Shoot()
    {
        // Instancia la bala en la posición y rotación del FirePoint
        var bala = Instantiate(PrefabBala, FirePoint.position, FirePoint.rotation);
        // Asigna velocidad lineal (vector de movimiento)
        bala.GetComponent<Rigidbody>().linearVelocity = FirePoint.forward * VelocidadBala;
    }
}

