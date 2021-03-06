using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{

    bool spawn = true;
    [SerializeField] Attacker[] attackerPrefabArray;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        var attackerIndex = UnityEngine.Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }
  
    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate
            (myAttacker, transform.position, transform.rotation, transform)
            as Attacker;
    }
}
