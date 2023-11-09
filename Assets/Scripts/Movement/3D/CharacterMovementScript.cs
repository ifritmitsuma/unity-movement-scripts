using UnityEngine;



public class CharacterMovementScript : MonoBehaviour {

    private enum MovementState {
        IDLE, WALKING, RUNNING
    }

    private Animator animator;

    private MovementState state;

    private Vector3 movement;

    private float speed = 2.5f;

    void Start() {

        animator = GetComponent<Animator>();

    }

    void Update() {

        state = MovementState.IDLE;
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if(Vector3.one - movement != Vector3.one) {
            state = MovementState.WALKING;
            if(Input.GetButton("Run")) {
                state = MovementState.RUNNING;
            }
        }

    }

    void FixedUpdate() {
        if(state != MovementState.IDLE) {
            transform.LookAt(transform.position + movement);
            transform.Translate((state == MovementState.RUNNING ? 2.0f : 1.0f) * speed * Time.deltaTime * transform.forward.normalized, Space.World);
        }
        animator.SetInteger("movement", (int) state);
    }

}