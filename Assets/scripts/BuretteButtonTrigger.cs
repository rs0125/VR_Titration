using UnityEngine;

public class BuretteButtonTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static bool burettebutton = false;
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        burettebutton = true;
    }

    private void OnTriggerExit(Collider other)
    {
        burettebutton = false;
    }

    public bool BuretteButtonStatus()
    {
        return burettebutton;
    }
}
