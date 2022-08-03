using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public FloatingJoystick joystick;
    public Animator animator;
    public GameObject scytheObject;
    public float movementSpeed;
    public float rotationSpeed;

    private Rigidbody rigidbody;
    private float maxInput;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        maxInput = Mathf.Max(Mathf.Abs(joystick.Vertical), Mathf.Abs(joystick.Horizontal));
        Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
        Vector3 fwd = transform.forward * maxInput;

        animator.SetFloat("Speed", maxInput);

        if (maxInput > 0 && direction != Vector3.zero) 
            rigidbody.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
        rigidbody.velocity = fwd * movementSpeed;
    }

    private void Attack()
    {
        if (maxInput > 0)
        {
            animator.ResetTrigger("Attack");
            scytheObject.SetActive(false);
        }
        else
        {
            scytheObject.SetActive(true);
            animator.SetTrigger("Attack");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case "Wheat":
                Attack();
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
