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
                    ""name"": """",
                    ""id"": ""7be778f4-39cf-4b1e-aacd-86b44b6c3b58"",
                    ""path"": ""<Joystick>/stick"",
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
                    ""id"": ""cf9a18c5-47c8-4a03-b7cd-e3d7de86b66f"",
                    ""path"": ""<HID::HORI CO.,LTD. HORIPAD S>/hat"",
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
                    ""id"": ""53c8b12f-0e1d-4b7f-b216-0ca24e81d2ad"",
                    ""path"": ""<HID::HORI CO.,LTD. HORIPAD S>/button3"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""a0ba6276-4f49-490c-b5ef-f8681b1ca0ce"",
                    ""path"": ""<HID::HORI CO.,LTD. HORIPAD S>/button10"",
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
                    ""name"": ""WebShoot"",
                    ""type"": ""Button"",
                    ""id"": ""1b8163bf-7f51-430e-be74-1406c48d8d93"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WebAim"",
                    ""type"": ""Value"",
                    ""id"": ""7108773d-0e4b-4c5c-8daa-e00c724bad91"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WebClimb"",
                    ""type"": ""Value"",
                    ""id"": ""56352519-110f-4cb9-9683-af25202fcd2c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WebCancel"",
                    ""type"": ""Button"",
                    ""id"": ""85569356-1b9c-4ce5-a442-879140eec298"",
                    ""expectedControlType"": ""Button"",
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
                    ""name"": """",
                    ""id"": ""b4a65f48-d4b5-4f09-acc8-c2ecbabc0033"",
                    ""path"": ""<Gamepad>/dpad/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""74afb125-9403-4847-bb7b-8d9596440e33"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f5e5a81d-8002-4be6-9244-1705cecd6789"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c92ee008-898e-47a5-82a7-421ebad9d243"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Horipad"",
                    ""id"": ""1ccd9d04-e53f-4f39-84ad-be62a4b63a4f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f53f585d-775c-43b3-a32d-94587a5a30f3"",
                    ""path"": ""<HID::HORI CO.,LTD. HORIPAD S>/hat/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a07bea45-7bb3-4fca-8f94-19073301073d"",
                    ""path"": ""<HID::HORI CO.,LTD. HORIPAD S>/hat/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
                    ""id"": ""0e191f8b-9d2b-416d-a7c8-c3ccdc2e9896"",
                    ""path"": ""<HID::HORI CO.,LTD. HORIPAD S>/button3"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""6c2dab7a-3b38-4682-bfbb-c92e6a67635d"",
                    ""path"": ""<HID::HORI CO.,LTD. HORIPAD S>/button10"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""538400f0-8308-40a4-bae0-db86c7ca20d0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WebShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aab53d30-7216-4201-bafa-a9f17eb170fe"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WebShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f122e95-034c-4673-9e46-827ac0bc4bf9"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WebShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17901ae8-2315-4531-b048-ecac9239d8b5"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WebShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71c96333-a17e-4a11-b1e8-94e9cb1247e3"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WebShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecd8afb8-3735-4d5f-8140-58d6e356536e"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WebShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33a20bd8-6df2-4f12-b192-b58a6e47ff89"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WebShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7f9a41d-4c71-4848-98be-0d3e032d71c6"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WebShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a10e2a47-c8de-4595-935c-38cccfada691"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WebShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93d448f1-6657-4737-9c5e-5b1d9ff0ff1c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WebCancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""571a5ed5-605b-4579-81f9-c2ddc49f5b90"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WebCancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83718503-cbe7-4686-b7ca-e2165d4b526d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WebCancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""505930b0-41be-4585-810a-dff80df87c92"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WebCancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e996e1c2-2f3d-4dd7-980b-6040f08e0de7"",
                    ""path"": ""<HID::HORI CO.,LTD. HORIPAD S>/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WebCancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""b6383830-b1b9-4a3a-82a3-2ac9a04ed633"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WebClimb"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b850a258-be94-4928-bedd-b6bb68e27f7c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WebClimb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""755c20ea-f488-4955-84d7-63e20224d483"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WebClimb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ea284345-1dec-4e3f-90bf-99d4a5720ea3"",
                    ""path"": ""<Gamepad>/leftStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WebClimb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""987312fd-bab6-4175-8c9b-42f2e0da0e5d"",
                    ""path"": ""<Gamepad>/dpad/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WebClimb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ce976fb-0124-47c2-9396-50be357d17ec"",
                    ""path"": ""<HID::HORI CO.,LTD. HORIPAD S>/hat/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WebClimb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d66338b-2ec0-4185-bf76-a6734cde38bd"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WebAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""771e958a-d990-4d6b-9e52-b1ad270c4daa"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WebAim"",
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
        m_Gravity_WebShoot = m_Gravity.FindAction("WebShoot", throwIfNotFound: true);
        m_Gravity_WebAim = m_Gravity.FindAction("WebAim", throwIfNotFound: true);
        m_Gravity_WebClimb = m_Gravity.FindAction("WebClimb", throwIfNotFound: true);
        m_Gravity_WebCancel = m_Gravity.FindAction("WebCancel", throwIfNotFound: true);
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
    private readonly InputAction m_Gravity_WebShoot;
    private readonly InputAction m_Gravity_WebAim;
    private readonly InputAction m_Gravity_WebClimb;
    private readonly InputAction m_Gravity_WebCancel;
    private readonly InputAction m_Gravity_Jump;
    private readonly InputAction m_Gravity_Pause;
    public struct GravityActions
    {
        private @PlayerControls m_Wrapper;
        public GravityActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gravity_Move;
        public InputAction @WebShoot => m_Wrapper.m_Gravity_WebShoot;
        public InputAction @WebAim => m_Wrapper.m_Gravity_WebAim;
        public InputAction @WebClimb => m_Wrapper.m_Gravity_WebClimb;
        public InputAction @WebCancel => m_Wrapper.m_Gravity_WebCancel;
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
                @WebShoot.started -= m_Wrapper.m_GravityActionsCallbackInterface.OnWebShoot;
                @WebShoot.performed -= m_Wrapper.m_GravityActionsCallbackInterface.OnWebShoot;
                @WebShoot.canceled -= m_Wrapper.m_GravityActionsCallbackInterface.OnWebShoot;
                @WebAim.started -= m_Wrapper.m_GravityActionsCallbackInterface.OnWebAim;
                @WebAim.performed -= m_Wrapper.m_GravityActionsCallbackInterface.OnWebAim;
                @WebAim.canceled -= m_Wrapper.m_GravityActionsCallbackInterface.OnWebAim;
                @WebClimb.started -= m_Wrapper.m_GravityActionsCallbackInterface.OnWebClimb;
                @WebClimb.performed -= m_Wrapper.m_GravityActionsCallbackInterface.OnWebClimb;
                @WebClimb.canceled -= m_Wrapper.m_GravityActionsCallbackInterface.OnWebClimb;
                @WebCancel.started -= m_Wrapper.m_GravityActionsCallbackInterface.OnWebCancel;
                @WebCancel.performed -= m_Wrapper.m_GravityActionsCallbackInterface.OnWebCancel;
                @WebCancel.canceled -= m_Wrapper.m_GravityActionsCallbackInterface.OnWebCancel;
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
                @WebShoot.started += instance.OnWebShoot;
                @WebShoot.performed += instance.OnWebShoot;
                @WebShoot.canceled += instance.OnWebShoot;
                @WebAim.started += instance.OnWebAim;
                @WebAim.performed += instance.OnWebAim;
                @WebAim.canceled += instance.OnWebAim;
                @WebClimb.started += instance.OnWebClimb;
                @WebClimb.performed += instance.OnWebClimb;
                @WebClimb.canceled += instance.OnWebClimb;
                @WebCancel.started += instance.OnWebCancel;
                @WebCancel.performed += instance.OnWebCancel;
                @WebCancel.canceled += instance.OnWebCancel;
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
        void OnWebShoot(InputAction.CallbackContext context);
        void OnWebAim(InputAction.CallbackContext context);
        void OnWebClimb(InputAction.CallbackContext context);
        void OnWebCancel(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
