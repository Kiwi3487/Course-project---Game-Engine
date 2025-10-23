using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Command shootCommand;

    void Start()
    {
        shootCommand = new ShootCommand();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootCommand.Execute();
        }
    }
}