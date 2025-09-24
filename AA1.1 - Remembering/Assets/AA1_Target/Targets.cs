using UnityEngine;

public class Targets : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject wholeTargetModel;     //modelo del target intacto
    public GameObject destroyedTargetPrefab; //modelo del target destruido

    private GameObject spawnedBroken; //referencia al target destruido instanciado
    private bool isDestroyed = false; //estado del target
    private float timer = 0f; //contador para respawn
    private float respawnDelay = 3f; //tiempo para respawn

    [Header("Target Type")]
    public bool enemy; //si es enemigo o no
    public bool special; //si es un target especial

    public ScoreManager scoreManager; //referencia al ScoreManager

    void Update()
    {
        //Si el target esta destruido y no es enemigo, iniciar el contador para respawn
        if (!enemy && isDestroyed)
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
        //Si ya esta destruido, no hacer nada
        if (isDestroyed) return;

        //Si colisiona con una bala y no es enemigo, destruir el target
        if (other.CompareTag("Bullet") && !enemy)
        {

            Debug.Log("Target hit!");

            //Esconder modelo intacto
            wholeTargetModel.SetActive(false);

            //Spawn del modelo destruido
            spawnedBroken = Instantiate(destroyedTargetPrefab, transform.position, Quaternion.Euler(90f, 0f, 0f));

            //Si es especial, sumar mas puntos
            if (special)
            {
                scoreManager.score += 500;
            }
            //si no es especial, sumar puntos normales
            else
            {
                scoreManager.score += 100;
            }

            //Actualizar estado
            isDestroyed = true;

            //Resetear timer
            timer = 0f;
        }

        //Si colisiona con una bala y es enemigo, restar puntos
        if (other.CompareTag("Bullet") && enemy)
        {
            Debug.Log("Enemy hit!");
            scoreManager.score -= 100;
        }
    }

    private void RespawnTarget()
    {
        //Destruir el modelo destruido si existe
        if (spawnedBroken != null)
        {
            Destroy(spawnedBroken);
        }

        //Reactivar el modelo intacto
        wholeTargetModel.SetActive(true);

        //Resetear estado y timer
        isDestroyed = false;
        timer = 0f;
    }
}

