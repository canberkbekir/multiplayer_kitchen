using System;
using Kitchen.Appliances;
using TMPro;
using UnityEngine;

namespace Kitchen.UI
{
    public class StoveUIManager : MonoBehaviour
    {
        [SerializeField] private Stove _stove;
        [SerializeField] private TextMeshProUGUI _stoveStatusText;
        private void Start()
        {
            _stove = gameObject.GetComponent<Stove>();
        }

        private void Update()
        {
            SetStoveStatus();
        }

        private void SetStoveStatus()
        {
            _stoveStatusText.text = _stove.status.ToString();
        }



    }
}
