using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text ComboText;
    [SerializeField] Image RestTimeImage;
    [SerializeField] Text RestTimeText;
    [SerializeField] Image BombGuageImage;
    [SerializeField] Text ScoreBoard;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Combo()
    {
        if (GamePlay.instance.Combo > 0.0f)
        {
            ComboText.text = GamePlay.instance.Combo.ToString() + "Combo";
        }
    }

    private void RestTime()
    {
        RestTimeImage.fillAmount = GamePlay.instance.PlayTime / GamePlay.instance.FullTime;
        RestTimeText.text = GamePlay.instance.PlayTime.ToString();
    }

    private void Bomb()
    {
        BombGuageImage.fillAmount = GamePlay.instance.BombPoint / GamePlay.instance.Bombfull;
    }


    
    // Update is called once per frame


    void Update()
    {
        Combo();
        RestTime();
        Bomb();
    }
}
