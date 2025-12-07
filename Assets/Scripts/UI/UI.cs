using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject[] uiElements;
    public bool alternativeInput { get; private set; }
    private PlayerInputSet input;

    #region UI Components
    public UI_SkillToolTip skillToolTip { get; private set; }
    public UI_ItemToolTip itemToolTip { get; private set; }
    public UI_StatToolTip statToolTip { get; private set; }

    public UI_SkillTree skillTreeUI { get; private set; }
    public UI_Inventory inventoryUI { get; private set; }
    public UI_InGame inGameUI { get; private set; }
    public UI_Options optionsUI { get; private set; }

    public UI_DeathScreen deathScreenUI { get; private set; }
    public UI_WinScreen winScreenUI { get; private set; }
    #endregion

    private bool skillTreeEnabled;
    private bool inventoryEnabled;

    private void Awake()
    {
        itemToolTip = GetComponentInChildren<UI_ItemToolTip>();
        skillToolTip = GetComponentInChildren<UI_SkillToolTip>();
        statToolTip = GetComponentInChildren<UI_StatToolTip>();

        skillTreeUI = GetComponentInChildren<UI_SkillTree>(true);
        inventoryUI = GetComponentInChildren<UI_Inventory>(true);
        inGameUI = GetComponentInChildren<UI_InGame>(true);
        optionsUI = GetComponentInChildren<UI_Options>(true);
        deathScreenUI = GetComponentInChildren<UI_DeathScreen>(true);
        winScreenUI = GetComponentInChildren<UI_WinScreen>(true);

        skillTreeEnabled = skillTreeUI.gameObject.activeSelf;
        inventoryEnabled = inventoryUI.gameObject.activeSelf;
    }

    private void Start()
    {
        skillTreeUI.UnlockDefaultSkills();
    }

    public void SetupControlsUI(PlayerInputSet inputSet)
    {
        input = inputSet;

        input.UI.SkillTreeUI.performed += ctx => ToggleSkillTreeUI();
        input.UI.InventoryUI.performed += ctx => ToggleInventoryUI();

        input.UI.AlternativeInput.performed += ctx => alternativeInput = true;
        input.UI.AlternativeInput.canceled += ctx => alternativeInput = false;

        input.UI.OptionsUI.performed += ctx =>
        {
            foreach (var element in uiElements)
            {
                if(element.activeSelf)
                {
                    SwitchToInGameUI();
                    return;
                }
            }

            OpenOptionsUI();
        };
    }

    public void OpenDeathScreenUI()
    {
        SwitchTo(deathScreenUI.gameObject);
        input.Disable();
    }

    public void OpenWinScreenUI()
    {
        SwitchTo(winScreenUI.gameObject);
        input.Disable();
    }

    public void OpenOptionsUI()
    {
        HideAllTooltips();
        StopPlayerControls(true);
        SwitchTo(optionsUI.gameObject);
    }

    public void SwitchToInGameUI()
    {
        HideAllTooltips();
        StopPlayerControls(false);
        SwitchTo(inGameUI.gameObject);

        skillTreeEnabled = false; //Warning!!
        inventoryEnabled = false; //Warning!!
    }

    private void SwitchTo(GameObject objectToSwitchOn)
    {
        foreach (var element in uiElements)
            element.gameObject.SetActive(false);

        objectToSwitchOn.SetActive(true);
    }

    private void StopPlayerControls(bool stopControls)
    {
        if (stopControls)
            input.Player.Disable();
        else
            input.Player.Enable();
    }

    public void HideAllTooltips()
    {
        itemToolTip.ShowToolTip(false, null);
        skillToolTip.ShowToolTip(false, null);
        statToolTip.ShowToolTip(false, null);
    }

    public void ToggleSkillTreeUI()
    {
        skillTreeEnabled = !skillTreeEnabled;
        skillTreeUI.gameObject.SetActive(skillTreeEnabled);
        skillToolTip.ShowToolTip(false, null);

        StopPlayerControls(skillTreeEnabled);
    }

    public void ToggleInventoryUI()
    {
        inventoryEnabled = !inventoryEnabled;
        inventoryUI.gameObject.SetActive(inventoryEnabled);
        statToolTip.ShowToolTip(false, null);
        itemToolTip.ShowToolTip(false, null);

        StopPlayerControls(inventoryEnabled);
    }
}
