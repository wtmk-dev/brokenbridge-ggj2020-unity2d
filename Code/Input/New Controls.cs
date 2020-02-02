// GENERATED AUTOMATICALLY FROM 'Assets/Code/Input/New Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @NewControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @NewControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""New Controls"",
    ""maps"": [
        {
            ""name"": ""PL"",
            ""id"": ""9ab3edde-4f06-42a2-95b4-2113c58aa2f2"",
            ""actions"": [
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""Button"",
                    ""id"": ""3a35cfd8-009d-46f7-abac-062ed3160b0a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Vertical"",
                    ""type"": ""Button"",
                    ""id"": ""2dad21ed-9d47-478a-ab2b-a29b28a5f7b6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""dfbb64fd-e1ba-4c32-8bc6-687dc1a53c7b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3655acb5-ddac-4691-85dd-2b678d264b6f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""33306a3e-7c20-4be2-8ef8-04f0ede8b4b7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""383cbb19-aa3e-4cd1-90a4-54eaea04af63"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d24e737e-8bfd-477a-a7bd-4f2e4888e25b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7388587c-b7bf-414a-98ef-7ab6f940553d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""PR"",
            ""id"": ""ffe45102-aa31-4ab4-b884-82e137b9bdd8"",
            ""actions"": [
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""PassThrough"",
                    ""id"": ""715b9563-a441-4731-a099-3e6515769d1a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Vertical"",
                    ""type"": ""Button"",
                    ""id"": ""bf1126ca-c375-4363-b880-b732e4e79485"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""878ffa40-af0d-4805-886d-24405a1cdf13"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d6fbef39-e528-40b2-94e1-e00a9bc01297"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7d6f704d-050e-4430-87fa-50e8a449bf51"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""00316fa6-fea4-4e46-9338-1d55c6835e37"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""071be51a-dd75-4d2d-9872-f06a63249b46"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""364884f0-7028-400d-9b87-29eae624fb29"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PL
        m_PL = asset.FindActionMap("PL", throwIfNotFound: true);
        m_PL_Horizontal = m_PL.FindAction("Horizontal", throwIfNotFound: true);
        m_PL_Vertical = m_PL.FindAction("Vertical", throwIfNotFound: true);
        // PR
        m_PR = asset.FindActionMap("PR", throwIfNotFound: true);
        m_PR_Horizontal = m_PR.FindAction("Horizontal", throwIfNotFound: true);
        m_PR_Vertical = m_PR.FindAction("Vertical", throwIfNotFound: true);
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

    // PL
    private readonly InputActionMap m_PL;
    private IPLActions m_PLActionsCallbackInterface;
    private readonly InputAction m_PL_Horizontal;
    private readonly InputAction m_PL_Vertical;
    public struct PLActions
    {
        private @NewControls m_Wrapper;
        public PLActions(@NewControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Horizontal => m_Wrapper.m_PL_Horizontal;
        public InputAction @Vertical => m_Wrapper.m_PL_Vertical;
        public InputActionMap Get() { return m_Wrapper.m_PL; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PLActions set) { return set.Get(); }
        public void SetCallbacks(IPLActions instance)
        {
            if (m_Wrapper.m_PLActionsCallbackInterface != null)
            {
                @Horizontal.started -= m_Wrapper.m_PLActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_PLActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_PLActionsCallbackInterface.OnHorizontal;
                @Vertical.started -= m_Wrapper.m_PLActionsCallbackInterface.OnVertical;
                @Vertical.performed -= m_Wrapper.m_PLActionsCallbackInterface.OnVertical;
                @Vertical.canceled -= m_Wrapper.m_PLActionsCallbackInterface.OnVertical;
            }
            m_Wrapper.m_PLActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
                @Vertical.started += instance.OnVertical;
                @Vertical.performed += instance.OnVertical;
                @Vertical.canceled += instance.OnVertical;
            }
        }
    }
    public PLActions @PL => new PLActions(this);

    // PR
    private readonly InputActionMap m_PR;
    private IPRActions m_PRActionsCallbackInterface;
    private readonly InputAction m_PR_Horizontal;
    private readonly InputAction m_PR_Vertical;
    public struct PRActions
    {
        private @NewControls m_Wrapper;
        public PRActions(@NewControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Horizontal => m_Wrapper.m_PR_Horizontal;
        public InputAction @Vertical => m_Wrapper.m_PR_Vertical;
        public InputActionMap Get() { return m_Wrapper.m_PR; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PRActions set) { return set.Get(); }
        public void SetCallbacks(IPRActions instance)
        {
            if (m_Wrapper.m_PRActionsCallbackInterface != null)
            {
                @Horizontal.started -= m_Wrapper.m_PRActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_PRActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_PRActionsCallbackInterface.OnHorizontal;
                @Vertical.started -= m_Wrapper.m_PRActionsCallbackInterface.OnVertical;
                @Vertical.performed -= m_Wrapper.m_PRActionsCallbackInterface.OnVertical;
                @Vertical.canceled -= m_Wrapper.m_PRActionsCallbackInterface.OnVertical;
            }
            m_Wrapper.m_PRActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
                @Vertical.started += instance.OnVertical;
                @Vertical.performed += instance.OnVertical;
                @Vertical.canceled += instance.OnVertical;
            }
        }
    }
    public PRActions @PR => new PRActions(this);
    public interface IPLActions
    {
        void OnHorizontal(InputAction.CallbackContext context);
        void OnVertical(InputAction.CallbackContext context);
    }
    public interface IPRActions
    {
        void OnHorizontal(InputAction.CallbackContext context);
        void OnVertical(InputAction.CallbackContext context);
    }
}
