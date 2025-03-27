using UnityEngine;
using UnityEngine.UI;

public class LiquidAmount : MonoBehaviour
{

    public Text Text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Text.text = "Liquid: 50mL";
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = FindObjectOfType<Burette_Collision>().getLiquid().ToString("F2") + "mL";
    }
}
