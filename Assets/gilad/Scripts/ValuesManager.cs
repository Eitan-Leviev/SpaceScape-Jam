using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ValuesManager : MonoBehaviour
{
    private static ValuesManager shared;

    private Color32 zeroColor;

    private Color32 originaleColor;

    private Color32 originalCircleColor;

    private Color32 zeroCircleColor;

    private Color32 zz;

    [SerializeField] private byte alpha = 75;

    [SerializeField] private TextMeshProUGUI wallTxt;
    
    [SerializeField] private TextMeshProUGUI magnetTxt;
    
    [SerializeField] private TextMeshProUGUI ventsTxt;

    [SerializeField] private Image wallCircle;
    
    [SerializeField] private Image magnetCircle;
    
    [SerializeField] private Image ventCircle;
    // Start is called before the first frame update
    void Start()
    {
        zeroColor = wallTxt.faceColor;
        originaleColor = wallTxt.faceColor;
        zeroCircleColor = wallCircle.color;
        originalCircleColor = wallCircle.color;
        zeroCircleColor.a = alpha;
        shared = this;
        zeroColor.a = alpha;
        print(originaleColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void UpdateQuants()
    {
        // print(shared.zeroColor);
        if(shared.magnetTxt != null)
        {
            
            if (GameManager.NumMagnets == 0)
            {
                shared.magnetTxt.faceColor = shared.zeroColor;
                shared.magnetCircle.color = shared.zeroCircleColor;
                print(shared.magnetCircle.color);
            }
            else
            {
                shared.magnetTxt.faceColor = shared.originaleColor;
                shared.magnetCircle.color = shared.originalCircleColor;
            }
            shared.magnetTxt.text = GameManager.NumMagnets.ToString();
        }
        if(shared.ventsTxt != null)
        {
            
            if (GameManager.NumVents == 0)
            {
                shared.ventsTxt.faceColor = shared.zeroColor;
                shared.ventCircle.color = shared.zeroCircleColor;
            }
            else
            {
                shared.ventsTxt.faceColor = shared.originaleColor;
                shared.ventCircle.color = shared.originalCircleColor;
            }
            shared.ventsTxt.text = GameManager.NumVents.ToString();
        }
        if(shared.wallTxt != null)
        {
            
            if (GameManager.NumWalls == 0)
            {
                shared.wallTxt.faceColor = shared.zeroColor;
                shared.wallCircle.color = shared.zeroCircleColor;
            }
            else
            {
                shared.wallTxt.faceColor = shared.originaleColor;
                shared.wallCircle.color = shared.originalCircleColor;
            }
            shared.wallTxt.text = GameManager.NumWalls.ToString();
        }
    }
}
