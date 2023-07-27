using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thirdweb;
using System.Threading.Tasks;

public class Article1 : MonoBehaviour
{
    public Prefab_NFT nftPrefab;
    public string contractAddress= "0x6818cc290d58719bc7D3eEDB982c3135238Fa1a6";  //\\ --> "0x6818cc290d58719bc7D3eEDB982c3135238Fa1a6"
    public string tokenId= "0";          //\\ --> "0" , "1" , "2" for article 1, 2, 3

    public GameObject readButton;
    public GameObject claimButton;

    private ThirdwebSDK sdk;

    // Start is called before the first frame update
    public void Start()
    {
        readButton.SetActive(false);
        claimButton.SetActive(false);

        sdk = new ThirdwebSDK("goerli");

        // load the nft
        Contract contract = sdk.GetContract(contractAddress);
        GetNFTmedia(contract);

        CheckBalance(GameManager.userAddress);
    }

    private void Update() {
        CheckBalance(GameManager.userAddress);
    }

    public async Task<string> CheckBalance(string userAddress)
    {
        Contract contract = sdk.GetContract(contractAddress);
        string balance = await contract.Read<string>("balanceOf", userAddress, int.Parse(tokenId)); // useraddress, tokenid
        float balanceFloat = float.Parse(balance);

        if (balanceFloat > 0)
        {
            readButton.SetActive(true);
            claimButton.SetActive(false);
        }
        else
        {
            readButton.SetActive(false);
            claimButton.SetActive(true);
        }

        return balance;
    }

    public async void GetNFTmedia(Contract contract)
    {
        NFT nft = await contract.ERC1155.Get(tokenId);
        Prefab_NFT nftPrefabScript = nftPrefab.GetComponent<Prefab_NFT>();
        nftPrefabScript.LoadNFT(nft);
    }

    public async void ClaimAccessKey()
    {
        Contract contract = sdk.GetContract(contractAddress);
        await contract.ERC1155.ClaimTo(GameManager.userAddress, tokenId, 1);                              //useraddress, tokenid, amount
    }

}
