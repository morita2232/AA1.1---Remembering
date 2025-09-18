using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rB;
    public float forceAmount = 10f; // You can adjust this to control how fast the bullet moves

    void Start()
    {
        if (rB == null)
        {
            rB = GetComponent<Rigidbody>(); // Ensure we are referencing the Rigidbody if not set in the editor
        }

        // Apply an instantaneous force in the forward direction
        rB.AddForce(transform.forward * forceAmount, ForceMode.Impulse);
    }

    void Update()
    {
        // No need to put anything here unless you want to handle other updates
    }
}

