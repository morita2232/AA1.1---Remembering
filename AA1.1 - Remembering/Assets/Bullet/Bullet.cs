using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rB; //Referencia al Rigidbody
    public float forceAmount = 10f; //Fuerza de impulso

    void Start()
    {
        //Si no hay Rigidbody asignado, obtener el componente
        if (rB == null)
        {
            rB = GetComponent<Rigidbody>();
        }

        //Aplicar fuerza de impulso en la direccion "up" del transform
        rB.AddForce(transform.up * forceAmount, ForceMode.Impulse);

        //Destruir la bala despues de 5 segundos para evitar acumulacion
        Destroy(gameObject, 5f);
    }
}





