using UnityEngine;

public class Flask_Collision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Material customMaterial;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        if (other.tag == "Indicator10")
        {
            customMaterial.SetFloat("_Indicator_Quantity", 0.5f);
        }

        if (other.tag == "Indicator15")
        {
            customMaterial.SetFloat("_Indicator_Quantity", 0.4f);
        }
        if (other.tag == "Indicator20")
        {
            customMaterial.SetFloat("_Indicator_Quantity", 0.3f);
        }

    }
}
