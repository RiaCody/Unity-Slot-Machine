
using UnityEngine;

/// <summary>
/// Data container for a symbol on a reel. 
/// Use ScriptableObject in production; kept simple here for readability.
/// </summary>
[System.Serializable]
public class Symbol
{
    public int id;
    public string name;
    public int payout = 5;
    public Sprite icon;
}
