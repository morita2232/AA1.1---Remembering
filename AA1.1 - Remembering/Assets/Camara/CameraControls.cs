using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControls : MonoBehaviour
{
    [Header("Referencias")]
    public Transform pivot;          //Pivot vacio en la pistola
    public Camera cam;               //Camara real

    [Header("Configuración")]
    public float sensitivityX = 100f; //sensibilidad horizontal
    public float sensitivityY = 80f; //sensibilidad vertical
    public float maxDistance = 5f; //distancia maxima de la camara desde el pivot
    public float minY = -30f; //limite minimo de rotacion vertical
    public float maxY = 60f; //limite maximo de rotacion vertical

    private float rotX = 0f; //rotacion vertical
    private float rotY = 0f; //rotacion horizontal

    private InputSystem_Actions inputActions; //acciones de input

    void Awake()
    {
        //Inicializar Input System
        inputActions = new InputSystem_Actions();

        //Habilitar el mapa de acciones "Player"
        inputActions.Enable();
    }

    void Start()
    {
        //Si no hay pivot o camara asignados, usar los que hay por defecto
        if (pivot == null) pivot = transform;
        if (cam == null) cam = Camera.main;

        //Obtener rotacion inicial del pivot
        Vector3 angles = pivot.localEulerAngles;

        //igualarlas a las variables de rotacion
        rotY = angles.y;
        rotX = angles.x;
    }

    void Update()
    {
        //Leer input WASD desde Input System generado
        Vector2 input = inputActions.Player.Move.ReadValue<Vector2>();
        float h = input.x;
        float v = input.y;

        //Actualizar rotaciones con sensibilidad y deltaTime
        rotY += h * sensitivityX * Time.deltaTime;
        rotX -= v * sensitivityY * Time.deltaTime;
        rotX = Mathf.Clamp(rotX, minY, maxY);

        //Aplicar rotacion al pivot
        pivot.localRotation = Quaternion.Euler(rotX, rotY, 0f);

        //Raycast para colisiones
        Vector3 dir = -pivot.forward;
        Ray ray = new Ray(pivot.position, dir);
        RaycastHit hit;

        //Si el raycast choca con algo que no sea el pivot o la camara, mover la camara al punto de colision
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            //Si el objeto chocado no es el pivot ni la camara
            if (hit.collider.transform != pivot && hit.collider.gameObject != cam.gameObject)
            {
                //Mover la camara al punto de colision
                cam.transform.position = hit.point;
            }
            //Si no, 
            else
            {
                //Dejar la camara en la distancia maxima
                cam.transform.localPosition = new Vector3(0f, 0f, -maxDistance);
            }
        }
        //Si no,
        else
        {
            //Dejar la camara en la distancia maxima
            cam.transform.localPosition = new Vector3(0f, 0f, -maxDistance);
        }
        //Traer la camara a mirar al pivot
        cam.transform.LookAt(pivot);
    }
}



