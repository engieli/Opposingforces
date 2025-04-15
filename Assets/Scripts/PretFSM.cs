using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class PretFSM : MonoBehaviour
{
    // Reference to the Player
    public Transform playerTransform;
    public float detectionRange = 10f; // Range within which the Pret detects the player

    // Variables for each state
    private enum State { Idle, Patrolling, Charging, Telegraphing }
    private State currentState = State.Idle;

    private void Update()
    {
        // Transition between states
        switch (currentState)
        {
            case State.Idle:
                IdleState();
                break;
            case State.Patrolling:
                PatrollingState();
                break;
            case State.Charging:
                ChargingState();
                break;
            case State.Telegraphing:
                TelegraphingState();
                break;
        }
    }

    // Idle State: Pret stands still
    void IdleState()
    {
        if (IsPlayerInRange())
        {
            currentState = State.Telegraphing;
        }
        else
        {
            currentState = State.Patrolling;
        }
    }

    // Patrolling State: Pret moves around
    void PatrollingState()
    {
        // Implement random movement or pathfinding here
        // If the player is seen, transition to Telegraphing or Charging state
        if (IsPlayerInRange())
        {
            currentState = State.Telegraphing;
        }
    }

    // Charging State: Pret charges toward the player
    void ChargingState()
    {
        if (!IsPlayerInRange())
        {
            currentState = State.Idle; // If the player is out of range, go idle
        }
        else
        {
            // Pret charges toward the player
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, 5f * Time.deltaTime);
        }
    }

    // Telegraphing State: Pret signals they're about to charge
    void TelegraphingState()
    {
        // Pret telegraphs that it's going to charge
        // Here you could add visual cues (e.g., a red glow or an animation)
        Debug.Log("Pret is preparing to charge!");

        // After some delay, transition to the charging state
        Invoke("StartCharging", 1f); // After 1 second, start charging
    }

    // Helper Method to Check if Player is in Range
    bool IsPlayerInRange()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        return distance < detectionRange;
    }

    // Start charging after telegraphing
    void StartCharging()
    {
        currentState = State.Charging;
    }
}
