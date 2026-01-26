using UnityEngine;
using System.Collections;

/// <summary>
/// Controls an NPC's behavior based on the time of day.
/// The NPC will move to different locations depending on the time and then wander randomly.
/// </summary>
public class NPCController : MonoBehaviour
{
    [Header("NPC Waypoints")]
    [Tooltip("The target transform for the NPC's position in the morning.")]
    [SerializeField]
    private Transform morningTarget;

    [Tooltip("The target transform for the NPC's position in the afternoon.")]
    [SerializeField]
    private Transform afternoonTarget;

    [Tooltip("The target transform for the NPC's position in the evening.")]
    [SerializeField]
    private Transform eveningTarget;

    [Header("Wandering Behavior")]
    [Tooltip("The radius around the target waypoint where the NPC can wander.")]
    [SerializeField]
    private float moveRadius = 2f;

    [Tooltip("How fast the NPC moves when wandering.")]
    [SerializeField]
    private float moveSpeed = 1f;

    [Tooltip("Minimum time the NPC will wait before wandering to a new spot.")]
    [SerializeField]
    private float minIdleTime = 2f;

    [Tooltip("Maximum time the NPC will wait before wandering to a new spot.")]
    [SerializeField]
    private float maxIdleTime = 5f;

    private Transform currentTarget;
    private Coroutine wanderCoroutine;

    // Subscribe to the time change event when the object is enabled
    private void OnEnable()
    {
        TimeController.OnTimeChanged += HandleTimeChange;

        // Immediately sync to current time if controller exists
        if (TimeController.Instance != null)
        {
            HandleTimeChange(TimeController.Instance.GetCurrentTime());
        }
    }


    // Unsubscribe from the event when the object is disabled to prevent errors
    private void OnDisable()
    {
        TimeController.OnTimeChanged -= HandleTimeChange;
    }

    /// <summary>
    /// This method is called whenever the TimeController's OnTimeChanged event is fired.
    /// </summary>
    /// <param name="newTime">The new time of day.</param>
    private void HandleTimeChange(TimeController.TimeOfDay newTime)
    {
        Debug.Log($"NPC {gameObject.name} reacting to time change: {newTime}");
        MoveNpc(newTime);
    }

    /// <summary>
    /// Moves the NPC to the appropriate target position and starts its wandering routine.
    /// </summary>
    private void MoveNpc(TimeController.TimeOfDay time)
    {
        Transform targetWaypoint = null;
        switch (time)
        {
            case TimeController.TimeOfDay.Morning:
                targetWaypoint = morningTarget;
                break;
            case TimeController.TimeOfDay.Afternoon:
                targetWaypoint = afternoonTarget;
                break;
            case TimeController.TimeOfDay.Evening:
                targetWaypoint = eveningTarget;
                break;
        }

        if (targetWaypoint != null)
        {
            currentTarget = targetWaypoint;

            // Stop any previous wandering coroutine
            if (wanderCoroutine != null)
            {
                StopCoroutine(wanderCoroutine);
            }

            // Teleport the NPC to their new home base position
            transform.position = currentTarget.position;

            // Start the new wandering routine from the new position
            wanderCoroutine = StartCoroutine(Wander());
        }
        else
        {
            Debug.LogWarning($"NPC {gameObject.name} does not have a target for {time}.");
        }
    }

    /// <summary>
    /// A coroutine that makes the NPC wander around its current target waypoint.
    /// </summary>
    private IEnumerator Wander()
    {
        // This loop will run forever until StopCoroutine is called on it
        while (true)
        {
            // Wait for a random amount of time before moving again
            float idleTime = Random.Range(minIdleTime, maxIdleTime);
            yield return new WaitForSeconds(idleTime);

            // Find a random point within a circle around the target waypoint
            Vector2 randomPoint = Random.insideUnitCircle * moveRadius;
            Vector3 destination = currentTarget.position + new Vector3(randomPoint.x, randomPoint.y, 0);

            // Move smoothly to the destination point
            while (Vector3.Distance(transform.position, destination) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
                yield return null; // Wait for the next frame before continuing the loop
            }
        }
    }
}

