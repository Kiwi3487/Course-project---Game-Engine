using UnityEngine;
using System.Collections.Generic;
using Observer;

public class TargetSpawner : MonoBehaviour
{
    public TargetFactory factory;
    public int maxTargets = 7;

    private readonly List<GameObject> activeTargets = new();

    void Start()
    {
        InitializeSpawning();
    }

    private void OnEnable()
    {
        TargetCalls.OnTargetHit += HandleTargetHit;
    }

    private void OnDisable()
    {
        TargetCalls.OnTargetHit -= HandleTargetHit;
    }

    public void InitializeSpawning()
    {
        activeTargets.Clear();

        for (int i = 0; i < maxTargets; i++)
            SpawnTarget();
    }

    private void HandleTargetHit()
    {
        activeTargets.RemoveAll(t => t == null || !t.activeSelf);
        
        if (activeTargets.Count < maxTargets)
            SpawnTarget();
    }

    void Update()
    {
        activeTargets.RemoveAll(t => t == null || !t.activeSelf);

        while (activeTargets.Count < maxTargets)
            SpawnTarget();
    }

    void SpawnTarget()
    {
        TargetType type = Random.value > 0.5f ? TargetType.Easy : TargetType.Hard;

        Vector3 pos = new Vector3(
            Random.Range(-20, 20),
            Random.Range(-5, 7),
            Random.Range(4, 12));

        GameObject target = factory.CreateTarget(type, pos);
        target.transform.localScale = Vector3.one;

        if (type == TargetType.Easy)
            target.transform.localScale *= Random.Range(1.4f, 2.1f);
        else
            target.transform.localScale *= Random.Range(0.5f, 1f);

        activeTargets.Add(target);
    }
}