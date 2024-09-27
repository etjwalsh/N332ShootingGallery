using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryView : MonoBehaviour
{
    [SerializeField] protected Image icon;
    [SerializeField] protected TextMeshProUGUI label;
    [SerializeField] protected InventoryItem[] items;

    protected int currentItem = -1;

    protected void Start()
    {
        updateView();
    }

    protected void Update()
    {
        RectTransform iconRect = icon.gameObject.GetComponent<RectTransform>();

        Vector3 rot = iconRect.eulerAngles;
        rot.z += 10f * Time.deltaTime;
        iconRect.eulerAngles = rot;

    }

    public void leftArrowClick()
    {
        currentItem--;
        if (currentItem < 0)
        {
            currentItem = items.Length - 1;
        }
        updateView();
    }

    public void rightArrowClick()
    {
        currentItem++;
        if (currentItem >= items.Length)
        {
            currentItem = 0;
        }
        updateView();
    }

    protected void updateView()
    {
        if (currentItem < 0 || items.Length == 0)
        {
            icon.sprite = null;
            label.text = "";
            return;
        }

        if (currentItem >= items.Length - 1)
        {
            currentItem = 0;
        }

        icon.sprite = items[currentItem].icon;
        label.text = $"<b>{items[currentItem].label}</b><br>{items[currentItem].description}";
    }
}
