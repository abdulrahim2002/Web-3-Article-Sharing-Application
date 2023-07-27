using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thirdweb;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject articleListing;

    // game state variable keeps track of the state of the game,
    // 0 means startscreen, 1 means article listing, 2 means article opened
    public static int    gameState;
    public static string userAddress;

    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    public GameObject article1;
    public GameObject article2;
    public GameObject article3;

    public GameObject wallet;
    
    
    // Start is called before the first frame update
    void Start()
    {
        gameState = 0;

        startScreen.SetActive(true);
        articleListing.SetActive(false);
    }

    public void StartScreenToArticleListing()
    {
        gameState = 1;
        
        startScreen.SetActive(false);
        articleListing.SetActive(true);
    }
    
    public void SetAddress(string address)
    {
        userAddress = address;
    }

    public void ShowArticle1()
    {
        // enable panel 1 and disable article 2 and article 3
        panel1.SetActive(true);
        
        article2.SetActive(false);
        article3.SetActive(false);
        wallet.SetActive(false);
    }

    public void CloseArticle1()
    {
        // reverse of ShowArticle1
        panel1.SetActive(false);

        article2.SetActive(true);
        article3.SetActive(true);
        wallet.SetActive(true);
    }

    public void ShowArticle2()
    {
        // set panel 2 to active and article 1 and 3 to inactive
        panel2.SetActive(true);

        article1.SetActive(false);
        article3.SetActive(false);
        wallet.SetActive(false);
    }

    public void CloseArticle2()
    {
        // reverse of ShowArticle2
        panel2.SetActive(false);

        article1.SetActive(true);
        article3.SetActive(true);
        wallet.SetActive(true);
    }

    public void ShowArticle3()
    {
        panel3.SetActive(true);

        article1.SetActive(false);
        article2.SetActive(false);
        wallet.SetActive(false);
    }

    public void CloseArticle3()
    {
        panel3.SetActive(false);

        article1.SetActive(true);
        article2.SetActive(true);
        wallet.SetActive(true);
    }

}