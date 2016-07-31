using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float MoveSpeed;
    public float JumpForce;
    public GameObject Tiro;
    public GameObject Arma;

    private Rigidbody2D MyRigidbody;

    [SerializeField]
    private Transform[] GroundPoints;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatisGround;

    private bool isGrounded;

    private bool jump;

    // Use this for initialization
    void Start () {
        MyRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = IsGrounded();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            jump = true;
        }

        if (isGrounded && jump)
        {
            isGrounded = false;
            MyRigidbody.velocity = new Vector2(MyRigidbody.velocity.x, JumpForce);
            jump = false;
        }

        if (Input.GetKeyDown (KeyCode.A)) {
            GameObject Tiro01 = (GameObject)Instantiate (Tiro);
            Tiro01.transform.position = Arma.transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        MyRigidbody.velocity = new Vector2(MoveSpeed, MyRigidbody.velocity.y);
    }

    private bool IsGrounded ()
      {
          if (MyRigidbody.velocity.y <= 0)
        {
          foreach (Transform point in GroundPoints)
          {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatisGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
