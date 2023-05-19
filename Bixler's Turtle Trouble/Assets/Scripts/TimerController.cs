using UnityEngine;

public class TimerController : MonoBehaviour
{
    private bool hasPickedUpObject = false;
    private CountDown countDownScript;

    private void Start()
    {
        countDownScript = FindObjectOfType<CountDown>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasPickedUpObject && other.gameObject.CompareTag("Turtle"))
        {
            Rigidbody turtleRigidbody = other.gameObject.GetComponent<Rigidbody>();
            if (turtleRigidbody != null && !turtleRigidbody.useGravity)
            {
                hasPickedUpObject = true;
                countDownScript.gameObject.SetActive(true);
                countDownScript.Start();
            }
        }
    }
}