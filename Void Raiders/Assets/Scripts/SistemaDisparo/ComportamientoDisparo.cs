using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(menuName = "Menu de Comportamiento Disparo/Crear Nuevo Disparo")]
public class ScriptDisparo : ScriptableObject {
 
        [Header("Prefab")]
        [Tooltip("Prefab del proyectil")]
        public GameObject proyectilPrefab;
        public GameObject proyectil;
        [Tooltip("Textura")]
        public Texture2D texturaProyectil;
        [Header("Parametros del disparo")]
        [Tooltip("Disparos por segundo")]
        public float velBala;
        [Tooltip("Tipo de disparo")]
        public int tipoDisparo;
        [Tooltip("Daño")]
        public int dañoBala;
        [Tooltip("OrigenEnemigo")]
        public bool origenEnemigo;
        [Tooltip("Direccion")]
        public Vector2 direccion;
    

        
    
    void verificarTipoDisparo(){

        switch(tipoDisparo){
            case 1 : 
                compDisparo1();
                Debug.Log("Disparo tipo 1 activado");
                break;
            default:
                Debug.LogWarning("Tipo de disparo no reconocido: " + tipoDisparo);
                break;
        }

    }
    

    //Comportamiento del disaparo tipo 1
    void compDisparo1(){
       
        //Instanciamos el proyectil
        proyectil.transform.Translate(new Vector3 (direccion.x, direccion.y, 0)* velBala * Time.deltaTime);

    }

    //Funcion que destruye el proyectil cuando sale de pantalla
    void OnBecameInvisible() {
        Destroy(proyectil);
     }
}
