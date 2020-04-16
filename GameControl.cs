using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameControl : MonoBehaviour
{
    
    public GameObject Panel;
    public TextMeshProUGUI BallSayisi;
    int Sayi;
    GameObject dENEM;
    PlayerTouch KOD;
   

    void Update()
    {
        Debug.Log(KOD.BalssCollected);
        BallSayisi.text = KOD.BalssCollected.ToString();
        

    }
     void Start()
    {
        dENEM = GameObject.FindGameObjectWithTag("Player");
        KOD = dENEM.GetComponent<PlayerTouch>();
        
        
        
    }
    public void EndGame()
    {
        Debug.Log("Game Over");
        Invoke("PanelGelis", 1f);
        
        
    }
    public void PanelGelis()
    {
        Panel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+0);
    }
    public void MainFonk()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
