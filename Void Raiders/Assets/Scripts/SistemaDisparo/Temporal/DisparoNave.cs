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
    public float fireRate = 5f;  
    private float nextFireTime = 0f; 

    void Update()
    {
        
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            
            nextFireTime = Time.time + 1f / fireRate; 
        }
    }

    void Shoot()
    {
        var bala = Instantiate(PrefabBala, FirePoint.position, FirePoint.rotation);
        bala.GetComponent<Rigidbody>().linearVelocity = FirePoint.forward * VelocidadBala;
    }
}

