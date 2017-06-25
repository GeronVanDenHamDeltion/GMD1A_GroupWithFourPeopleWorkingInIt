﻿using System.Collections;
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
        yield return new WaitForEndOfFrame();
        Handheld.PlayFullScreenMovie("FOG EndCredit", Color.black, FullScreenMovieControlMode.CancelOnInput);
        print("test");
    }

}
