using UnityEngine;

public class Enemy : MonoBehaviour
{

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Destory");
        Destroy(this.gameObject);
    }
}
