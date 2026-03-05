using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float stepSpeed;
    [SerializeField] private float currentLane = 0;
    [SerializeField] private float laneLimit = 1;

    [Header("Controller Settings")]
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private Vector3 movement;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float jumpHeight = 2.0f;


    private Vector3 currentPosition;
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        currentPosition = transform.position;
    }


    private void Update()
    {
        // MOVE ENTRE AS PISTAS
        //currentPosition = new Vector3(currentLane, currentPosition.y, currentPosition.z); 
        //transform.position = Vector3.MoveTowards(transform.position, currentPosition, stepSpeed * Time.deltaTime);

        // VERIFICA SE ESTA NO CHÃO
        isGrounded = characterController.isGrounded;

        // PULO
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            movement.y += jumpHeight;
        }
        else
        {
            // GRAVIDADE
            movement.y += gravity * Time.deltaTime;
        }

        // ATUALIZAÇÃO DO CHARACTER CONTROLLER
        characterController.Move(movement * Time.deltaTime);

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
}
