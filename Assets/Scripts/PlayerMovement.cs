using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController controller;
    public Vector3 playerPosition;
    
    public const float speedMultiplier = 100;
    public float playerSpeed = 5 * speedMultiplier;

    // determines if the player is touching the floor
    public bool isGrounded;

    void Start() {
        controller = gameObject.AddComponent<CharacterController>();
        Debug.Log("El jugador puede empezar a moverse");
    }

    void Update() {
        isGrounded = controller.isGrounded;
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        
        if (isGrounded && playerPosition.y < 0)
            playerPosition.y = 0;

        Vector3 movement = new(hAxis, 0, vAxis);
        
        controller.Move(playerSpeed * Time.deltaTime * movement);

        //gameObject.transform.forward = movement;
    }
}
