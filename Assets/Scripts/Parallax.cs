using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Clase que controla el efecto de parallax o movimiento del fondo del juego
 */
public class Parallax : MonoBehaviour {
    //atributos de la clase
    [SerializeField] private float speed = 5.0f; //velocidad de movimiento por defecto
    private MeshRenderer meshRenderer; //renderizador del fondo

    //al iniciar
    void Awake() {
        //obtenemos el componente renderizador del fondo que le pasamos
        meshRenderer = GetComponent<MeshRenderer>();
    }

    //al actualizar
    void Update() {
        //vamos moviendo el fondo en el eje x como offset de la textura a velocidad constante
        meshRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
