using UnityEngine;
using UnityEngine.SceneManagement;

public class EnesWeapon : MonoBehaviour
{
    private Transform aimTransform;
    public Transform firePoint; 

    public GameObject bulletPrefabLevel1;
    public GameObject bulletPrefabLevel2;
    public GameObject bulletPrefabLevel3;
    public int damage = 1; 
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    private const int pointGoal = 3;
    public int cuPoints = 0;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                Instantiate(bulletPrefabLevel1, firePoint.position, firePoint.rotation);
            }
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                Instantiate(bulletPrefabLevel2, firePoint.position, firePoint.rotation);
                damage = 2;

            }
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                Instantiate(bulletPrefabLevel3, firePoint.position, firePoint.rotation);
                damage = 3;
            }
        }
        HandleAiming();
    }

    private void HandleAiming()
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen) - 180f;

        //Ta Daaa
        aimTransform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
