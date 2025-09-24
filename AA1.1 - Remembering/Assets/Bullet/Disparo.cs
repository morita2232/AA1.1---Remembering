using UnityEngine;
using UnityEngine.InputSystem;

public class Disparo : MonoBehaviour
{
    public GameObject bulletPrefab; //Prefab de la bala
    public Transform spawnPoint; //Punto de spawn de la bala
    InputSystem_Actions inputActions; //Acciones de input
    void Start()
    {
        //Inicializar Input System
        inputActions = new InputSystem_Actions();
        inputActions.Enable();

    }

    void Update()
    {
        //Disparar cuando se presiona el boton de disparo
        if (inputActions.Player.Attack.triggered)
        {
            // La bala hereda la posición y rotación del spawnPoint
            Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}

