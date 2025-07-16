using UnityEngine;

public class NPCFaceController : MonoBehaviour
{
    public Animator animator;

    // Call this method from the player script, passing in the direction vector
    public void FaceDirection(Vector2 direction)
    {
        // Determine the dominant direction (up, down, left, right)
        Vector2 faceDir = Vector2.zero;
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            faceDir.x = direction.x > 0 ? 1 : -1;
            faceDir.y = 0;
        }
        else
        {
            faceDir.x = 0;
            faceDir.y = direction.y > 0 ? 1 : -1;
        }

        animator.SetFloat("FaceX", faceDir.x);
        animator.SetFloat("FaceY", faceDir.y);
    }
}
