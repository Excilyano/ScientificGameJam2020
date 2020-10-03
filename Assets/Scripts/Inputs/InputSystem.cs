// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Inputs/InputSystem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputSystem : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""Default map"",
            ""id"": ""f1f6500d-dcb2-404c-ab2e-c3a41234f680"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""658c1a88-c125-47fd-a3ea-cfd0b3131560"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""12770a0c-fbb5-40bb-be41-917cc0bd0953"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""801e9000-89e7-417a-b27e-83562f605b9e"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Default map
        m_Defaultmap = asset.FindActionMap("Default map", throwIfNotFound: true);
        m_Defaultmap_Move = m_Defaultmap.FindAction("Move", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Default map
    private readonly InputActionMap m_Defaultmap;
    private IDefaultmapActions m_DefaultmapActionsCallbackInterface;
    private readonly InputAction m_Defaultmap_Move;
    public struct DefaultmapActions
    {
        private @InputSystem m_Wrapper;
        public DefaultmapActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Defaultmap_Move;
        public InputActionMap Get() { return m_Wrapper.m_Defaultmap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultmapActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultmapActions instance)
        {
            if (m_Wrapper.m_DefaultmapActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_DefaultmapActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_DefaultmapActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_DefaultmapActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_DefaultmapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public DefaultmapActions @Defaultmap => new DefaultmapActions(this);
    public interface IDefaultmapActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
