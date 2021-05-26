// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""ecaee42d-6a5a-461a-b926-3f5ca0035042"",
            ""actions"": [
                {
                    ""name"": ""Beam1"",
                    ""type"": ""Value"",
                    ""id"": ""5108f521-da95-4b16-a000-ea9738f99742"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Beam2"",
                    ""type"": ""Value"",
                    ""id"": ""b3623e98-b2ab-4cb1-b4e1-a89e9e065b7e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""b40ad5a3-8d9a-403e-bf0f-753148b55193"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""e2adf864-50ce-423b-bd55-a3d931623c8e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""7e89b8df-bfe9-43e4-8201-2d926d694a62"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Beam1"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d141bf25-7a5c-4810-8c3c-890e885afc64"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Beam1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""08760084-64c0-4a0b-859e-1dd4c24d0443"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Beam1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""daf082c9-9e2b-4f9b-befa-6c64d1b922b1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Beam1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f5cd2c6f-4716-48fc-9a36-ad5a8a328f34"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Beam1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5b0641a5-8aba-4068-a8ef-9f73ee3a9a09"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Beam1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""52ec4498-ba15-467b-b253-ca7fe8c9be3f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Beam2"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5ee6587e-277a-4c4c-867d-c946f5482a87"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Beam2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""28edabbc-a13d-4e5d-8355-2327f611f445"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Beam2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""52a6cf10-edfb-4760-a432-8a4a8b9a6598"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Beam2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""06b9a77f-9ef3-4673-95b7-a1e9a08087c4"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Beam2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bf5f37f6-f710-4fcb-9b8e-72b104d76dcb"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Beam2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72832bdc-21a5-4ecc-a9d6-5ddb8d92f5b6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""835128d7-4999-4d0b-abc4-1f4aedbe32dd"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98a48ce3-15d0-41f9-af89-5f679ff8d5b5"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ad96b40-754f-4319-9b2c-decff07b2c3d"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Gravity"",
            ""id"": ""c67305ac-acb4-4133-a3c5-9b66a0c1d10b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""c70071df-bf72-484e-b353-b87972bc9fe2"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Web"",
                    ""type"": ""Value"",
                    ""id"": ""1b8163bf-7f51-430e-be74-1406c48d8d93"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""0ed6aab5-a1a5-4ecd-8264-e197d75d389a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""82d1ec72-6282-4c7c-851c-a442d7e263ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""93bc5d7e-581f-4e6e-8008-1c8ca70ec03c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""97e517e3-c38e-4085-b945-4e397e851709"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""e24b3646-1f77-4f18-9462-6c075a6bdb98"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""08000499-a9aa-41b8-9f13-a5e11ef09c11"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""71c10d08-a25d-4de1-8aaa-0814d2184114"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Web"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a1e45872-3669-40ff-a98e-554064f6bd92"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Web"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""63c9f5b9-166d-40de-b660-7096dea05a17"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Web"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""36577c5b-a62f-4330-a76a-8ceecef9ced6"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Web"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1792f96f-f30c-4937-9d3c-8fc158179d28"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Web"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9b8c3bd5-0645-4d60-a548-7d4fd57ca219"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Web"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""438da936-4599-4a31-9f54-3967a6ea5649"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75856bf0-8ec6-439b-a0e1-df31425167c0"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1fe071fe-f2ab-4a2d-b046-41e6094a111e"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""506ab956-4cff-4c29-9278-cf1a7c84f725"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Beam1 = m_Gameplay.FindAction("Beam1", throwIfNotFound: true);
        m_Gameplay_Beam2 = m_Gameplay.FindAction("Beam2", throwIfNotFound: true);
        m_Gameplay_Interact = m_Gameplay.FindAction("Interact", throwIfNotFound: true);
        m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
        // Gravity
        m_Gravity = asset.FindActionMap("Gravity", throwIfNotFound: true);
        m_Gravity_Move = m_Gravity.FindAction("Move", throwIfNotFound: true);
        m_Gravity_Web = m_Gravity.FindAction("Web", throwIfNotFound: true);
        m_Gravity_Jump = m_Gravity.FindAction("Jump", throwIfNotFound: true);
        m_Gravity_Pause = m_Gravity.FindAction("Pause", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Beam1;
    private readonly InputAction m_Gameplay_Beam2;
    private readonly InputAction m_Gameplay_Interact;
    private readonly InputAction m_Gameplay_Pause;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Beam1 => m_Wrapper.m_Gameplay_Beam1;
        public InputAction @Beam2 => m_Wrapper.m_Gameplay_Beam2;
        public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Beam1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBeam1;
                @Beam1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBeam1;
                @Beam1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBeam1;
                @Beam2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBeam2;
                @Beam2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBeam2;
                @Beam2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBeam2;
                @Interact.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Beam1.started += instance.OnBeam1;
                @Beam1.performed += instance.OnBeam1;
                @Beam1.canceled += instance.OnBeam1;
                @Beam2.started += instance.OnBeam2;
                @Beam2.performed += instance.OnBeam2;
                @Beam2.canceled += instance.OnBeam2;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Gravity
    private readonly InputActionMap m_Gravity;
    private IGravityActions m_GravityActionsCallbackInterface;
    private readonly InputAction m_Gravity_Move;
    private readonly InputAction m_Gravity_Web;
    private readonly InputAction m_Gravity_Jump;
    private readonly InputAction m_Gravity_Pause;
    public struct GravityActions
    {
        private @PlayerControls m_Wrapper;
        public GravityActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gravity_Move;
        public InputAction @Web => m_Wrapper.m_Gravity_Web;
        public InputAction @Jump => m_Wrapper.m_Gravity_Jump;
        public InputAction @Pause => m_Wrapper.m_Gravity_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Gravity; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GravityActions set) { return set.Get(); }
        public void SetCallbacks(IGravityActions instance)
        {
            if (m_Wrapper.m_GravityActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GravityActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GravityActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GravityActionsCallbackInterface.OnMove;
                @Web.started -= m_Wrapper.m_GravityActionsCallbackInterface.OnWeb;
                @Web.performed -= m_Wrapper.m_GravityActionsCallbackInterface.OnWeb;
                @Web.canceled -= m_Wrapper.m_GravityActionsCallbackInterface.OnWeb;
                @Jump.started -= m_Wrapper.m_GravityActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GravityActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GravityActionsCallbackInterface.OnJump;
                @Pause.started -= m_Wrapper.m_GravityActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GravityActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GravityActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GravityActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Web.started += instance.OnWeb;
                @Web.performed += instance.OnWeb;
                @Web.canceled += instance.OnWeb;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GravityActions @Gravity => new GravityActions(this);
    public interface IGameplayActions
    {
        void OnBeam1(InputAction.CallbackContext context);
        void OnBeam2(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IGravityActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnWeb(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
