using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSpawnData", menuName = "Custom Data/LevelSpawnData")]
public class LevelData : ScriptableObject
{
    [SerializeField] public List<SpawnEntry> spawns = new List<SpawnEntry>();
}
