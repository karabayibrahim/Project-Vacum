using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerTouch : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject cameraObject;
    GameObject Trigger;
    ToNextStage Trigcode;
    CameraMovementScript camCode;
    public GameObject explosionEffect; 
    GameObject StateCheck;
    Vector3 Degerler;
    public GameObject Hızlanmaİmage;
    public GameObject BuyumeImage;
    public GameObject BombImage;
    public GameObject YavaslamaImage;
    public GameObject ChestImage;
    public GameObject KuculmeImage;
    public GameObject SuperCekımImage;
    public bool VakumAktifmi = false;
    public GameObject VakumEffecktPar;
    public GameObject YavaslamaPar;
    
    //public GameObject ToplamaPoint;
    //public GameObject Toplanan;
    








    public GameObject AnaKarakter;
    PlayerMovement MoveCode;
    public int health = 3;
    Pull pullcode;
    PullSuper pullCodeSuper;
    GameObject StateCheckSuper;
    SphereCollider SuperVakum;
    float saniye = 10;
    public int BalssCollected = 0;//Topladığımız sayisi
    
    int DusenBallSayisi;
    public GameObject DownPoint;
    public GameObject Ball;
    int  rndsecim;
    public bool HizlanmaKontrol = false;
   
    
    

    private void Update()
    {
        #region DurumKontroller
        if (rndsecim==1)
        {
            SizeUp();
            saniye -= Time.deltaTime;
            if (saniye <= 0)
            {
                SizeNaturel();
                saniye = 10;
                rndsecim = 0;
            }
            
        }
        if (rndsecim==2)
        {
            SizeDown();
            
            saniye -= Time.deltaTime;
            if (saniye <= 0)
            {
                SizeNaturel();
                saniye = 10;
                rndsecim = 0;
            }
            
        }
        if (rndsecim == 3 )
        {
            
            SpeedUp();
            saniye -= Time.deltaTime;
            if (saniye <= 0)
            {

                SpeedNaturel();
                saniye = 10;
                rndsecim = 0;
            }

        }
        if (rndsecim==4)
        {
            SpeedDown();
            saniye -= Time.deltaTime;
            if (saniye <= 0)
            {
                SpeedNaturel();
                saniye = 10;
                rndsecim = 0;
            }
        }
        if (rndsecim==5)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            CameraShaker.Instance.ShakeOnce(50f, 5f, .1f, 1f);
            Debug.Log("BOOM");
            
            gameObject.SetActive(false);
            MoveCode.AutomaticMoveSpeed = 0;
            Destroy(GameObject.Find("patlamaParticule(Clone)"), 1f);
            FindObjectOfType<GameControl>().EndGame();
            
            BombImage.SetActive(true);
            Destroy(BombImage, 1f);

            
            
        }
        if (rndsecim==6)
        {
            SuperVacum();
            saniye -= Time.deltaTime;
            if (saniye <= 0)
            {
                VacumNaturel();
                saniye = 10;
                rndsecim = 0;
            }
        }

        #endregion

        if (MoveCode.AutomaticMoveSpeed==4)
        {
            Hızlanmaİmage.SetActive(false);
        }
    }
     void Start()
    {
        //SizeUpObject = GameObject.FindGameObjectWithTag("Black");

        //rndCode = SizeUpObject.GetComponent<Rnd>();
        StateCheck = GameObject.Find("Cekim");
        Degerler = AnaKarakter.transform.localScale;
        pullcode = StateCheck.GetComponent<Pull>();
        StateCheckSuper = GameObject.FindGameObjectWithTag("CekimSuper");
        pullCodeSuper = StateCheckSuper.GetComponent<PullSuper>();
        
        AnaKarakter = GameObject.FindGameObjectWithTag("Player");
        MoveCode = AnaKarakter.GetComponent<PlayerMovement>();
        cameraObject = GameObject.Find("MainCamera");
        Trigger = GameObject.FindGameObjectWithTag("FastTrigger");
        Trigcode =Trigger.GetComponent<ToNextStage>();
        pullCodeSuper.enabled = false;
        //Ball = GameObject.FindGameObjectWithTag("Balls");
        //camCode = cameraObject.GetComponent<CameraMovementScript>();
    }
    #region Carpısma Durumlari
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Balls") && pullcode.PullCheck == true)//Pull check cekim aktifmi kontroludür.
        {
            if(other.gameObject != null)
            {
                BalssCollected++;
                //GameObject yenitoplanan = Instantiate(Toplanan, ToplamaPoint.transform.position, Quaternion.identity);
                
                Debug.Log(BalssCollected);
                other.gameObject.SetActive(false);
                
                
            }
            
            //Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Balls") && pullCodeSuper.PullCheckSuper == true)//Pull check cekim aktifmi kontroludür.
        {
            if (other.gameObject != null)
            {
                
                Debug.Log(BalssCollected);
                other.gameObject.SetActive(false);


            }

            //Destroy(other.gameObject);
        }
        

        else  if (other.gameObject.CompareTag("Bomb") && pullcode.PullCheck == true)
        {
            if (other.gameObject != null)
            {
                Instantiate(explosionEffect, transform.position, transform.rotation);
                CameraShaker.Instance.ShakeOnce(50f, 5f, .1f, 1f);
                Debug.Log("BOOM");
                other.gameObject.SetActive(false);
                // gameObject.SetActive(false);
                
                MoveCode.AutomaticMoveSpeed = 0;
                Destroy(GameObject.Find("patlamaParticule(Clone)"),1f);
                FindObjectOfType<GameControl>().EndGame();//Game Over
                BombImage.SetActive(false);
                Destroy(gameObject);
            }

            //Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Black") && pullcode.PullCheck == true)
        {
            
            if (other.gameObject != null)
            {
                
               
                rndsecim = Random.Range(4, 4);
                Debug.Log(rndsecim);

                
                other.gameObject.SetActive(false);
            }

            //Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Balls")&&pullcode.PullCheck==false)//Çekimsiz çarpışma durumlarını kontrol ediyoruz.
        {
            DusenBallSayisi = BalssCollected / 5;
            BalssCollected -= BalssCollected / 5;
            
           
            Debug.Log("dUSEN"+DusenBallSayisi);
            Debug.Log(BalssCollected);

            CameraShaker.Instance.ShakeOnce(4f,2f,.1f,1f);

            Topdusurme();
            



        }
        DusenBallSayisi = 0;
        if (other.gameObject.CompareTag("Engel"))
        {
            FindObjectOfType<GameControl>().EndGame();
            Destroy(gameObject);
        }

    }
    #endregion
    #region Durumlar
    public void SizeUp()
    {
        BuyumeImage.SetActive(true);
        AnaKarakter.transform.localScale = Degerler * 2;
       // AnaKarakter.transform.position = new Vector3(AnaKarakter.transform.position.x, 1, AnaKarakter.transform.position.z);
        

    }
    public void SizeNaturel()
    {
        BuyumeImage.SetActive(false);
        KuculmeImage.SetActive(false);
        AnaKarakter.transform.localScale = Degerler;
       // AnaKarakter.transform.position = new Vector3(AnaKarakter.transform.position.x, 0.5f, AnaKarakter.transform.position.z);
    }
    public void SizeDown()
    {
        KuculmeImage.SetActive(true);
        AnaKarakter.transform.localScale = Degerler / 2;
       // AnaKarakter.transform.position = new Vector3(AnaKarakter.transform.position.x, 0.25f, AnaKarakter.transform.position.z);
    }
    public void SpeedUp()
    {
        HizlanmaKontrol = true;
        Hızlanmaİmage.SetActive(true);
        if ( !Trigcode.kontrol)
        {
            MoveCode.AutomaticMoveSpeed = 8f;
        }
        //else
        //{
        //    Hızlanmaİmage.SetActive(false);
        //}


    }
    public void SpeedDown()
    {
        HizlanmaKontrol = false;
        YavaslamaImage.SetActive(true);
        YavaslamaPar.SetActive(true);
        
        if (!Trigcode.kontrol)
        {
            MoveCode.AutomaticMoveSpeed = 2f;
        }
        
    }
    public void SpeedNaturel()
    {
        Hızlanmaİmage.SetActive(false);
        YavaslamaImage.SetActive(false);
        YavaslamaPar.SetActive(false);
        MoveCode.AutomaticMoveSpeed = 4f;
    }
    public void SuperVacum()
    {

        SuperCekımImage.SetActive(true);
        VakumEffecktPar.SetActive(true);
        StateCheck.SetActive(false);
        pullCodeSuper.enabled = true;



        //VakumAktifmi = true;

    }
    public void VacumNaturel()
    {
        SuperCekımImage.SetActive(false);
        StateCheck.SetActive(true);
        pullCodeSuper.enabled = false;
        VakumEffecktPar.SetActive(false);
    }
    #endregion
    #region Down
    public void Topdusurme()
    {
        if (BalssCollected != 0 && DusenBallSayisi!=0)
        {
            for (int i = 1; i <= DusenBallSayisi; i++)
            {
                GameObject dusen = Instantiate(Ball, DownPoint.transform.position, Quaternion.identity);
                Destroy(dusen, 2f);
                
            }
            
        }
        





    }
    #endregion 
    
    

}
