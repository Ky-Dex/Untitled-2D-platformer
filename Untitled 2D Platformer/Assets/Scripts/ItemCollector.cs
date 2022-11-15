using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    int appleCount = 0;
    [SerializeField] TMP_Text appleText;
    GameObject collectible;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Apple"))
        {
            collectible = collision.gameObject;
            collectible.GetComponent<Animator>().SetTrigger("Collect");
            appleCount++;
            appleText.text = "Apples: " + appleCount;
        }
    }
}
