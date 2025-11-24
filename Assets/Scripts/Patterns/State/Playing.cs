using Patterns.State;
using UnityEngine;

public class Playing : GameState
{
    public void Enter()
    {
        Time.timeScale = 1f;
    }
}