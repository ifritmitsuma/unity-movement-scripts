using UnityEngine;

public class CharacterMovementScript : MonoBehaviour {

    public CharacterController controller;

    public Transform cam;

    private Vector3 movement;

    public float speed = 2.5f;

    public float turnSmoothTime = 100f;

    private float turnSmoothVelocity;

    public float rotationFactorPerFrame;

    void Start() {
        MovementState state = MovementState.IDLE;
        PlayerMovementStateManager.SetMovementState(state);
    }

    void Update() {

        MovementState state = MovementState.IDLE;
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        if(Vector3.one - movement != Vector3.one) {
            state = MovementState.WALKING;
            if(Input.GetButton("Run")) {
                state = MovementState.RUNNING;
            }
        }
        PlayerMovementStateManager.SetMovementState(state);

        HandleRotation(state);
        HandleGravity();
        
        controller.Move((state == MovementState.RUNNING ? 2.0f : 1.0f) * speed * Time.deltaTime * movement.normalized);

    }

    void HandleRotation(MovementState state) {

        Vector3 positionToLookAt = movement;

        Quaternion currentRotation = transform.rotation;

        if(state != MovementState.IDLE) {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }

    }

    void HandleGravity() {
        if(controller.isGrounded) {
            float groundedGravity = -0.05f;
            movement.y = groundedGravity;
        } else {
            float gravity = -9.8f;
            movement.y += gravity;
        }
    }

}