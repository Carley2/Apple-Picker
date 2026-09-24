using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour{
    static private TMP_Text  _UI_TEXT;
    static private int  _SCORE = 1000;

    private TMP_Text txtCom;

    void Awake () {
        _UI_TEXT = GetComponent<TMP_Text>();
    }

    static public int SCORE {
        get { return _SCORE; }
        private set {
            _SCORE = value;
            if ( _UI_TEXT != null ) {
                _UI_TEXT.text = "High Score: " + value.ToString( "#,0" );
            }
        }
    }

    static public void TRY_SET_HIGH_SCORE( int scoreToTry ) {
        if ( scoreToTry <= SCORE ) return; // If scoreToTry is too low, return
        SCORE = scoreToTry;
    }

}
