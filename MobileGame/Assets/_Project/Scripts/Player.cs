using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private GameObject playerMesh;
    [SerializeField] private float speed;
    [SerializeField] private float stepSpeed;
    [SerializeField] private float currentLane = 0;
    [SerializeField] private float laneLimit = 1;

    [Header("Jump Settings")]
    [SerializeField] private Transform sensorGround;
    [SerializeField] private float sensorRadius;



    private Vector3 currentPosition;

    private Animator anim;

    private void Start()
    {        
        anim = playerMesh.GetComponent<Animator>();
        currentPosition = transform.position;
    }

    private void Update()
    {
        if (GameManager.inGame)
        {
            Move();
            anim.SetBool("pInGame", GameManager.inGame);
        }
    }


    void OnGround()
    {
        // Physics.OverlapSphere(sensorGround.position, sensorRadius, 1 << LayerMask.NameToLayer("Ground"));
    }

    private void Move()
    {        
        currentPosition = new Vector3(currentLane, currentPosition.y, currentPosition.z);
        transform.position = Vector3.MoveTowards(transform.position, currentPosition, stepSpeed * Time.deltaTime);
    }

    public void ChangeLane(int direction)
    {
        if(direction < 0)
        {
            if(currentLane > -laneLimit)
            {
                currentLane += direction; 
            }
        }
        else if (direction > 0)
        {
            if (currentLane < laneLimit)
            {
                currentLane += direction;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        if (sensorGround != null) 
        {
            Gizmos.DrawSphere(sensorGround.position, sensorRadius);
        }       
    }

}
