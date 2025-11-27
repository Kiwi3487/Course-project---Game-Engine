using Observer;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointValue = 10;
    
    public void OnHit()
    {
        GameManager.Instance.AddScore(pointValue);
        TargetCalls.TargetHit();
        ObjectPooling.Instance.ReturnToPool(gameObject.tag, gameObject);
    }

}