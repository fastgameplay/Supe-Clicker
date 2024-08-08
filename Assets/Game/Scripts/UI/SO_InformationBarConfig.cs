namespace SupeClicker.UI
{
    using System;
    using ScriptableEvents.Reference;
    using UnityEngine;

    [CreateAssetMenu(fileName = "Information Bar Config", menuName = "Configs/InfoBar")]
    public class SO_InformationBarConfig : ScriptableObject
    {
        private const string FormatString = "{0} {1}/{2} {3}";

        [field: Header("Colros")]
        [field: SerializeField] public Color BackGround {get; private set;}
        [field: SerializeField] public Color Filler {get; private set;}

        [field: Space(5)]
        [field: Header("Settings")]
        [field: SerializeField] public bool ShowText {get; private set;} = false;
        [field: SerializeField] public bool ManualFillAmountChange {get; private set;} = false;
        [SerializeField] private string InformationPrefix = "";
        [SerializeField] private string InformationSuffix = "";

        [Space(5)]
        [Header("Events")]
        [field: SerializeField] public EventReference<float> OnFillAmountChange;
        [field: SerializeField] public EventReference<int> OnTextBaseChange;
        [field: SerializeField] public EventReference<int> OnTextValueChange;

        public string GetFormatedString(IFormattable first, IFormattable second){
            return string.Format(FormatString, InformationPrefix, first, second, InformationSuffix);
        }
        public string GetFormatedString(string first, string second){
            return string.Format(FormatString, InformationPrefix, first, second, InformationSuffix);
        }
    }
}