using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Image barraVida;

    [SerializeField] public float vidasMax = 3;
    [SerializeField] public float vidasAct = 3;

    public void Update(){
        barraVida.fillAmount = vidasAct/vidasMax;
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy")){
            vidasAct--;
        }
    }
}
