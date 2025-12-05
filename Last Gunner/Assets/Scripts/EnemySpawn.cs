using Unity.Mathematics;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyprefab;

    float time = 0f;

    void Start()
    {
        Instantiate(enemyprefab, transform.position, quaternion.identity);
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time >= 3f)
        {
            Instantiate(enemyprefab, transform.position, quaternion.identity);
            time = 0;
        }
    }
}
