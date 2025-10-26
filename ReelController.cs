
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Represents a single reel. Spins for a short duration and returns a random Symbol.
/// </summary>
public class ReelController : MonoBehaviour
{
    [Tooltip("Available symbols this reel can land on. Configure in the Inspector.")]
    public List<Symbol> availableSymbols = new List<Symbol>();

    [Tooltip("Seconds to simulate spinning.")]
    public float spinDuration = 0.8f;

    [Tooltip("Optional: how many 'ticks' to simulate while spinning (visual only).")]
    public int ticks = 10;

    public Action<Symbol> OnSpinComplete;

    private bool spinning = false;

    public void Spin()
    {
        if (spinning || availableSymbols.Count == 0) return;
        StartCoroutine(SpinRoutine());
    }

    private IEnumerator SpinRoutine()
    {
        spinning = true;
        float elapsed = 0f;

        // (Optional) fake ticking to simulate motion; hook animation here.
        for (int i = 0; i < ticks; i++)
        {
            elapsed = (i / (float)ticks) * spinDuration;
            yield return new WaitForSeconds(spinDuration / ticks);
        }

        // Choose a random symbol as the outcome.
        var symbol = availableSymbols[Random.Range(0, availableSymbols.Count)];
        spinning = false;

        // Callback to the GameManager.
        OnSpinComplete?.Invoke(symbol);
    }
}
