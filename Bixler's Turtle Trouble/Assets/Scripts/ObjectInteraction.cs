using UnityEngine;
using TMPro;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject player;
    public TMP_Text textBox;
    public string objectName;
    public string interactionMessage;

    private bool isLookingAtObject = false;

    void Update()
    {
        // Check if the player is looking at the object
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, player.transform.forward, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                isLookingAtObject = true;
                textBox.text = "Press E to pick up " + objectName;
                textBox.gameObject.SetActive(true);
            }
            else
            {
                isLookingAtObject = false;
                textBox.gameObject.SetActive(false);
            }
        }

        // Check for interaction input
        if (isLookingAtObject && Input.GetKeyDown(KeyCode.E))
        {
            // Perform the interaction here, e.g., picking up the object
            // ...
        }
    }
}