using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public bool playerispressent;
    public bool partOne;
    public GameObject player;
    public CameraEffects effects;
    public float volume;
    public float wait;
    public Animator anim;
    public GameObject npc;
    public void Awake()
    {
        npc.SetActive(false);
    }
    public void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        playerispressent = true;
    }
    public void Update()
    {
        if (playerispressent == true)
        {
            if (player.transform.rotation.y < 60 && player.transform.rotation.y > -60)
            {
                partOne = true;
            }
        }
        if (partOne == true)
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<BookManager>().enabled = false;
            effects.ChromaticAberration(30, 60, 25, true);
            effects.Grain(0, 90, 50, true);
            effects.staticNoise.volume = volume;
            effects.heartBeat.volume = volume;
            if (player.transform.rotation.y > 150 || player.transform.rotation.y < -100)
            {
                StartCoroutine(endGamePartTwo());
            }
        }
    }
    public IEnumerator endGamePartTwo()
    {
        anim.SetBool("bNPCidle", true);
        yield return new WaitForSeconds(wait);
        npc.SetActive(true);
        yield return new WaitForSeconds(wait);
        npc.SetActive(false);
        yield return new WaitForSeconds(wait);
        npc.SetActive(true);
        yield return new WaitForSeconds(wait);
        npc.SetActive(false);
        yield return new WaitForSeconds(wait);
        npc.SetActive(true);
        yield return new WaitForSeconds(wait);
        npc.SetActive(false);
        yield return new WaitForSeconds(wait);
        npc.SetActive(true);
        yield return new WaitForSeconds(wait);
        npc.SetActive(false);
        yield return new WaitForSeconds(wait);
        npc.SetActive(true);
        yield return new WaitForSeconds(wait);
        npc.SetActive(false);
        yield return new WaitForSeconds(wait);
        npc.SetActive(true);
        yield return new WaitForSeconds(wait);
        npc.SetActive(false);
        yield return new WaitForSeconds(wait);
        npc.SetActive(true);
        yield return new WaitForSeconds(wait);
        npc.SetActive(false);
        yield return new WaitForSeconds(wait);
        npc.SetActive(true);
        yield return new WaitForSeconds(wait);
        npc.SetActive(false);
        yield return new WaitForSeconds(wait);
        npc.SetActive(true);
        yield return new WaitForSeconds(wait);
        yield return new WaitForSeconds(wait);
        npc.SetActive(true);
        yield return new WaitForSeconds(wait);
        npc.SetActive(false);
        yield return new WaitForSeconds(wait);
        npc.SetActive(true);
        yield return new WaitForSeconds(wait);
        npc.SetActive(false);
        npc.SetActive(false);
    }

}
