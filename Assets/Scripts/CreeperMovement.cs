using UnityEngine;
using UnityEngine.SceneManagement;

public class CreeperMovement : MonoBehaviour
{
    public float speed = 5f;

    [HideInInspector]
    public bool mustPatrol;
    public bool mustTurn;

    public Rigidbody2D rb;
    public Collider2D bodyCollider;
    public LayerMask Stage;
    public LayerMask Enemy;
    public LayerMask Bomb;

    private void Start()
    {
        mustPatrol = true;
    }

    private void Update()
    {
        if (mustPatrol) 
        {
            Patrol();
        }
    }

   
    void Patrol() 
    {
        if (mustTurn || bodyCollider.IsTouchingLayers(Stage) || bodyCollider.IsTouchingLayers(Enemy) || bodyCollider.IsTouchingLayers(Bomb))
        {
            Turn();
        }

        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Turn() 
    {
        mustPatrol=false;
        transform.localScale = new Vector2(transform.localScale.x *-1, transform.localScale.y);
        speed *= -1;
        mustPatrol=true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            DeathSequence();
        }
    }

    private void DeathSequence()
    {
        enabled = false;

        OnDeathSequenceEnded();
    }

    private void OnDeathSequenceEnded()
    {
        ScoreBoard.scoreValue += 100;
        if(ScoreBoard.scoreValue == 500) 
        {
            Invoke(nameof(SceneChange), 3f);
        }
        gameObject.SetActive(false);
    }

    void SceneChange() 
    {
        SceneManager.LoadScene(0);
    }
}
