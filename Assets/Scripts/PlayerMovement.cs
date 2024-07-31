using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public CharacterController controller;
    public float playerSpeed = 1.5f;

    void Start() {
        controller = gameObject.AddComponent<CharacterController>();
        Debug.Log("El jugador puede empezar a moverse");
    }

    void Update() {
        MovePlayer();
    }

    private void MovePlayer() {
        if (Input.GetKey(KeyCode.W))
            transform.position += transform.forward * (playerSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            transform.position -= transform.forward * (playerSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            transform.position -= transform.right * (playerSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.position += transform.right * (playerSpeed * Time.deltaTime);
    }
}
