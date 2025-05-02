    using UnityEngine;

    public class Espacio : MonoBehaviour
    {
        public float rotationSpeed = 0.5f;

        void Update()
        {
            // Obtener el material del skybox
            Material skyboxMaterial = RenderSettings.skybox;

            // Verificar si el skybox material existe
            if (skyboxMaterial != null)
            {
                // Actualizar la propiedad _Rotation del skybox material
                skyboxMaterial.SetFloat("_Rotation", Time.time * rotationSpeed);
            }
        }
    }
