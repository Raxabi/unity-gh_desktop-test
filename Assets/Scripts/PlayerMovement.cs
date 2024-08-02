using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float playerSpeed = 1.5f;
    public float speedMultipiler = 2.5f;

    public float jumpForce = 5f;

    // Determines the velocity that the player should up or fall
    public float verticalVelocity = 0.0f;

    public float gravity = 9.81f;

    public bool isGrounded = true;

    void Start() {
        Debug.Log("El jugador puede empezar a moverse");
    }

    void Update() {
        if (!isGrounded)
            Fall();
        
        MovePlayer();

    }

    /// <summary>
    /// Modifies the vertical velocity of the player assigning to his value
    /// the force that the player applies on the floor
    /// </summary>
    private void Jump() {
        verticalVelocity = jumpForce;
        isGrounded = false;
    }

    /// <summary>
    /// The gravity system works by increase a value that reprensets the jump of the player
    ///
    /// In this case is `verticalVelocity` which is increaded to the value of `jumpForce`, that represents the force that the player applies to the floor
    /// Once the value of the player jump is setted needs to back to his previous value.
    /// So as well as vertical velocity backs to 0, the player position on `y` axis increments to the value of `verticalVelocity`
    /// which at some point, will back to his initial value, representing also, that the players backs to the floors
    /// </summary>
    private void Fall() {
        verticalVelocity -= gravity * Time.deltaTime;
        transform.position += new Vector3(0, verticalVelocity * Time.deltaTime, 0);

        if (transform.position.y <= 1f) {
            isGrounded = true;
            verticalVelocity = 0;
        }
    }

    private void MovePlayer() {
        var isRunPressed = Input.GetKey(KeyCode.LeftShift);

        var hori = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");
        var previousHeight = transform.position.y;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Jump();

        transform.position += hori * (playerSpeed * Time.deltaTime * transform.right);
        transform.position += vert * ((isRunPressed && vert == 1 ? 2.5f : playerSpeed) * Time.deltaTime * transform.forward);
    }

    private Vector3 SanitizePlayerHeight(Vector3 playerPosition, float previousHeight) {
        return new Vector3(playerPosition.x, previousHeight, playerPosition.z);
    }
}
