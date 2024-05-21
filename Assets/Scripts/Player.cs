
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

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Obstacle")) {
            Debug.Log("Game Over");
            GameManager.FindAnyObjectByType<GameManager>().GameOver();
        }

        if (collider.CompareTag("Checkpoint")) {
            Debug.Log("Score");
            GameManager.FindAnyObjectByType<GameManager>().IncreaseScore();
        }
    }

}
