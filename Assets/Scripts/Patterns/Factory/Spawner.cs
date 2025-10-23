using UnityEngine;
using System.Collections.Generic;

public class TargetSpawner : MonoBehaviour
{
    public TargetFactory factory;
    public int maxTargets = 7;

    private List<GameObject> activeTargets = new List<GameObject>();

    void Start()
    {
        InitializeSpawning();
    }
    
    public void InitializeSpawning()
    {
        foreach (var t in activeTargets)
        {
            if (t != null)
                Destroy(t);
        }
        activeTargets.Clear();

        for (int i = 0; i < maxTargets; i++)
        {
            SpawnTarget();
        }
    }

    void Update()
    {
        if (GameManager.Instance == null || factory == null)
            return;
        activeTargets.RemoveAll(t => t == null);
        while (activeTargets.Count < maxTargets)
        {
            SpawnTarget();
        }
    }

    void SpawnTarget()
    {
        TargetType type = Random.value > 0.5f ? TargetType.Easy : TargetType.Hard;
        Vector3 pos = new Vector3(Random.Range(-20, 20), Random.Range(-5, 7), Random.Range(4, 12));
        GameObject target = factory.CreateTarget(type, pos);

        if (type == TargetType.Easy)
        {
            float scale = Random.Range(1.4f, 2.1f);
            target.transform.localScale = Vector3.one * scale;
        }
        else if (type == TargetType.Hard)
        {
            float scale = Random.Range(0.5f, 1f);
            target.transform.localScale = Vector3.one * scale;
        }

        activeTargets.Add(target);
    }
}