using UnityEngine;
using System.Collections;

public class InimigoController : MonoBehaviour {

    public float MoveSpeed;
		public float JumpForce;
    private Rigidbody2D MyRigidbody;

		[SerializeField]
		private Transform[] GroundPoints;

		[SerializeField]
		private float groundRadius;

		[SerializeField]
		private LayerMask whatisGround;

		private bool isGrounded = true;

		private float jump;

    public GameObject Arma;

    public GameObject Tiro;

	// Use this for initialization
	void Start () {
        MyRigidbody = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate ()
	{
		isGrounded = IsGrounded();
		if (isGrounded)
		{
				jump = JumpForce;
				MyRigidbody.velocity = new Vector2(MoveSpeed, JumpForce);
				jump = 0;
				isGrounded = false;

		}
	}

	// Update is called once per frame
	void Update () {
	}

	private bool IsGrounded ()
	{
				if (jump == 0)
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

	void Teste () {
		JumpForce = 0;
		MoveSpeed = 0;
	}

	void Teste2 ()
	{
		JumpForce = 3f;
		MoveSpeed = -2f;
	}

  void arma ()
  {
        GameObject Tiro01 = (GameObject)Instantiate (Tiro);
        Tiro01.transform.position = Arma.transform.position;
  }

	void OnTriggerEnter2D(Collider2D obj) {

    if (obj.gameObject.tag == "Tiro Player") {
        Destroy(gameObject);
    }
	}

}
