using UnityEngine;

public class Targets : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject wholeTargetModel;     // intact target mesh + collider
    public GameObject destroyedTargetPrefab; // prefab with pieces + rigidbodies

    private GameObject spawnedBroken; // reference to the broken instance
    private bool isDestroyed = false;
    private float timer = 0f;
    private float respawnDelay = 3f;

    void Update()
    {
        if (isDestroyed)
        {
            timer += Time.deltaTime;
            Debug.Log("Timer: " + timer);

            if (timer >= respawnDelay)
            {
                Debug.Log("Respawning target");
                RespawnTarget();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDestroyed) return;

        if (other.CompareTag("Bullet"))
        {

            Debug.Log("Target hit!");
            
            // Hide whole target model
            wholeTargetModel.SetActive(false);

            // Spawn broken target with physics
            spawnedBroken = Instantiate(destroyedTargetPrefab, transform.position, Quaternion.Euler(90f, 0f, 0f));

            // Start countdown
            isDestroyed = true;
            timer = 0f;
        }
    }

    private void RespawnTarget()
    {
        // Destroy the broken pieces
        if (spawnedBroken != null)
        {
            Destroy(spawnedBroken);
        }

        // Reactivate the intact model
        wholeTargetModel.SetActive(true);

        // Reset state
        isDestroyed = false;
        timer = 0f;
    }
}

