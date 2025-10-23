Richard Li - 100928851 - Roles: Everything, Contribution : 100%
Singleton

Created 2 managers: UIManager and GameManager.
UIManager handles:
Updating score and timer
Displaying time, score, and accuracy for the player.
GameManager handles:
Checking if the game is over.
Benefits:
Easy communication between managers.
Other scripts can easily access the managers.

DLLs (Dynamic Link Libraries)
Created a system where scores double when player reaches halfway mark or 50 points.
Benefits:
Separates reusable logic (score calculations) from main code.
Can be used in future projects.
Allows easy swapping of libraries if needed.
Usage:
GameManager calls the method from the DLL to calculate score, which is then displayed by UIManager.

Command Pattern
Encapsulates player actions (e.g., shooting a raycast).
Separates input detection from actual actions:
Pressing left mouse button sends a command, which executes the behavior.
Benefits:
Easy to create new commands.
Commands can be recorded for other uses (like replay systems or AI).

Factory Pattern (Spawning)
Handles object creation without knowing the internal details.
TargetSpawner example:
Chooses a random position (Vector3) for spawning.
Factory selects which target to spawn.
Benefits:
Makes spawning flexible.
Can easily add new object types.

Description:
The player is challenged to hit moving and static targets in a 3D environment. Targets are of two types:
Easy targets – larger in size, easier to hit.
Hard targets – smaller, harder to hit.
There are always 7 targets in the scene. When one is destroyed, another spawns to maintain the target count.

https://youtu.be/ZSf3RxE24Ac
