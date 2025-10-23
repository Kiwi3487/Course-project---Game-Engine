using UnityEngine;

public class ShootCommand : Command
{
    public void Execute()
    {
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
        
        UIManager.Instance.RegisterClick(hitSomething);
    }
}