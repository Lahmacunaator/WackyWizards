using UnityEngine;
using Random = UnityEngine.Random;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private ProjectileDirection direction;
    [SerializeField] private GameObject[] projectiles;
    [SerializeField] private float minCooldown;
    [SerializeField] private float maxCooldown;
    [SerializeField] private float firingSpeed = 5f;

    private Vector2 launchDirection;
    private float cooldown;
    private float timer = 0f;
    
    private void Awake()
    {
        launchDirection = GetDirection();
        SetNextCooldown();
    }

    private void FixToTheEdge()
    {
        var position = GetPositionToPlace();
        transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= cooldown)
        {
            timer = 0;
            var projectile = projectiles[Random.Range(0, projectiles.Length)];
            Fire(projectile);
        }

        timer += Time.deltaTime;
    }

    private void Fire(GameObject projectilePrefab)
    {
        var spawn = Instantiate(projectilePrefab, transform);
        var projectile = spawn.GetComponent<Projectile>();
        projectile.Launch(launchDirection, firingSpeed);
        SetNextCooldown();
    }

    private void SetNextCooldown()
    {
        cooldown = Random.Range(minCooldown, maxCooldown);
    }

    private Vector2 GetDirection()
    {
        return direction switch
        {
            ProjectileDirection.UP => Vector2.up,
            ProjectileDirection.DOWN => Vector2.down,
            ProjectileDirection.LEFT => Vector2.left,
            ProjectileDirection.RIGHT => Vector2.right,
            _ => Vector2.up
        };
    }
    
    private Vector3 GetPositionToPlace()
    {
        return direction switch
        {
            ProjectileDirection.UP => Vector3.down * Screen.height + new Vector3(transform.position.x, 0, transform.position.z),
            ProjectileDirection.DOWN => Vector3.up * Screen.height + new Vector3(transform.position.x, 0, transform.position.z),
            ProjectileDirection.LEFT => Vector3.right * Screen.width + new Vector3(0, transform.position.y, transform.position.z),
            ProjectileDirection.RIGHT =>  Camera.main.ViewportToWorldPoint (new Vector3(0, transform.position.y, 0)) + new Vector3(0,5,0),
            _ => Vector3.up
        };
    }
}

public enum ProjectileDirection
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}
