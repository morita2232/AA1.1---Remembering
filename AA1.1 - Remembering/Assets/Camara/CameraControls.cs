using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControls : MonoBehaviour
{
    [Header("Referencias")]
    public Transform pivot;          // Pivot vacío en la pistola
    public Camera cam;               // Cámara real

    [Header("Configuración")]
    public float sensitivityX = 100f;
    public float sensitivityY = 80f;
    public float maxDistance = 5f;
    public float minY = -30f;
    public float maxY = 60f;

    private float rotX = 0f;
    private float rotY = 0f;

    private InputSystem_Actions inputActions;

    void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Enable();
    }

    void Start()
    {
        if (pivot == null) pivot = transform;
        if (cam == null) cam = Camera.main;

        Vector3 angles = pivot.localEulerAngles;
        rotY = angles.y;
        rotX = angles.x;
    }

    void Update()
    {
        // Leer input WASD desde Input System generado
        Vector2 input = inputActions.Player.Move.ReadValue<Vector2>();
        float h = input.x;
        float v = input.y;

        rotY += h * sensitivityX * Time.deltaTime;
        rotX -= v * sensitivityY * Time.deltaTime;
        rotX = Mathf.Clamp(rotX, minY, maxY);

        pivot.localRotation = Quaternion.Euler(rotX, rotY, 0f);

        // Raycast para colisiones
        Vector3 dir = -pivot.forward;
        Ray ray = new Ray(pivot.position, dir);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.collider.transform != pivot && hit.collider.gameObject != cam.gameObject)
            {
                cam.transform.position = hit.point;
            }
            else
            {
                cam.transform.localPosition = new Vector3(0f, 0f, -maxDistance);
            }
        }
        else
        {
            cam.transform.localPosition = new Vector3(0f, 0f, -maxDistance);
        }

        cam.transform.LookAt(pivot);
    }
}



