using UnityEngine;
using UnityEngine.InputSystem;

public class MovTorreta : MonoBehaviour
{

    public GameObject baseTorreta;
    public GameObject torsoTorreta;

    public bool baseT;
    public bool torsoT;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (baseT == true)
        {


            baseTorreta.transform.localEulerAngles += new Vector3 (0, Mouse.current.delta.value.x);


        }
        
        if (torsoT == true)
        {


            torsoTorreta.transform.localEulerAngles += new Vector3 (Mouse.current.delta.value.y, 0);

            


        }
    }
}
