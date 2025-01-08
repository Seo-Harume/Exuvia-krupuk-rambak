using UnityEngine;

public class UnderlineEffect : MonoBehaviour
{
    public GameObject underline; // Assign the underline object here
    public bool isVisibleOnStart = false; // Atur apakah underline harus terlihat di awal

    private void Start()
    {
        if (underline != null)
        {
            underline.SetActive(isVisibleOnStart);
        }
    }

    public void ShowUnderline()
    {
        if (underline != null)
        {
            underline.SetActive(true);
            Debug.Log("Underline ditampilkan");
        }
        else
        {
            Debug.LogWarning("Underline belum di-assign");
        }
    }


    public void HideUnderline()
    {
        if (underline != null)
        {
            underline.SetActive(false);
        }
    }
}
