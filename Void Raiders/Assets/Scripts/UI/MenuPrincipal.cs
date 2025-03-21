using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void EscenaJuego()
    {
        SceneManager.LoadScene("BASE (NO EDITAR)");
    }
    
    public void Salir()
    {
        Application.Quit();
    }
}
