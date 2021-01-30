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
    private bool isPhoneClosed = false;

    #endregion

    #region WashingMachine

    public bool wMachineClicked = false;

    #endregion

    #region Mirror

    

    #endregion

    #region Ashpit

    public bool ashClicked = false;

    #endregion

    #region Pizza

    private bool isPizzaClicked = false;

    #endregion

    #region Glass

    

    #endregion

    #region Aspirator

    private bool isAsOpen = false;
    public Light asLight;

    #endregion

    #region Shower

    private bool showerClicked = false;

    #endregion

    #region Tabela

    private bool tabelaClicked = false;

    #endregion

    #region Çöp

    

    #endregion

    #region Jukebox

    private bool jboxClicked = false;
    public Light barBottleLight;

    #endregion

    #region Bed

    

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
                    SceneManager.LoadScene("OkyanusKitchen");
                }
                
                else if (raycastHit.collider.CompareTag("Ashpit"))
                {
                    ashClicked = true;
                }
                
                else if (raycastHit.collider.CompareTag("Aspirator"))
                {
                    if (isAsOpen)
                    {
                        asLight.intensity = 0f;
                        isAsOpen = false;
                    }
                    else
                    {
                        asLight.intensity = 0.8f;
                        isAsOpen = true;
                    }
                }
                
                else if (raycastHit.collider.CompareTag("Pizza") && ashClicked)
                {
                    isPizzaClicked = true;
                }
                
                else if (raycastHit.collider.CompareTag("Glass") && isPizzaClicked)
                {
                    //Phone Ring
                    SceneManager.LoadScene("OkyanusLivingRoom");
                }
                
                else if (raycastHit.collider.CompareTag("TVController") && isPhoneClosed)
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
                    }
                    
                }
                
                else if (raycastHit.collider.CompareTag("Phone"))
                {
                    //Phone Audio Stop
                    phoneMesh.material = basicGrey;
                    isPhoneClosed = true;
                }
                
                else if (raycastHit.collider.CompareTag("Whiskey") && tvOpen && isPhoneClosed)
                {
                    //Whiskey Drink Sound
                    SceneManager.LoadScene("OkyanusBathroom");
                }
                
                else if (raycastHit.collider.CompareTag("Shower"))
                {
                    //Sound
                    showerClicked = true;
                }
                
                else if (raycastHit.collider.CompareTag("WashingMachine") && showerClicked)
                {
                    //Sound
                    wMachineClicked = true;
                }
                
                else if (raycastHit.collider.CompareTag("Mirror") && wMachineClicked)
                {
                    //Sound
                    SceneManager.LoadScene("Street1");
                }
                
                else if (raycastHit.collider.CompareTag("Tabela"))
                {
                    //Sound
                    tabelaClicked = true;
                }
                
                else if (raycastHit.collider.CompareTag("Cop") && tabelaClicked)
                {
                    //Sound
                    SceneManager.LoadScene("Bar1");
                }
                
                else if (raycastHit.collider.CompareTag("Jukebox"))
                {
                    //Sound
                    barBottleLight.intensity = 3f;
                    jboxClicked = true;
                }
                
                else if (raycastHit.collider.CompareTag("Bottle") && jboxClicked)
                {
                    //Sound
                    SceneManager.LoadScene("BarToilet");
                }
                
                else if (raycastHit.collider.CompareTag("BarMirror"))
                {
                    //Sound
                    SceneManager.LoadScene("StrangersHouse1");
                }
                
                else if (raycastHit.collider.CompareTag("Bed"))
                {
                    //Sound
                    SceneManager.LoadScene("StrangersHouse2");
                }
                
                else if (raycastHit.collider.CompareTag("BalconyDoor"))
                {
                    //Sound
                    SceneManager.LoadScene("StrangersBalkon");
                }

            }
        }
    }
}
