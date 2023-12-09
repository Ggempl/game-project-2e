using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private bool isTimeSlowed = false;
    private float originalTimeScale;
    public float playerTimeScale = 1.0f; // Separate time scale for the player
    [SerializeField] private AudioClip TimeSlowSoundClip;
    // Duration of time slowdown in seconds
    public float timeSlowDuration = 5.0f;
    private float timeSlowTimer;

    // Cooldown period between consecutive time slowdowns
    public float timeSlowCooldown = 10.0f;
    private bool isCooldown = false;
    private float cooldownTimer;

    void Start()
    {
        originalTimeScale = Time.timeScale;
        timeSlowTimer = timeSlowDuration; // Set the initial timer value
    }

    void Update()
    {
        if (!isCooldown && Input.GetKeyDown(KeyCode.R))
        {
            ToggleTimeSlow();
            SoundFXManger.instance.PlaySoundFXClip(TimeSlowSoundClip, transform, 1f);
        }

        // Update the player's movement and actions using the separate time scale
        float deltaTime = isTimeSlowed ? Time.deltaTime * playerTimeScale : Time.deltaTime;
        // Add your player movement and action logic here using deltaTime

        // Update the time slowdown timer
        if (isTimeSlowed)
        {
            timeSlowTimer -= Time.unscaledDeltaTime;

            if (timeSlowTimer <= 0.0f)
            {
                // If the timer reaches zero, revert to the original time scale
                ToggleTimeSlow();
            }
        }

        // Update the cooldown timer
        if (isCooldown)
        {
            cooldownTimer -= Time.unscaledDeltaTime;

            if (cooldownTimer <= 0.0f)
            {
                // If the cooldown timer reaches zero, allow the player to trigger time slowdown again
                isCooldown = false;
            }
        }
    }

    void ToggleTimeSlow()
    {
        if (isTimeSlowed)
        {
            // If time is already slowed, revert to the original time scale
            Time.timeScale = originalTimeScale;
            timeSlowTimer = timeSlowDuration; // Reset the timer
        }
        else
        {
            // Slow down time globally
            Time.timeScale = 0.25f; // You can adjust this value for the desired slowdown effect
            isCooldown = true; // Activate cooldown
            cooldownTimer = timeSlowCooldown; // Set the cooldown timer
        }

        // Invert the time-slowed state
        isTimeSlowed = !isTimeSlowed;
    }
}