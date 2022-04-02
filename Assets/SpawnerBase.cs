using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace NeneChico
{  
    /// Spawns objects randomly in a cube defined by 2 corners
    public abstract class SpawnerBase : MonoBehaviour
    {
        [Tooltip("Object used as first corner for spawnpoints location")]
        public Transform FirstCorner;

        [Tooltip("Object used as last corner for spawnpoints location")]
        public Transform LastCorner;


        [Tooltip("Maximum delay in seconds between each spawn event")]
        public float MaxTimeBetweenSpawn = 0.5f;

        [Tooltip("Minimum delay in seconds between each spawn event")]
        public float MinTimeBetweenSpawn = 0.1f;

        [Tooltip("Maximum Quantity of spawn objects at spawn event")]
        public int MaxSpawnQuantity = 2;

        [Tooltip("Minimum Quantity of spawn objects at spawn event")]
        public int MinSpawnQuantity = 1;

        protected List<GameObject> aliveSpawneds = new List<GameObject>();

        protected float timer = 0.0f;

        protected long spawnCount = 0;

        [Tooltip("Unity Event called when an object is spawned")]
        public UnityEvent OnSpawnEvent;

        [Tooltip("Unity Event called if the spawned object is a DamageableAI and is destroyed")]
        public UnityEvent OnSpawnedDamageableAIDestroyEvent;

        [Tooltip("Maximum of spawn objects (0 for unlimited)")]
        [Range(0, 9999)]
        public int MaxSpawned = 0;

        public bool DrawSpawnCubeDiagonal;

        void Start()
        {
            timer = Random.Range(MinTimeBetweenSpawn, MaxTimeBetweenSpawn);
        }

        void OnEnable()
        {
            timer = Random.Range(MinTimeBetweenSpawn, MaxTimeBetweenSpawn);
        }

        void OnDisable()
        {
            DestroyAllSpawned();
        }

        void Update()
        {
            timer -= Time.deltaTime;

            if (timer <= 0.0f)
            {
                int spawnQuantity = Random.Range(MinSpawnQuantity, MaxSpawnQuantity);
                for (int i = 0; i < spawnQuantity; i++)
                {
                    Spawn();
                }
                timer = Random.Range(MinTimeBetweenSpawn, MaxTimeBetweenSpawn);
            }
        }

        public int GetAliveSpawneds()
        {
            aliveSpawneds.RemoveAll(item => item == null);
            return aliveSpawneds.Count;
        }

        public abstract void Spawn();

        public void DestroyAllSpawned()
        {
            aliveSpawneds.RemoveAll(item => item == null);
            aliveSpawneds.ForEach(o => Object.Destroy(o));
        }

        /// returns the total networked spawned prefab locally (not the total count in the game)
        public long GetLocalSpawnCount()
        {
            return spawnCount;
        }

        protected void OnDrawGizmos()
        {
            if (DrawSpawnCubeDiagonal)
            {
                OnDrawGizmosSelected();
            }
        }

        protected void OnDrawGizmosSelected()
        {
            Debug.DrawLine(FirstCorner.transform.position, LastCorner.transform.position, Color.yellow);
        }
    }
}