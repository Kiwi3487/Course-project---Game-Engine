using Observer;
using UnityEngine;

public class ShootCommand : Command
{
    public void Execute()
    {
        if (GameManager.Instance.IsEndingState)
            return;
        
        Camera cam = Camera.main;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        bool hitSomething = false;

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Target target = hit.collider.GetComponent<Target>();
            if (target != null)
            {
                target.OnHit();
                hitSomething = true;
            }
        }
        
        if (!hitSomething)
            TargetCalls.TargetMiss();
        
        UIManager.Instance.RegisterClick(hitSomething);
    }
}