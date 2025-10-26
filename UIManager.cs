
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles simple UI output for credits, result text, and messages.
/// Uses Unity UI (Text). Swap to TMP if desired.
/// </summary>
public class UIManager : MonoBehaviour
{
    public Text creditsText;
    public Text resultText;
    public Text messageText;

    public void UpdateCredits(int value)
    {
        if (creditsText != null)
            creditsText.text = $"Credits: {value}";
    }

    public void ShowResult(string combo, int payout)
    {
        if (resultText != null)
            resultText.text = $"Result: {combo} | Payout: {payout}";
    }

    public void ShowMessage(string msg)
    {
        if (messageText != null)
            messageText.text = msg;
    }
}
