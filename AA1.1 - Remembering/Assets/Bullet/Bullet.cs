using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rB;
    public float forceAmount = 10f;

    void Start()
    {
        if (rB == null)
        {
            rB = GetComponent<Rigidbody>();
        }

        
        rB.AddForce(transform.up * forceAmount, ForceMode.Impulse);
        Destroy(gameObject, 5f);
    }
}





