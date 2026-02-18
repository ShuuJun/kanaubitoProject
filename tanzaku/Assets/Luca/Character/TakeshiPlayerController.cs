using RedstoneinventeGameStudio;
using System;
using UnityEngine;
using static TimeController;
using UnityEngine.SceneManagement;

public class TakeshiPlayerController : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 lastMoveDir = Vector2.down;
    public bool warpedState = false;
    public wpLocationData spawnLocation;
    public wpLocationData WPDeparture;
    public GameObject otherPlayer;

    // For NPC interaction
    //private GameObject npcInRange;
    private NPCManager npcInRange;

    void Start()
    {
        LoadPosition();
        rb = GetComponent<Rigidbody2D>();
        if (WPDeparture.takeshiActive == true)
        {
            this.gameObject.SetActive(true);
            if(this.gameObject.GetComponent<Camera>() != null)
                this.gameObject.GetComponent<Camera>().enabled = true;
            this.gameObject.GetComponent<TakeshiPlayerController>().enabled = true;

        }
        else
            this.gameObject.SetActive(false);
        if (spawnLocation != null) // Check if data exists
        {

            LoadPosition();

        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (WPDeparture.takeshiActive == true && WPDeparture.warpedState == true)
            {
                spawnLocation.waypointCoordinates = WPDeparture.waypointCoordinates;
                SceneManager.LoadScene(WPDeparture.savedScene);
            }
            WPDeparture.takeshiActive = false;
            otherPlayer.SetActive(true);
            otherPlayer.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            otherPlayer.GetComponent<SimplePlayerController>().enabled = true;
            GetComponent<TakeshiPlayerController>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            this.gameObject.SetActive(false);
        }

        if (DialogueManager.IsDialogueActive)
        {
            rb.velocity = Vector2.zero; // Stop movement immediately
            animator.SetBool("IsMoving", false); // Set animation to idle
            return; // Skip the rest of Update
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(moveX, moveY).normalized;

        if (move.sqrMagnitude > 0.01f)
            lastMoveDir = move;

        animator.SetFloat("MoveX", move.sqrMagnitude > 0.01f ? move.x : lastMoveDir.x);
        animator.SetFloat("MoveY", move.sqrMagnitude > 0.01f ? move.y : lastMoveDir.y);
        animator.SetBool("IsMoving", move.sqrMagnitude > 0.01f);

        rb.velocity = move * moveSpeed;

        // NPC interaction
        if (npcInRange != null && Input.GetKeyDown(KeyCode.E))
        {
            npcInRange.StartDialogue();

            // Calculate direction from NPC to player
            Vector2 direction = (transform.position - npcInRange.transform.position).normalized;

            // Determine dominant direction
            Vector2 faceDir = Vector2.zero;
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                faceDir.x = direction.x > 0 ? 1 : -1;
            else
                faceDir.y = direction.y > 0 ? 1 : -1;

            // Set NPC facing direction
            Animator npcAnimator = npcInRange.GetComponent<Animator>();
            if (npcAnimator != null)
            {
                npcAnimator.SetFloat("FaceX", faceDir.x);
                npcAnimator.SetFloat("FaceY", faceDir.y);
            }

            // Optionally: trigger dialogue or other interaction here
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        NPCManager npc = other.GetComponent<NPCManager>();
        if (npc != null)
        {
            npcInRange = npc;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        NPCManager npc = other.GetComponent<NPCManager>();
        if (npc != null && npcInRange == npc)
        {
            npcInRange = null;
        }
    }

    public void LoadPosition()
    {
        transform.position = spawnLocation.waypointCoordinates;
        //spawnLocation.waypointCoordinates = new Vector3(0, 0, 0);

        // else
        //transform.position = otherPlayer.transform.position + new Vector3(0, 0, 0);
    }

}
