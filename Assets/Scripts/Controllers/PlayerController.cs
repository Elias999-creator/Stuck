using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Interactable focus;

    public LayerMask movementMask;

    Camera cam;
    public float attackRange;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    float distance = Vector3.Distance(interactable.transform.position, transform.position);
                    if (distance <= attackRange)
                    {
                        FaceTarget(interactable.transform);
                        interactable.Interact();
                    }
                }
            }
        }
    }

    void FaceTarget(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = lookRotation;
    }
}
