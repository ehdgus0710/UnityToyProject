using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputActionRebindingExtensions;

public class KeyInterection : MonoBehaviour
{    
    [SerializeField]
    private InputActionReference inputAction;
    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    public Text keyCodeText;
    public Text keyCodeNameText;
    
    [SerializeField]
    private string currentEffectivePath;

    public UnityEvent duplicateBindingEvent;

    private void Start()
    {
        UpdateKeyInterection();
    }

    public void ChangeApplyBinding()
    {
        inputAction.action.Disable();
        keyCodeText.text = "Wait...";
        rebindingOperation = inputAction.action.PerformInteractiveRebinding()
            //.WithControlsExcluding("Mouse")
            .WithControlsExcluding("Gamepad")
            .WithCancelingThrough("<Keyboard>/escape")
            .OnMatchWaitForAnother(0.1f)
            .OnCancel(operation => RebindCancel())
            .OnComplete(operation => RebindComplete());

        rebindingOperation.Start();
    }

    private void RebindCancel()
    {
        inputAction.action.Enable();
        rebindingOperation.Dispose();
        UpdateKeyInterection();
    }

    private void RebindComplete()
    {
        inputAction.action.Enable();
        rebindingOperation.Dispose();

        int inputActionindex = inputAction.action.GetBindingIndexForControl(inputAction.action.controls[0]);
        string effectivePath = inputAction.action.bindings[inputActionindex].effectivePath;

        InputControlPath.ToHumanReadableString(effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        if (CheckDuplicateBindings(effectivePath))
            duplicateBindingEvent?.Invoke();
        else
            UpdateKeyInterection();
    }

    public void UpdateKeyInterection()
    {
        var device = string.Empty;
        var keyCode = string.Empty;

        inputAction.action.GetBindingDisplayString(0, out device, out keyCode);
        currentEffectivePath = inputAction.action.bindings[0].effectivePath;
        keyCodeText.text = inputAction.action.name;
        keyCodeNameText.text = keyCode;
    }

    public bool CheckDuplicateBindings(string path)
    {
        var inputActionMap = inputAction.action.actionMap;

        foreach (var inputBinding in inputActionMap.bindings)
        {
            if (inputBinding.action == inputAction.action.name)
                continue;

            if (inputBinding.effectivePath == path)
            {
                var action = inputActionMap.FindAction(inputBinding.action);
                action.ApplyBindingOverride(currentEffectivePath);
                return true;
            }
        }

        return false;
    }

}
