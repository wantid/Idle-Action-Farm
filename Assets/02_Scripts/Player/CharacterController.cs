using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public FloatingJoystick joystick;
    public Animator animator;
    public GameObject scytheObject;
    public float movementSpeed;
    public float rotationSpeed;

    private void Update()
    {
        float maxInput = Mathf.Max(Mathf.Abs(joystick.Vertical), Mathf.Abs(joystick.Horizontal));
        Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
        Vector3 fwd = Vector3.forward * maxInput;

        animator.SetFloat("Speed", maxInput);

        if (maxInput != 0 && direction != Vector3.zero)
        {
            animator.ResetTrigger("Attack");
            scytheObject.SetActive(false);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
        } 
        transform.Translate(fwd * movementSpeed * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case "Wheat":
                scytheObject.SetActive(true);
                animator.SetTrigger("Attack");
                break;
            case "CutWheat":
                other.GetComponent<CutWheat>().GoToStack();
                break;
            case "Barn":
                other.GetComponent<WheatSell>().StockWheat(transform.position);
                break;
            default:
                Debug.Log($"Collision with {other.name}({other.tag})");
                break;
        }
    }
}
