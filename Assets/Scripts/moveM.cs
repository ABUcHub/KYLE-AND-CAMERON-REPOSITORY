using UnityEngine;



public class MonkeyMovement : MonoBehaviour
{
    //variable initialisation.
    private Rigidbody2D rigiB;
    private float moveS;
    private Vector2 movementM;
    public float movementSpeed = 3.5f;
    public float jumpHeight = 7.5f;

    public GameObject WinObj;

    //manages the banana counting with the monkey collecting them
    public BananaManager bm;
    void Start()
    {
        rigiB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // moving & jumping 
        moveS = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigiB.linearVelocity = new Vector2(rigiB.linearVelocity.x, jumpHeight);
        }
    }
    // monkey movement for our silly monkey 
    private void FixedUpdate()
    {
        movementM = new Vector2(moveS * movementSpeed, rigiB.linearVelocity.y);
        rigiB.linearVelocity = movementM;
    }

    //banana collection.
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("banana collect"))
        {
            Destroy(other.gameObject);
            bm.bananaCount++;
        }

        if (other.gameObject.CompareTag("winObject"))
        {
            Debug.Log("Win object collected");
            WinObj.SetActive(true);
        }
    }
}