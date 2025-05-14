using UnityEngine;
using UnityEngine.InputSystem;

public class lookController : MonoBehaviour
{
    [SerializeField]
    Camera head;
    Vector2 lookInput;
    [SerializeField]
    Vector2 sensitivity = Vector2.one;
    [SerializeField]
    float pickupRange;
    [SerializeField]
    GameObject rocket;
    [SerializeField]
    float rocketLauncherCooldown;
    float rocketLauncherTimer;


    float xRotation = 0;

    void Start()
    {
        head = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        rocketLauncherTimer -= Time.deltaTime;
        xRotation += lookInput.y * sensitivity.y;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        head.transform.localEulerAngles = new(xRotation, 0, 0);

        transform.Rotate(Vector3.up, lookInput.x * sensitivity.x);
        head.transform.Rotate(Vector3.right, lookInput.y * sensitivity.y);
    }

    void OnLook(InputValue Value)
    {
        lookInput = Value.Get<Vector2>();
    }

    void OnUse(InputValue Value)
    {
        RaycastHit hit;
        if (Physics.Raycast(head.transform.position, head.transform.forward, out hit, pickupRange))
        {
            if (hit.collider.CompareTag("usable"))
            {
                hit.collider.GetComponent<UsableObejctController>().PickedUp(GetComponent<inventoryManager>().inventory);
            }
        }
    }

    void OnFireRocket()
    {
        if (rocketLauncherTimer <= 0)
        {
            Instantiate(rocket, head.transform.position + head.transform.forward * 0.5f, head.transform.rotation);
            rocketLauncherTimer = rocketLauncherCooldown;
        }   
    }
}
