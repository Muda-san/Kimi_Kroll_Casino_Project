using UnityEngine;

public class gamemanagerScript : MonoBehaviour
{
    public GameObject winscreen;

    public static gamemanagerScript instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameManager dans la scène");
            return;
        }

        instance = this;
    }


    public void Start()
    {
        BossScript.bossDeafeated = false;
        Coins.Jeton = 0;
    }


    private void Update()
    {
        if(BossScript.bossDeafeated == true)
        {

            Player_controler.instance.PlayerStop();



            winscreen.SetActive(true);
        }
    }

}
