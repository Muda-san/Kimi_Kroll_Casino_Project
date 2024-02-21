using UnityEngine;

public class gamemanagerScript : MonoBehaviour
{
    public GameObject winscreen;

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
