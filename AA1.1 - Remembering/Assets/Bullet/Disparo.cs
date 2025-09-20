using UnityEngine;
using UnityEngine.InputSystem;

public class Disparo : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    InputSystem_Actions inputActions;
    void Start()
    {

        inputActions = new InputSystem_Actions();
        inputActions.Enable();

    }

    void Update()
    {
        if (inputActions.Player.Attack.triggered)
        {
            // La bala hereda la posición y rotación del spawnPoint
            Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}

