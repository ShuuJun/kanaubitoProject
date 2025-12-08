using UnityEngine;
using UnityEngine.Rendering.Universal; // Required for Light2D
using System; // Required for Action
using System.Collections; // Required for Coroutines
using UnityEngine.UI; // Required for Image

/// <summary>
/// Manages the time of day, lighting, and notifies other game objects of time changes.
/// Includes a fade-to-black transition when time changes.
/// </summary>
public class TimeController : MonoBehaviour
{
    // Enum to define the different times of day
    public enum TimeOfDay
    {
        Morning,
        Afternoon,
        Evening
    }

    // Static event that other scripts can subscribe to
    public static event Action<TimeOfDay> OnTimeChanged;

    // The current time of day
    [SerializeField]
    private TimeOfDay currentTime = TimeOfDay.Morning;

    [Header("Lighting Settings")]
    [Tooltip("The global 2D light in the scene.")]
    [SerializeField]
    private Light2D globalLight;

    [Tooltip("The color of the global light during the morning.")]
    [SerializeField]
    private Color morningColor = Color.white;

    [Tooltip("The color of the global light in the afternoon.")]
    [SerializeField]
    private Color afternoonColor = new Color(1f, 0.85f, 0.6f);

    [Tooltip("The color of the global light in the evening.")]
    [SerializeField]
    private Color eveningColor = new Color(0.4f, 0.3f, 0.6f);

    [Header("Fade Effect Settings")]
    [Tooltip("The UI Image to use for the fade-to-black effect.")]
    [SerializeField]
    private Image fadeImage;

    [Tooltip("How long the fade in/out effect should last.")]
    [SerializeField]
    private float fadeDuration = 1f;

    // A flag to prevent spamming the time change
    private bool isChangingTime = false;


    void Start()
    {
        // Ensure the fade image is transparent at the start
        if (fadeImage != null)
        {
            Color tempColor = fadeImage.color;
            tempColor.a = 0;
            fadeImage.color = tempColor;
        }
        // Set the initial lighting and notify all listeners of the starting time.
        UpdateTime();
    }

    /// <summary>
    /// Starts the process to advance the time, including the fade effect.
    /// </summary>
    public void AdvanceTime()
    {
        // Prevent changing time if a fade is already in progress
        if (isChangingTime)
        {
            return;
        }

        // Start the fading coroutine
        StartCoroutine(FadeAndChangeTime());
    }

    /// <summary>
    /// A coroutine that handles fading out, changing the time, and fading back in.
    /// </summary>
    private IEnumerator FadeAndChangeTime()
    {
        isChangingTime = true;

        // --- Fade Out (to black) ---
        yield return StartCoroutine(Fade(1f)); // Fade to opaque

        // --- Change the time ---
        if (currentTime == TimeOfDay.Morning)
        {
            currentTime = TimeOfDay.Afternoon;
        }
        else if (currentTime == TimeOfDay.Afternoon)
        {
            currentTime = TimeOfDay.Evening;
        }
        else if (currentTime == TimeOfDay.Evening)
        {
            currentTime = TimeOfDay.Morning;
        }

        UpdateTime();

        // Optional: wait a moment while the screen is black
        yield return new WaitForSeconds(0.2f);

        // --- Fade In (from black) ---
        yield return StartCoroutine(Fade(0f)); // Fade to transparent

        isChangingTime = false;
    }

    /// <summary>
    /// A generic coroutine to fade an image's alpha to a target value over a duration.
    /// </summary>
    /// <param name="targetAlpha">The target alpha value (0 for transparent, 1 for opaque).</param>
    private IEnumerator Fade(float targetAlpha)
    {
        if (fadeImage == null)
        {
            Debug.LogError("Fade Image is not assigned in TimeController!");
            yield break; // Exit the coroutine if the image isn't set
        }

        float alpha = fadeImage.color.a;
        Color currentColor = fadeImage.color;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeDuration)
        {
            Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(alpha, targetAlpha, t));
            fadeImage.color = newColor;
            yield return null;
        }

        // Ensure the final alpha is set correctly
        fadeImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, targetAlpha);
    }


    /// <summary>
    /// Updates the lighting and invokes the OnTimeChanged event.
    /// </summary>
    private void UpdateTime()
    {
        UpdateLighting();

        // Fire the event to notify all subscribers (like NPCs)
        OnTimeChanged?.Invoke(currentTime);
        Debug.Log("Time has changed to: " + currentTime);
    }

    /// <summary>
    /// Changes the global light color based on the current time of day.
    /// </summary>
    private void UpdateLighting()
    {
        if (globalLight == null)
        {
            Debug.LogError("Global Light is not assigned in the TimeController!");
            return;
        }

        switch (currentTime)
        {
            case TimeOfDay.Morning:
                globalLight.color = morningColor;
                break;
            case TimeOfDay.Afternoon:
                globalLight.color = afternoonColor;
                break;
            case TimeOfDay.Evening:
                globalLight.color = eveningColor;
                break;
        }
    }

    // A helper method to get the current time, useful for objects that initialize mid-cycle.
    public TimeOfDay GetCurrentTime()
    {
        return currentTime;
    }
}

