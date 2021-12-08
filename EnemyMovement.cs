using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float dirX;
    private float moveSpeed;
    private Rigidbody2D rb;

    Scene cScene;
    string CurrentScene;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        dirX = 1f;
        moveSpeed = 3f;

        cScene = SceneManager.GetActiveScene();
        CurrentScene = cScene.name;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            dirX *= -1f;

            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(CurrentScene);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }
}
