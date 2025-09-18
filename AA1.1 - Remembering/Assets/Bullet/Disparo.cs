using UnityEngine;

public class Disparo : MonoBehaviour
{

    //rigidbody en un script de la bala para el add force

    public GameObject finPistola;
    public GameObject bala;
    InputSystem_Actions inputActions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
        inputActions = new InputSystem_Actions();
        inputActions.Enable();

    }

    // Update is called once per frame
    void Update()
    {

        if(inputActions.Player.Attack.triggered)
        {

            Instantiate(bala, finPistola.transform.position, Quaternion.identity);
            bala.transform.localScale = new Vector3(0.15f,0.15f, 0.15f);
       

        }

    }
}
