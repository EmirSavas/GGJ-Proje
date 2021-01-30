using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class InteractableObjects : MonoBehaviour
{

    #region LampLevel1

    public Light level1LampLight;
    public Material basicGrey;
    public Material level1LampMatLight;
    public MeshRenderer level1Lamp;
    private bool level1LampOpen = false;
    public Light level1LampLight2;
    public AudioSource lampSound;
    public AudioSource lampBuzzSound;
    private bool isClicked = false;

    #endregion


    #region Cigarette

    

    #endregion

    #region TV

    public Light tvLight;
    public MeshRenderer tvMesh;
    public Material tvMatLight;
    private bool tvOpen = false;

    #endregion


    #region Whiskey

    public Light wLight;

    #endregion


    #region Phone

    public MeshRenderer phoneMesh;

    #endregion
    


    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity))
            {
                if (raycastHit.collider.CompareTag("LampLevel1"))
                {
                    if (!level1LampOpen)
                    {
                        level1LampLight.intensity = 5f;
                        level1LampLight2.intensity = 10f;
                        level1Lamp.material = level1LampMatLight;
                        lampSound.Play();
                        lampBuzzSound.PlayDelayed(0.5f);
                        level1LampOpen = true;
                        isClicked = true;
                    }
                    else if(level1LampOpen)
                    {
                        level1LampLight.intensity = 0f;
                        level1LampLight2.intensity = 0f;
                        level1Lamp.material = basicGrey;
                        lampSound.Play();
                        lampBuzzSound.Stop();
                        level1LampOpen = false;
                    }
                    
                }
                
                else if (raycastHit.collider.CompareTag("Cigarette") && isClicked)
                {
                    //Cigarette Audio
                    SceneManager.LoadScene("LivingRoom");
                }
                
                else if (raycastHit.collider.CompareTag("TVController"))
                {

                    if (!tvOpen)
                    {
                        tvMesh.material = tvMatLight;
                        tvLight.intensity = 3f;
                        wLight.intensity = 5f;
                        tvOpen = true;
                        
                    }
                    else if (tvOpen)
                    {
                        tvMesh.material = basicGrey;
                        tvLight.intensity = 0f;
                        wLight.intensity = 0f;
                        tvOpen = false;
                    }
                    
                }
                
                else if (raycastHit.collider.CompareTag("Phone"))
                {
                    //Phone Audio Stop
                    phoneMesh.material = basicGrey;
                }

            }
        }
    }
}
