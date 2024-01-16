using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerMovementStateManager
{
    static List<MovementState> playerMovementStates = new();

    public static void SetMovementState(MovementState state, int player = 0) {
        if(player > playerMovementStates.Count - 1) {
            for(int i=playerMovementStates.Count - 1; i <= player; ++i) {
                playerMovementStates.Add(MovementState.IDLE);
            }
        }
        playerMovementStates[player] = state;
    }

    public static MovementState GetMovementState(int player = 0) {
        if(player < 0 || player > playerMovementStates.Count - 1) {
            throw new UnityException("Player " + player + " is not configured!");
        }
        return playerMovementStates[player];
    }

    

}
