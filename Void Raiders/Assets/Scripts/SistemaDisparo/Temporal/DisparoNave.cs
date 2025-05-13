using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoNave : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject PrefabBala;
    public float VelocidadBala = 20f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var bala = Instantiate(PrefabBala, FirePoint.position, FirePoint.rotation);
            bala.GetComponent<Rigidbody>().linearVelocity = FirePoint.forward * VelocidadBala;
        }
    }
}
