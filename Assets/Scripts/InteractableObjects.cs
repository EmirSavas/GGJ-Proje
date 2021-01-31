using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InteractableObjects : MonoBehaviour
{

    public TextMeshProUGUI Text;
    
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
    public bool Cigarette;

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
    public AudioSource oksuruk;

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
    
    public AudioSource jBoxMusic;
    public AudioSource WhiskeyOrder;
    public AudioSource BottleSound;
    
    private bool delayWhiskeyOrder = false;
    private float delayWhiskeyOrdTimer =0f;
    private bool delayWhiskeyOrderBool = false;
    

    #endregion
    
    #region BarMirror

    public AudioSource RutinAudio;
    
    private bool LeaveFromBar = false;
    private float LeaveFromBarTimer =0f;
    private bool LeaveFromBarBool = false;

    #endregion

    #region Bed

    public AudioSource bedvoices;
    
    private bool Münasebet = false;
    private float MünasebetTimer = 0f;
    private bool MünasebetBool = false;
    

    #endregion

    #region Delay

    private bool delayCigarStart = false;
    private float delay = 0f;

    #endregion

    #region Cigar2

    public AudioSource cigarSound2;
    private bool cigar2 = false;

    #endregion


    public bool fadeOutBlack;
    public int fadeSpeed = 5;
    public GameObject fadeOutImage;
    
    private float Delay;
    public Animator panel;

    private void Start()
    {
        panel = GetComponent<Animator>();
        panel.Play("PopUp");
    }

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
                    
                    Text.text = "Where did I put my cigarettes?";
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
                    
                    Cigarette = true;
                    cigarSound.Play();
                    delayCigarStart = true;
                    
                }
                
                else if (raycastHit.collider.CompareTag("Ashpit"))
                {
                    //Bakcam
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
                    Text.text = "The perfect pizza to turn my stomach to a dump.";
                    isPizzaClicked = true;
                    pizzaBox.Play();
                    oksuruk.PlayDelayed(1.5f);
                    phoneRing1.PlayDelayed(8f);
                    charKimBu.PlayDelayed(9.5f);
                    //Olmadı
                    if (charKimBu.isPlaying)
                    {
                        Delay += Time.deltaTime;

                        if (Delay >= 9.5f)
                        {
                            Text.text = "Who is this now?";
                            Delay = 0f;
                        }
                    }
                    
                }
                
                else if (raycastHit.collider.CompareTag("Glass") && isPizzaClicked)
                {
                    //Phone Ring
                    SceneManager.LoadScene("OkyanusLivingRoom");
                    Text.text ="Phone... phone...";
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
                    Text.text ="I can’t deal with you right now at all.";
                    phoneRing2.Stop();
                    whiskeyChar.PlayDelayed(5f);
                    
                    if (whiskeyChar.isPlaying)
                    {
                        Delay += Time.deltaTime;

                        if (Delay >= 5f)
                        {
                            Text.text = "I can only get rid of this disgusting taste of pizza with whiskey.";
                            Delay = 0f;
                        }
                    }
                }
                
                else if (raycastHit.collider.CompareTag("Whiskey") && tvOpen && isPhoneClosed)
                {
                    Text.text = "Oh... That was good.";
                    siseSound.Play();
                    buIyi.PlayDelayed(0.5f);
                    delayWhiskeyStart = true;
                }
                
                else if (raycastHit.collider.CompareTag("Shower"))
                {
                    //Geçiş Cümlesi
                    //Text.text = "Scrubbing these stained feelings sheds a false light on my calloused heart.";
                    //Sound
                    showerClicked = true;
                }
                
                else if (raycastHit.collider.CompareTag("WashingMachine") && showerClicked)
                {
                    Text.text = "I forgot to empty the laundry again... Perfect.";
                    wMachineClicked = true;
                    camasir.Play();
                }
                
                else if (raycastHit.collider.CompareTag("Mirror") && wMachineClicked)
                {
                    Text.text = "I look absolutely great, really.";
                    harika.Play();
                    MirrorTimerStart = true;
                }
                
                else if (raycastHit.collider.CompareTag("Tabela"))
                {
                    Text.text = "For once, I wish a bus that arrives on time. Whatever...";
                    otobus.Play();
                    tabelaClicked = true;
                }
                
                else if (raycastHit.collider.CompareTag("Cop") && tabelaClicked)
                {
                    _throw.Play();
                    birSise.PlayDelayed(0.5f);
                    Text.text = "Another bottle finished, good.";
                    copStart = true;
                }
                
                else if (raycastHit.collider.CompareTag("Jukebox"))
                {
                    jBoxMusic.PlayDelayed(0.5f);
                    barBottleLight.intensity = 3f;
                    jboxClicked = true;
                }
                
                else if (raycastHit.collider.CompareTag("Bottle") && jboxClicked)
                {
                    WhiskeyOrder.PlayDelayed(1f);
                    Text.text = "Double whiskey, no ice.";
                    BottleSound.PlayDelayed(3f);
                    delayWhiskeyOrder = true;
                    //Delay Koymak Lazım. -Hazan
                    //SceneManager.LoadScene("BarToilet");
                    //delayWhiskeyOrder = true;
                }
                
                else if (raycastHit.collider.CompareTag("BarMirror"))
                {
                    RutinAudio.Play();
                    Text.text = "Are we suprised that Okyanus ended another night like this. Of course not. *Sigh* Me and my routines...";
                    LeaveFromBar = true;
                    //SceneManager.LoadScene("StrangersHouse1");
                }
                
                else if (raycastHit.collider.CompareTag("Bed"))
                {
                    bedvoices.Play();
                    Münasebet = true;
                }
                
                else if (raycastHit.collider.CompareTag("Cigarette2"))
                {
                    cigarSound.Play();
                    cigar2 = true;
                }
                
                else if (raycastHit.collider.CompareTag("BalconyDoor") && cigar2)
                {
                    SceneManager.LoadScene("BlankScene8");
                }

            }
        }

        

        

        #endregion

        if (delayWhiskeyBool)
        {
            SceneManager.LoadScene("OkyanusBathroom");
            panel.Play("PopUp");
            delayWhiskeyBool = false;
            delayWhiskeyStart = false;
        }
        
        if (delayCigarBool)
        {
            SceneManager.LoadScene("OkyanusKitchen");
            panel.Play("PopUp");
            delayCigarBool = false;
            delayCigarStart = false;
            //Text.text = "Ahh… this is why I like the first cigarette of the day.";
        }

        if (mirrorDelay)
        {
            SceneManager.LoadScene("Street1");
            panel.Play("PopUp");
            mirrorDelay = false;
            MirrorTimerStart = false;
        }
        
        if (cop)
        {
            SceneManager.LoadScene("Bar1");
            panel.Play("PopUp");
            cop = false;
            copStart = false;
        }

        if (MünasebetBool)
        {
            SceneManager.LoadScene("StrangersHouse2");
            Münasebet = false;
            MünasebetBool = false;
        }

        if (delayWhiskeyOrderBool)
        {
            SceneManager.LoadScene("BarToilet");
            panel.Play("PopUp");
            delayWhiskeyOrderBool = false;
            delayWhiskeyOrder = false;
        }
        
        if (LeaveFromBarBool)
        {
            SceneManager.LoadScene("BlankScene7");
            LeaveFromBarBool = false;
            LeaveFromBar = false;
        }
        
        if (Münasebet)
        {
            MünasebetTimer += Time.deltaTime;

            if (MünasebetTimer >= 5f)
            {
                MünasebetBool = true;
                MünasebetTimer = 0f;
            }
        }
        
        if (LeaveFromBar)
        {
            LeaveFromBarTimer += Time.deltaTime;

            if (LeaveFromBarTimer >= 10f)
            {
                LeaveFromBarBool = true;
                LeaveFromBarTimer = 0f;
            }
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
        
        if (delayWhiskeyOrder)
        {
            delayWhiskeyOrdTimer += Time.deltaTime;

            if (delayWhiskeyOrdTimer >= 5f)
            {
                delayWhiskeyOrderBool = true;
                delayWhiskeyOrdTimer = 0f;
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
