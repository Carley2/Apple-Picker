using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int  numBaskets = 4;
    public float  basketBottomY = -14f;
    public float  basketSpacingY = 2f;
    public List<GameObject> basketList;
    public GameManager gameManager;
    
    void Start(){
        basketList = new List<GameObject>();
        for (int i=0; i <numBaskets; i++) {
            GameObject tBasketGO = Instantiate<GameObject>( basketPrefab );
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + ( basketSpacingY * i );
            tBasketGO.transform.position = pos;
            basketList.Add( tBasketGO );
        }
        
    }

    public void AppleMissed() {
        // Don't do anything if the game is already over
        if (basketList.Count == 0)
        {
            return;
        }

        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");

        foreach (GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }

        // Destroy any branches that are currently falling
        GameObject[] branchArray = GameObject.FindGameObjectsWithTag("Branch");

        foreach (GameObject tempGO in branchArray)
        {
            Destroy(tempGO);
        }           

        int basketIndex = basketList.Count - 1;

        GameObject basketGO = basketList[basketIndex];

        basketList.RemoveAt(basketIndex);

        Destroy(basketGO);

        int currentRound = 5 - basketList.Count;

        if (basketList.Count > 0)
        {
            gameManager.roundText.text = "Round " + currentRound;
        }

        if (basketList.Count == 0)
        {
            gameManager.GameOver();
        }
    }

}
