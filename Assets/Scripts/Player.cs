
using UnityEngine;

public class Player : MonoBehaviour {
    private Vector3 direction;
    
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float upforce = 5.0f;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            direction = Vector3.up * upforce;
        }

        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) {
                direction = Vector3.up * upforce;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.Translate(direction * Time.deltaTime);
    }

    //
    private void OnTriggerEnter2D(Collider2D collider) {
        //si colisionamos con un obstaculo
        if (collider.CompareTag("Obstacle")) {
            //mostramos mensaje de game over en consola
            Debug.Log("Game Over");
            //llamamos al metodo de game over del game manager
            GameManager.Instance.GameOver();
        }

        //si colisionamos con un checkpoint
        if (collider.CompareTag("Checkpoint")) {
            //mostramos mensaje de score en consola
            Debug.Log("Score");
            //llamamos al metodo de incrementar score del game manager    
            GameManager.Instance.IncreaseScore();
        }
    }

}
