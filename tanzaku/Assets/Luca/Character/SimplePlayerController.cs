using RedstoneinventeGameStudio;
using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 lastMoveDir = Vector2.down;

    // For NPC interaction
    //private GameObject npcInRange;
    private NPCManager npcInRange;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
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
}
