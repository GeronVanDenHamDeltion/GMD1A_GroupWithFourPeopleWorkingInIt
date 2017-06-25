using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;



public class EndGame : MonoBehaviour
{

    public VideoClip creditsMP4;

    public bool playerispressent;
    public bool partOne;
    public bool partTwo;
    public int amountofruns;
    public GameObject player;
    public CameraEffects effects;
    public float volume;
    public float wait;
    public Animator anim;
    public GameObject npc;
    public VideoPlayer video;
    public GameManager gamemanager;
    public Camera endcamera;
    public GameObject sound;
    public void Awake()
    {
        endcamera.enabled = false;
        gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
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
            if (partTwo == false)
            {
                StartCoroutine(endGamePartTwo());
                partTwo = true;
            }
        }
    }
    public IEnumerator endGamePartTwo()
    {
        print("test end");
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
        npc.SetActive(false);
        yield return new WaitForSeconds(wait);
        npc.SetActive(true);
        yield return new WaitForSeconds(wait);
        npc.SetActive(false);
        yield return new WaitForSeconds(wait);
        npc.SetActive(true);
        yield return new WaitForSeconds(wait);
        npc.SetActive(false);
        if (amountofruns < 7)
        {
            amountofruns++;
            StartCoroutine(endGamePartTwo());
        }
        else
        {
            partOne = false;
            partTwo = false;
            StartCoroutine(endcredits());
        }
    }
    public IEnumerator endcredits()
    {
        sound.SetActive(false);
        player.SetActive(false);
        endcamera.enabled = true;
        effects.staticNoise.volume = 0;
        effects.heartBeat.volume = 0;
        effects.chromaticAberration = 0;
        effects.grain = 0;
        video.Play();
        ResSave ressave = sound.GetComponent<Sounds>().Load();
        video.gameObject.GetComponent<AudioSource>().volume = ressave.volume;
        yield return new WaitForSeconds(110);
        print("gvd ga naar menu dan!");
        gamemanager.sceneNumber = 0;
        StartCoroutine(gamemanager.ChangeScene());
        //effects.ChromaticAberration(0, 0, 0, false);
        //effects.Grain(0, 0, 0, false);
       
    }

}
