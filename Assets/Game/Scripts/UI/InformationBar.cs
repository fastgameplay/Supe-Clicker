namespace SupeClicker.UI
{
    using System.Collections.Generic;
    using TMPro;
    using Unity.VisualScripting;
    using UnityEngine;
    using UnityEngine.UI;

    public class InformationBar : MonoBehaviour
    {
        [SerializeField] private SO_InformationBarConfig _config;
        [SerializeField] private Image _backGround;
        [SerializeField] private Image _filler;
        [SerializeField] private TMP_Text _info;
        public int CurrentValue
        {
            get => _currentValue;
            set 
            {
                if(value < 0 || value > _baseValue) Debug.LogWarning($"Value ({value}) out of bounds [0f;1f] Clamping...");
                _currentValue = Mathf.Clamp(value,0,_baseValue);
                UpdateText();
                if(!_config.ManualFillAmountChange){
                    HandleFillChange((float)_baseValue/_currentValue);
                }
            }
        }
        private int _baseValue = 100;
        private int _currentValue;

        // Cache for formatted strings
        private Dictionary<int, string> _formattedStringsCache = new Dictionary<int, string>();

        private void HandleFillChange(float value)
        {
            if(value < 0f || value > 1f) Debug.LogWarning($"Value ({value}) out of bounds [0f;1f] Clamping...");

            _filler.fillAmount = Mathf.Clamp01(value);
        }
        private void UpdateText()
        {
            if (!_formattedStringsCache.TryGetValue(_currentValue, out string formattedString))
            {
                // If the string is not in the cache, format it and add it to the cache
                formattedString = _config.GetFormatedString(_baseValue, _currentValue);
                
                _formattedStringsCache[_currentValue] = formattedString;
            }
            _info.text = formattedString;
        }

        private void HandleTextBaseChange(int value)
        {
            _baseValue = value;

            // Clear the cache because the base value has changed
            _formattedStringsCache.Clear();

            CurrentValue = _currentValue; // Update currentValue
        }
        private void HandleTextValueChange(int value) => CurrentValue = value;
        
        void OnEnable()
        {
            if(_config.ManualFillAmountChange)
            {
                _config.OnFillAmountChange += HandleFillChange;
            }

            _info.gameObject.SetActive(_config.ShowText);
            if(_config.ShowText)
            {
                _config.OnTextBaseChange += HandleTextBaseChange;
                _config.OnTextValueChange += HandleTextValueChange;
            }
        }
        void OnDisable()
        {
            if(_config.ManualFillAmountChange)
            {
                _config.OnFillAmountChange -= HandleFillChange;
            }
            if(_config.ShowText)
            {
                _config.OnTextBaseChange += HandleTextBaseChange;
                _config.OnTextValueChange += HandleTextValueChange;
            }
        }
        
    }
}