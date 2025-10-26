
# 🎰 Unity Slot Machine (C#)

A lightweight Unity project that demonstrates **clean, modular C# design** for a simple slot-machine prototype.  
This repo focuses on **readable code, reusable components,** and **Unity best practices**—perfect for code review.

> Open the project in **Unity 2022 LTS (or newer)**. Create a scene (e.g., `MainScene.unity`), drop in a `GameObject` for each script, wire references in the Inspector, and press ▶️ to test.

## ✨ Features
- Modular **GameManager**, **ReelController**, **Symbol**, **UIManager**, and **AudioManager**
- Randomised spin results with configurable symbols & payouts
- Basic win evaluation and credit tracking
- Hooks for UI (Unity UI) and audio (AudioSource)
- Clear code comments and SOLID-aligned structure

## 🧱 Project Structure
```
Assets/
  Scripts/
    GameManager.cs
    ReelController.cs
    Symbol.cs
    UIManager.cs
    AudioManager.cs
  Scenes/           # (create MainScene.unity here in Unity)
  Prefabs/          # (optional)
  Materials/        # (optional)
Packages/
ProjectSettings/
```

## 🚀 Quick Start
1. **Clone** this repo.
2. Open in **Unity 2022 LTS**.
3. Create a **UI Canvas** with a Text and two Buttons: **Spin** and **Reset**.
4. Add an **Empty GameObject** and attach `GameManager.cs` to it.
5. Add 3 child GameObjects for reels, each with `ReelController.cs` attached.
6. Add another GameObject with `UIManager.cs` and link Text/Buttons in the Inspector.
7. (Optional) Add `AudioManager.cs` with an **AudioSource** for sounds.
8. Click **Play** and test spins.

## 🧪 Notes
- This prototype keeps graphics minimal to emphasise **code quality**.
- Add sprites to `Symbol.icon` if you want visuals; otherwise it runs text-only.
- Extend `EvaluateWin()` to support paylines, wilds, or multi-symbol rewards.

## 📄 License
MIT
