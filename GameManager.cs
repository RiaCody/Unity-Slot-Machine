
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Coordinates reels, credits, UI, and sound.
/// Keep logic modular and readable for code review.
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("Reels")]
    public List<ReelController> reels = new List<ReelController>();

    [Header("Economy")]
    public int startingCredits = 100;
    public int spinCost = 1;
    public int credits;

    [Header("Refs")]
    public UIManager ui;
    public AudioManager audioManager;

    private int reelsCompleted = 0;
    private List<Symbol> lastResult = new List<Symbol>();

    void Start()
    {
        credits = startingCredits;
        if (ui != null) ui.UpdateCredits(credits);
    }

    public void OnSpinButton()
    {
        if (credits < spinCost) {
            if (ui != null) ui.ShowMessage("Not enough credits!");
            return;
        }

        credits -= spinCost;
        if (ui != null) ui.UpdateCredits(credits);
        if (audioManager != null) audioManager.PlaySpin();

        reelsCompleted = 0;
        lastResult.Clear();

        foreach (var reel in reels)
        {
            reel.OnSpinComplete = OnReelComplete;
            reel.Spin();
        }
    }

    public void OnResetButton()
    {
        credits = startingCredits;
        if (ui != null)
        {
            ui.UpdateCredits(credits);
            ui.ShowResult("-", 0);
            ui.ShowMessage("Reset complete.");
        }
    }

    private void OnReelComplete(Symbol result)
    {
        lastResult.Add(result);
        reelsCompleted++;

        if (reelsCompleted >= reels.Count)
        {
            // All reels finished: evaluate result.
            int payout = EvaluateWin(lastResult);
            credits += payout;
            if (ui != null)
            {
                var nameList = new List<string>();
                foreach (var s in lastResult) nameList.Add(s != null ? s.name : "None");
                string combo = string.Join(" | ", nameList);
                ui.ShowResult(combo, payout);
                ui.UpdateCredits(credits);
            }
            if (payout > 0 && audioManager != null) audioManager.PlayWin();
        }
    }

    /// <summary>
    /// Very simple evaluation: if all symbols match -> win that symbol's payout.
    /// Extend this to support paylines, wilds, scatters, etc.
    /// </summary>
    private int EvaluateWin(List<Symbol> result)
    {
        if (result.Count == 0) return 0;
        var first = result[0];
        foreach (var s in result)
        {
            if (s == null || s.id != first.id) return 0;
        }
        return first != null ? first.payout : 0;
    }
}
