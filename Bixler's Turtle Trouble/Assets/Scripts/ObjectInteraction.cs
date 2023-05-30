using UnityEngine;
using TMPro;

public class ObjectInteraction : MonoBehaviour
{
    [SerializeField] float raycastDistance = 2f;
    public LayerMask pickupLayer;
    public TextMeshProUGUI textMeshPro;
    public PhysicsPickup physicsPickup;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance, pickupLayer))
        {
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.layer == LayerMask.NameToLayer("Pickup"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (physicsPickup.isHoldingObject)
                    {
                        physicsPickup.ReleaseObject();
                        textMeshPro.text = "Press E to pick up " + hitObject.name;
                    }
                    else
                    {
                        physicsPickup.PickUpObject();
                        textMeshPro.text = "Press E to drop " + hitObject.name;
                    }
                }
                else
                {
                    textMeshPro.text = "Press E to pick up " + hitObject.name;
                }
            }
        }
        else
        {
            textMeshPro.text = "";
        }
    }
}