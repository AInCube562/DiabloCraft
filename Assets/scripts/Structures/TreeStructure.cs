using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeStructure : Structure
{
    [SerializeField] [Range(0, 1)] private float spawnChance = 0.5f;
    public override bool CheckCanSpawn()
    {
        return Random.Range(0f, 1f) < spawnChance;
    }
}
