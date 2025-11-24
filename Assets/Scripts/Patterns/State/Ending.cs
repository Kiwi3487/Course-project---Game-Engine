using Patterns.State;
using UnityEngine;

public class Ending : GameState
{
    public void Enter()
    {
        Time.timeScale = 0f;
    }
}
