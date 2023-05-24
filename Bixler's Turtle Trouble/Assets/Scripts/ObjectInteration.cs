using UnityEngine;
using TMPro;

public class ObjectInteractionTMP : MonoBehaviour
{
    public GameObject player;
    public TMP_Text textBox;
    public LayerMask pickupLayer;
    [SerializeField] TextMeshProUGUI Interaction; 
    

    private bool isLookingAtObject = false;

    void Update()
    {
        // Check if the player is looking at any objects on the pickup layer
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, Mathf.Infinity, pickupLayer))
        {
            isLookingAtObject = true;
            Interaction.text = "Press E to interact";
            textBox.gameObject.SetActive(true);
        }
        else
        {
            isLookingAtObject = false;
            textBox.gameObject.SetActive(false);
        }

        // Check for interaction input
        if (isLookingAtObject && Input.GetKeyDown(KeyCode.E))
        {
            // Perform the interaction here, e.g., picking up the object
            // ...
        }
    }
}