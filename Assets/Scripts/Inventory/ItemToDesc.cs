using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemToDesc : MonoBehaviour
{
    [SerializeField] private GameObject descContainer;
    [SerializeField] private GameObject descImage;
    [SerializeField] private GameObject description;


    public void GoDesc()
    {
        descContainer = GameObject.Find("InventoryDesc");
        descImage = GameObject.Find("DescImage");
        description = GameObject.Find("ItemDesc");

        descImage.GetComponent<Image>().sprite = this.gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
        description.GetComponent<TextMeshProUGUI>().text = this.gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text;
    }
}
