using UnityEngine;

public class Gangster1 : MonoBehaviour
{
    [Header("Character Info")]
    public float movingSpeed;
    public float runningSpeed;
    private float CurrentmovingSpeed;
    public float turningSpeed = 300f;
    public float stopSpeed = 1f;
    private float characterHealth = 100f;
    public float presentHealth;

    [Header("Destination Var")]
    public Vector3 destination;
    public bool destinationReached;
    public Animator animator;


    [Header("Gangster AI")]
    public GameObject playerBody;
    public LayerMask PlayerLayer;
    public float visionRadius;
    public float shootingRadious;
    public bool playerInvisionRadius;
    public bool playerInshootingRadious;

    [Header("Gangster Shooting Var")]
    public float giveDamageOf = 3f;
    public float shootingRange = 100f;
    public GameObject ShootingRaycastArea;
    public float timebtwShoot;
    bool previouslyShoot;
    public Player player;
    public GameObject bloodEffect;


    private void Start()
    {
        CurrentmovingSpeed = movingSpeed;
        presentHealth = characterHealth;
        playerBody = GameObject.Find("Player");
        player = GameObject.FindObjectOfType<Player>();
        GameObject.Find("Player");
    }
    private void Update()
    {
        playerInvisionRadius = Physics.CheckSphere(transform.position, visionRadius, PlayerLayer);
        playerInshootingRadious = Physics.CheckSphere(transform.position, shootingRadious, PlayerLayer);

        if (!playerInvisionRadius && !playerInshootingRadious )
        {
            Walk();
        }
        if (playerInvisionRadius && !playerInshootingRadious )
        {
            ChasePlayer();
        }
        if (playerInvisionRadius && playerInshootingRadious )
        {
            ShootPlayer();
        }
    }

    public void Walk()
    {
        if (transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;
            float destinationDistance = destinationDirection.magnitude;

            if (destinationDistance >= stopSpeed)
            {

                //Turning
                destinationReached = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turningSpeed * Time.deltaTime);

                //Move AI
                transform.Translate(Vector3.forward * CurrentmovingSpeed * Time.deltaTime);

                animator.SetBool("Walk", true);
                animator.SetBool("Shoot", false);
                animator.SetBool("Run", false);
            }
            else
            {
                destinationReached = true;

            }
        }
    }
    public void LocalDestination(Vector3 destination)
    {
        this.destination = destination;
        destinationReached = false;
    }
    public void ChasePlayer()
    {
        transform.position += transform.forward * CurrentmovingSpeed * Time.deltaTime;
        transform.LookAt(playerBody.transform);

        animator.SetBool("Run", true);
        animator.SetBool("Walk", false);
        animator.SetBool("Shoot", false);

        CurrentmovingSpeed = runningSpeed;
    }

    public void ShootPlayer()
    {
        CurrentmovingSpeed = 0f;
        transform.LookAt(playerBody.transform);

        animator.SetBool("Run", false);
        animator.SetBool("Walk", false);
        animator.SetBool("Shoot", true);


        if (!previouslyShoot)
        {
            RaycastHit hit;
            if (Physics.Raycast(ShootingRaycastArea.transform.position, ShootingRaycastArea.transform.forward, out hit, shootingRange))
            {
                Debug.Log("Shooting" + hit.transform.name);

                PlayerScript playerBody = hit.transform.GetComponent<PlayerScript>();

                if (playerBody != null)
                {

                    playerBody.playerHitDamage(giveDamageOf);
                    GameObject bloodEffectGo = Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(bloodEffectGo, 1f);
                }
            }
            previouslyShoot = true;
            Invoke(nameof(ActiveShooting), timebtwShoot);
        }
    }

    private void ActiveShooting()
    {
        previouslyShoot = false;
    }
    public void characterHitDamage(float takeDamage)
    {
        presentHealth -= takeDamage;

        if (presentHealth <= 0)
        {
            animator.SetBool("Die", true);
            characterDie();
        }
    }
    private void characterDie()
    {
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        CurrentmovingSpeed = 0f;
        shootingRange = 0f;
        Object.Destroy(gameObject, 4.0f);
        player.currentkills += 1;
        player.playerMoney += 10;
    }
}