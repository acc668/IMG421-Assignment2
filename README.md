# Apple Picker — Modified Prototype

## Overview
A modified version of the Apple Picker prototype from *Introduction to Game Design, Prototyping, and Development* (Chapter 28). This version adds four difficulty modes, a main menu, win conditions, a guided tutorial, and a game over screen.

---

## How to Play
- **Move your mouse** left and right to move the basket(s)
- Catch apples before they hit the ground
- Missing an apple destroys your top basket
- Reach the catch target to **win**; lose all baskets to **lose**

---

## Difficulty Modes

| Difficulty | Tree Speed | Drop Delay | Baskets | Basket Width | Win Target | Special |
|------------|-----------|------------|---------|--------------|------------|---------|
| Tutorial   | 3 u/s     | 2.5s       | 5       | 6 units      | 5 apples   | Guided prompts |
| Easy       | 6 u/s     | 1.5s       | 3       | 4 units      | 20 apples  | —       |
| Medium     | 10 u/s    | 1.0s       | 3       | 3.5 units    | 35 apples  | —       |
| Hard       | 15 u/s    | 0.7s       | 2       | 3 units      | 50 apples  | —       |
| Hell       | 20 u/s    | 0.4s       | 1       | 2 units      | 75 apples  | Two trees, faster gravity |

---

## Game Balancing Notes

### Philosophy
Each difficulty is tuned so that a **skilled player** has roughly a 60–70% catch rate at the *minimum*, while a new player on Easy/Tutorial can learn the loop without frustration. Here's how each knob affects balance:

### Tree Speed
The tree speed determines how much *horizontal range* the player must cover with their basket. At 3 u/s (Tutorial), the player has ample time to react. At 20 u/s (Hell), the tree crosses the screen so fast that prediction and preemptive positioning are required rather than reactive catching.

### Drop Delay
Fewer seconds between drops means more apples in the air simultaneously. On Easy, at 1.5s intervals, only one apple is in play at a time during a normal run. On Hell, at 0.4s intervals with two trees, up to 4–5 apples can be falling simultaneously — far more than one basket can cover.

### Basket Width
Narrower baskets reduce the effective "catch zone." A basket width of 6 (Tutorial) is forgiving enough for a player who overshoots slightly. A width of 2 (Hell) requires very precise positioning.

### Gravity Scale
Apples fall progressively faster on harder difficulties. This reduces the player's reaction window. On Tutorial (0.5× gravity), the apple takes roughly twice as long to fall as on Hard, giving new players time to read the situation.

### Basket Count
Basket count is the primary "lives" system. Tutorial gives 5 lives so a player can make 5 mistakes before losing. Hell gives 1 — a single missed apple ends the round.

### Win Target Calibration
Win targets are set so that each difficulty takes approximately **2–4 minutes** for a skilled player to complete, creating a satisfying challenge without becoming a grind:
- Tutorial (5 apples): ~30 seconds — just enough to demonstrate mastery of the basic mechanic
- Easy (20 apples): ~2 min — comfortable for a new player
- Medium (35 apples): ~3 min — requires consistent focus
- Hard (50 apples): ~3.5 min — one mistake is very costly with only 2 baskets
- Hell (75 apples): ~4+ min — with 1 basket and two trees, every single apple counts

### Hell Mode Balance Note
Hell is *intentionally imbalanced toward difficulty*. Two trees firing at 0.4s intervals with only one basket means the player will frequently face impossible choices. This is a deliberate design decision: Hell mode is a score-attack / endurance challenge, not an expected-to-win scenario. The win target of 75 is achievable but requires near-perfect play.

---

## Credits
Based on the Apple Picker prototype from *Introduction to Game Design, Prototyping, and Development* by Jeremy Gibson Bond.
