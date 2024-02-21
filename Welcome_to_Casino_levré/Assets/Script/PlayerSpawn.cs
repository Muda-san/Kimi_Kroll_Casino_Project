using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private void Awake()
    {
        //va chercher le player pour l'amener sur les positions de ton spawner
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
    }
}