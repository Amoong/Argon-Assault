using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hitPoint = 3;
    [SerializeField] GameObject hitVFX;
    [SerializeField] GameObject deathVFX;
    [SerializeField] int scorePerHit = 15;

    GameObject parentGameObject;
    ScoreBoard scoreBoard;
    int originHealth = 1;

    void Start()
    {
        // 객체들 중 하나를 찾아서 반환
        // 리소스가 많이 드는 작업
        // Update 메소드에선 사용 X
        scoreBoard = FindObjectOfType<ScoreBoard>();

        originHealth = hitPoint;

        AddRigidbody();
        SetParent();
    }

    void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void SetParent()
    {
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        scoreBoard.IncreaseScore(scorePerHit);

        float healthPercent = (float)hitPoint / originHealth;

        Material material = GetComponent<MeshRenderer>().material;
        material.color = new Color(1, healthPercent, healthPercent);

        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;

        if (--hitPoint < 1)
        {
            KillEnemy();
        }
    }
    void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }


}
