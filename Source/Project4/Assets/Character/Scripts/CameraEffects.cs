using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing.Utilities;

public class CameraEffects : MonoBehaviour  {

    
    public PostProcessingController post;
    public GameObject closeEnemy;

    [Header("Public Effects")]
    public float chromaticAberration = 0;
    public float vignette;
    public float dof = 0;
    public float camFOV = 80;
    public float bloom;
    public float grain = 0;
    public bool wakenUp;
    

    [Header("Other")]
    public float closestThread;
    public float anxietyRadius;





    void Start()
    {
        post = GetComponent<PostProcessingController>();
        
        


    }

    void FixedUpdate()
    {
        post.chromaticAberration.intensity = chromaticAberration;
        post.vignette.intensity = vignette;
        post.depthOfField.aperture = dof;
        GetComponent<Camera>().fieldOfView = camFOV;
        post.bloom.bloom.intensity = bloom;
        post.grain.intensity = grain;


        if (closeEnemy != null)
        {
            closestThread = Vector3.Distance(closeEnemy.transform.position, this.gameObject.transform.position);

            if (closestThread <= anxietyRadius)
            {
                ChromaticAberration(0, 20, 15, true);
                Grain(0, 1, 3, true);

            }
            else
            {
                ChromaticAberration(chromaticAberration, 0, 5, false);
                Grain(grain, 0, 5, false);
            }

        }

        
        

    }

    public void ChromaticAberration(float start, float target, float speed, bool repeat)
    {
        if(repeat)
        {
            chromaticAberration = Mathf.PingPong(speed * Time.time, target);
        }
        else
        {
            chromaticAberration = Mathf.Lerp(start, target, Time.deltaTime * speed);
        }             
    }

    public void Vignette(float start, float target, float speed, bool repeat)
    {
        if (repeat)
        {
            vignette = Mathf.PingPong(speed * Time.time, target);
        }
        else
        {
            vignette = Mathf.Lerp(start, target, Time.time * speed * 0.1f);
        }
    }

    public void Grain(float start, float target, float speed, bool repeat)
    {
        if (repeat)
        {
            grain = Mathf.PingPong(speed * Time.time, target);
        }
        else
        {
            grain = Mathf.Lerp(start, target, Time.time * speed *0.1f);
        }
    }

    void Update()
    {
        
        if(wakenUp == false)
        {
            print("waking up");
            Vignette(1, 0.4f, 5, false);

        }
        if (vignette <= 0.4f)
        {
            print("woken");
            wakenUp = true;
        }
    }

    

    
}

