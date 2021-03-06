﻿using UnityEngine;
using UnityEngine.UI;

namespace Nashet.UnityUIUtils
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(ToolTipHandler))]
    public class HotKey : MonoBehaviour
    {
        [SerializeField]
        private KeyCode key;

        [SerializeField]
        private bool addTextInTooltip = true;

        [SerializeField]
        private bool allowsKeyHolding;

        private Button button;

        //private ToolTipHandler tooltip;
        private void Start()
        {
            button = GetComponent<Button>();
            if (addTextInTooltip)
            {
                var tooltip = GetComponent<ToolTipHandler>();
                tooltip.AddText("\nHotkey is " + key + " button");
            }
        }

        // Update is called once per frame
        private void Update()
        {
            if (allowsKeyHolding)
            {
                if (Input.GetKey(key) && button.interactable)
                    button.onClick.Invoke();
            }
            else
            {
                if (Input.GetKeyUp(key) && button.interactable)
                    button.onClick.Invoke();
            }
        }
    }
}