using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationScript : MonoBehaviour
{

    Animator animator;

    public string idleAnimationStateName;
    public string walkingAnimationStateName;
    public string runningAnimationStateName;

    Dictionary<MovementState, string> stateNames = new();

    void Awake() {
        animator = GetComponent<Animator>();
        stateNames[MovementState.IDLE] = idleAnimationStateName;
        stateNames[MovementState.WALKING] = walkingAnimationStateName;
        stateNames[MovementState.RUNNING] = runningAnimationStateName;
    }

    // Update is called once per frame
    void Update()
    {
        MovementState state = PlayerMovementStateManager.GetMovementState();
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName(stateNames[state])) {
            animator.Play(stateNames[state]);
        }
    }
}
