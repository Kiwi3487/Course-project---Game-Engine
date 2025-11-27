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

Observer Pattern
Custom observer system using a static class TargetCalls.
It contains two events: OnTargetHit and OnTargetMiss.
When a target is clicked, it invokes TargetHit().
UIManager subscribes to these events to update accuracy and statistics without depending directly on the Target object.
This removes tight coupling and allows other systems to react to hits or misses.

State Pattern
Used to manage gameplay flow.
Two states: Playing and Ending.
GameManager holds a reference to the current state and switches between them.
When the player reaches the score/time limit, it switches to the Ending state which freezes gameplay so no more inputs are possible.

Object Pooling
Implemented an object pool using a dictionary of queues
Each target type (Easy, Hard) has its own pool.
Instead of instantiating new objects, the pool reuses inactive ones.
When a target is hit, it is returned to the pool.
This reduces performance cost and prevents memory spikes.

Game Description:
The player is challenged to hit moving and static targets in a 3D environment. Targets are of two types:
Easy targets – larger in size, easier to hit.
Hard targets – smaller, harder to hit.
The total targets start at 14 and reduces to 7 as the game goes on.

https://youtu.be/ZSf3RxE24Ac
