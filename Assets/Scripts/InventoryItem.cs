using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] protected Sprite _icon;
    [SerializeField] protected string _label;
    [SerializeField] protected string _description;

    public Sprite icon
    {
        get
        {
            return _icon;
        }
    }

    public string label
    {
        get
        {
            return _label;
        }
    }

    public string description
    {
        get
        {
            return _description;
        }
    }

}
