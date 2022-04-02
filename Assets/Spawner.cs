using UnityEngine;
using System.Collections.Generic;

namespace NeneChico
{  
    /// Spawns several types of objects randomly among a list of preba 
    public class Spawner : SpawnerBase
    {
        [Tooltip("Optional Game Object parent for spawned objects")]
        [SerializeField]
        protected GameObject spawnedObjectsParent = null;

        [SerializeField] 
        protected List<GameObject> spawnablePrefabs = new List<GameObject>();

        void Awake()
        {
            if (spawnedObjectsParent == null)
            {
                spawnedObjectsParent = this.gameObject;
            }
        }

        override public void Spawn()
        {
            GameObject prefab = spawnablePrefabs[Random.Range(0, spawnablePrefabs.Count)];
            Vector3 spawnLocation = new Vector3(Random.Range(FirstCorner.position.x, LastCorner.position.x),
                                                Random.Range(FirstCorner.position.y, LastCorner.position.y),
                                                Random.Range(FirstCorner.position.z, LastCorner.position.z));
            Quaternion spawnRotation = prefab.transform.rotation;

            if (MaxSpawned == 0 || GetAliveSpawneds() < MaxSpawned)
            {
                GameObject instance = null;
                //Debug.Log("Spawning a " + prefab.name);
                instance = Instantiate(prefab, spawnLocation, spawnRotation, spawnedObjectsParent.transform); //TODO: object pool management per prefab
                if (instance)
                {
                    aliveSpawneds.Add(instance);
                    spawnCount++;
                    OnSpawnEvent.Invoke();
                }
                else
                {
                    Debug.LogError("Failed to instanciate {prefab.name}");
                }
            }
        }
    }
}