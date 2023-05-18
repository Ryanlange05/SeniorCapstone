using UnityEngine;

public class TimerController : MonoBehaviour
{
    private bool hasPickedUpObject = false;
    private CountDown countDownScript;

    private void Start()
    {
        countDownScript = GetComponentInChildren<CountDown>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !hasPickedUpObject)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Turtle"))
                {
                    hasPickedUpObject = true;
                    countDownScript.gameObject.SetActive(true);
                    countDownScript.StartTimer();
                    break;
                }
            }
        }
    }
}