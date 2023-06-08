using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
   public float bossHealth = 120f;
    public Animator animator;
    public Player player;
    public Missions missions;

    public Text missionCompletedText;
    public GameObject SaveUIgameObject;

    private void Update()
    {
        if(bossHealth <120)
        {
            //animation
            animator.SetBool("Shooting", true);
        }
        if(bossHealth<=0)
        {
            //pass mission
            if (missions.Mission1 == true  && missions.Mission2 == true && missions.Mission3 == true && missions.Mission4 == false)
            {
                StartCoroutine(Mission4UI());
                missionCompletedText.text = "Gonzalves was killed.";
                missions.Mission4 = true;
           
            }
           
            Object.Destroy(gameObject,3.0f);
            
            //animation
            animator.SetBool("Died", true);
            animator.SetBool("Shooting", false);

            gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
    }
    
    public void characterHitDamage(float takeDamage)
    {
        bossHealth -= takeDamage;
    }

    IEnumerator Mission4UI()
    {
        SaveUIgameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        SaveUIgameObject.SetActive(false);
        player.playerMoney += 2000;

    }
}
