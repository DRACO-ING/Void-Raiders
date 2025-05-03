using UnityEngine;

public class MiniManager : MonoBehaviour
{
    public GameObject objectToSpawn; // Asigna el prefab en el inspector

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Crea una instancia del objeto en la posición (0, 0, 0) y con la rotación y escala actuales
                GameObject newObject = Instantiate(objectToSpawn);

                // Opcional: Modifica la posición del nuevo objeto
                newObject.transform.position = new Vector3(-15, 7, 0);
            }
        }

}
