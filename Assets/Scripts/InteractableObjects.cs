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
    public AudioSource charCigar;

    #endregion
    
    #region Cigarette

    public AudioSource cigarSound;
    private bool delayCigarBool = false;

    #endregion

    #region TV

    public Light tvLight;
    public MeshRenderer tvMesh;
    public Material tvMatLight;
    private bool tvOpen = false;
    public AudioSource kumanda;
    public AudioSource tvSound;

    #endregion
    
    #region Whiskey

    public Light wLight;
    public AudioSource siseSound;
    public bool delayWhiskeyBool = false;
    public AudioSource buIyi;
    private bool delayWhiskeyStart = false;
    private float delayWhiskeyTimer = 0f;

    #endregion
    
    #region Phone

    public MeshRenderer phoneMesh;
    private bool isPhoneClosed = false;
    public AudioSource ugrasamam;
    public AudioSource phoneRing2;
    public AudioSource whiskeyChar;

    #endregion

    #region WashingMachine

    public bool wMachineClicked = false;
    public AudioSource camasir;

    #endregion

    #region Mirror

    public AudioSource harika;
    private float MirrorTimer = 0f;
    private bool MirrorTimerStart = false;
    private bool mirrorDelay = false;

    #endregion

    #region Ashpit

    public bool ashClicked = false;

    #endregion

    #region Pizza

    private bool isPizzaClicked = false;
    public AudioSource pizzaBox;
    public AudioSource phoneRing1;
    public AudioSource charKimBu;

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
    public AudioSource otobus;

    #endregion

    #region Çöp

    public AudioSource _throw;
    public AudioSource birSise;
    private float copTimer = 0f;
    private bool copStart = false;
    private bool cop = false;

    #endregion

    #region Jukebox

    private bool jboxClicked = false;
    public Light barBottleLight;

    #endregion

    #region Bed

    

    #endregion

    
    public bool delayCigarStart = false;
    public float delay = 0f;

    void Update()
    {
        #region Raycast
        
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
                        charCigar.PlayDelayed(1f);
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
                    cigarSound.Play();
                    delayCigarStart = true;
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
                    pizzaBox.Play();
                    phoneRing1.PlayDelayed(1f);
                    charKimBu.PlayDelayed(2.5f);
                }
                
                else if (raycastHit.collider.CompareTag("Glass") && isPizzaClicked)
                {
                    //Phone Ring
                    SceneManager.LoadScene("OkyanusLivingRoom");
                }
                
                else if (raycastHit.collider.CompareTag("TVController") && isPhoneClosed)
                {
                    
                    kumanda.Play();

                    if (!tvOpen)
                    {
                        tvMesh.material = tvMatLight;
                        tvLight.intensity = 3f;
                        wLight.intensity = 5f;
                        tvOpen = true;
                        tvSound.PlayDelayed(0.1f);
                        
                    }
                    
                    else if (tvOpen)
                    {
                        tvMesh.material = basicGrey;
                        tvLight.intensity = 0f;
                        wLight.intensity = 0f;
                        tvOpen = false;
                        tvSound.Stop();
                    }
                    
                }
                
                else if (raycastHit.collider.CompareTag("Phone"))
                {
                    phoneMesh.material = basicGrey;
                    isPhoneClosed = true;
                    ugrasamam.Play();
                    phoneRing2.Stop();
                    whiskeyChar.PlayDelayed(5f);
                }
                
                else if (raycastHit.collider.CompareTag("Whiskey") && tvOpen && isPhoneClosed)
                {
                    siseSound.Play();
                    buIyi.PlayDelayed(0.5f);
                    delayWhiskeyStart = true;
                }
                
                else if (raycastHit.collider.CompareTag("Shower"))
                {
                    //Sound
                    showerClicked = true;
                }
                
                else if (raycastHit.collider.CompareTag("WashingMachine") && showerClicked)
                {
                    wMachineClicked = true;
                    camasir.Play();
                }
                
                else if (raycastHit.collider.CompareTag("Mirror") && wMachineClicked)
                {
                    harika.Play();
                    MirrorTimerStart = true;
                }
                
                else if (raycastHit.collider.CompareTag("Tabela"))
                {
                    otobus.Play();
                    tabelaClicked = true;
                }
                
                else if (raycastHit.collider.CompareTag("Cop") && tabelaClicked)
                {
                    _throw.Play();
                    birSise.PlayDelayed(0.5f);
                    copStart = true;
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

        

        

        #endregion

        if (delayWhiskeyBool)
        {
            SceneManager.LoadScene("OkyanusBathroom");
            delayWhiskeyBool = false;
            delayWhiskeyStart = false;
        }
        
        if (delayCigarBool)
        {
            SceneManager.LoadScene("OkyanusKitchen");
            delayCigarBool = false;
            delayCigarStart = false;
        }
        
        if (mirrorDelay)
        {
            SceneManager.LoadScene("Street1");
            mirrorDelay = false;
            MirrorTimerStart = false;
        }
        
        if (cop)
        {
            SceneManager.LoadScene("Bar1");
            cop = false;
            copStart = false;
        }

        if (delayCigarStart)
        {
            delay += Time.deltaTime;

            if (delay >= 5f)
            {
                delayCigarBool = true;
                delay = 0f;
            }
        }
        
        if (delayWhiskeyStart)
        {
            delayWhiskeyTimer += Time.deltaTime;

            if (delayWhiskeyTimer >= 5f)
            {
                delayWhiskeyBool = true;
                delayWhiskeyTimer = 0f;
            }
        }
        
        if (MirrorTimerStart)
        {
            MirrorTimer += Time.deltaTime;

            if (MirrorTimer >= 5f)
            {
                mirrorDelay = true;
                MirrorTimer = 0f;
            }
        }
        
        if (copStart)
        {
            copTimer += Time.deltaTime;

            if (copTimer >= 5f)
            {
                cop = true;
                copTimer = 0f;
            }
        }
        
        
        
    }

}
