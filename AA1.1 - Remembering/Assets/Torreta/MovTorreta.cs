using UnityEngine;
using UnityEngine.InputSystem;

public class MovTorreta : MonoBehaviour
{
    public GameObject baseTorreta;
    public GameObject torsoTorreta;

    public bool baseT;
    public bool torsoT;

    public float minBaseY = -60f;  
    public float maxBaseY = 60f;

    public float minTorsoX = -20f; 
    public float maxTorsoX = 45f;

    private float baseRotationY = 0f;
    private float torsoRotationX = 0f;

    
    private Transform baseTransform;
    private Transform torsoTransform;

    void Start()
    {
        baseTransform = baseTorreta != null ? baseTorreta.transform : null;
        torsoTransform = torsoTorreta != null ? torsoTorreta.transform : null;

        if (baseTransform != null)
            baseRotationY = baseTransform.localEulerAngles.y;

        if (torsoTransform != null)
            torsoRotationX = torsoTransform.localEulerAngles.x;
    }

    void Update()
    {
        Vector2 mouseDelta = Mouse.current.delta.value;

        if (baseT && baseTransform != null)
        {
            baseRotationY += mouseDelta.x;
            baseRotationY = Mathf.Clamp(baseRotationY, minBaseY, maxBaseY);

            Vector3 euler = baseTransform.localEulerAngles;
            euler.y = baseRotationY;
            baseTransform.localEulerAngles = euler;
        }

        if (torsoT && torsoTransform != null)
        {
            torsoRotationX += mouseDelta.y;
            torsoRotationX = Mathf.Clamp(torsoRotationX, minTorsoX, maxTorsoX);

            Vector3 euler = torsoTransform.localEulerAngles;
            euler.x = torsoRotationX;
            torsoTransform.localEulerAngles = euler;
        }
    }
}

