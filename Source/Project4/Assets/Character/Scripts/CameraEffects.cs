using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing.Utilities;

public class CameraEffects : MonoBehaviour  {

    public Camera playerCamera;
    public PostProcessingController post;
    public GameObject closeEnemy;

    [Header("Public Effects")]
    public float chromaticAberration = 0;
    public float vignette = 0;
    public float dof = 0;
    public float camFOV = 80;
    public float bloom;
    public float grain = 0;

    [Header("Other")]
    public float closestThread;
    public float anxietyRadius;





    void Start()
    {
        post = GetComponent<PostProcessingController>();

        chromaticAberration = post.chromaticAberration.intensity;
        vignette = post.vignette.intensity;
        dof = post.depthOfField.aperture;
        camFOV = GetComponent<Camera>().fieldOfView;
        bloom = post.bloom.bloom.intensity;
        grain = post.grain.intensity;
    }

    void FixedUpdate()
    {
        closestThread = Vector3.Distance(closeEnemy.transform.position, this.gameObject.transform.position);
        if (closestThread <= anxietyRadius)
        {
            Fear();
        }


    }

    public void Fear()
    {
        print("spoopy");
    }

    
}

