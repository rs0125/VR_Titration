using UnityEngine;
using System.Collections;

public class Burette_Collision : MonoBehaviour
{
    public Material customMaterial;
    public float titrant = 0.5f;
    public static float liquid = 50;
    public float decreaseRate = 0.1f;  // Rate at which the liquid decreases per second

    private Coroutine decreaseCoroutine;
    private bool isDecreasing = false;  // Flag to control the decrease

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Beaker")
        {
            customMaterial.SetFloat("_Titrate_Quantity", titrant);
            if (!isDecreasing)
            {
                decreaseCoroutine = StartCoroutine(DecreaseLiquid());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Beaker")
        {
            if (isDecreasing)
            {
                StopCoroutine(decreaseCoroutine);
                isDecreasing = false;  // Set the flag to false
            }
        }
    }

    private IEnumerator DecreaseLiquid()
    {
        isDecreasing = true;  // Set the flag to true
        while (liquid > 0)
        {
            liquid -= decreaseRate * Time.deltaTime;
            liquid = Mathf.Max(liquid, 0);  // Ensure liquid doesn't go below 0
            yield return null;
        }
        isDecreasing = false;  // Reset the flag when the loop ends
    }

    public float getLiquid()
    {
        return liquid;
    }
}
