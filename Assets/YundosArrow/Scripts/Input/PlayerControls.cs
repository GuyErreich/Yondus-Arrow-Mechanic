//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/YundosArrow/Scripts/Input/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace YundosArrow.Scripts.Input
{
    public partial class @PlayerControls : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Character"",
            ""id"": ""22c18a3e-0f00-4aa6-99e6-f239867fa204"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""97f12f86-fbce-4518-b93f-87eb7233cddd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""63c7b36c-89dc-49be-b3b0-679831f2fe05"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""dcf54d94-6ddf-473f-bd2e-a63c554ddd45"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""ea50ad31-2ced-4a6d-8193-1ebd5700ce3d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""4a672e3e-97df-4831-aea6-9d86be874888"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""16b43c7a-7559-4e38-a6ee-214cb64258df"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""895dc0da-1674-4ba5-ad85-913d573793cc"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b70e7218-1ce1-4d41-892a-c2ceb0e76600"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fe4feb3f-6d05-4410-a54f-48ca28b50688"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f967a8b4-6972-419a-a44e-23432ab001ff"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f4daad48-8094-4c15-8f51-a23c1c8ed555"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""241828fb-6d1b-4500-8a00-a394ec1164cf"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c168ad8c-ed05-4bea-b0d7-ae5d313cf69e"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1fbef26-f309-46fa-8aa1-01c526a69369"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""SlimeRepo"",
            ""id"": ""910484dc-c720-439c-80c8-9d68e3ce5eaf"",
            ""actions"": [
                {
                    ""name"": ""Purple"",
                    ""type"": ""Button"",
                    ""id"": ""91bdae57-be74-4ad2-9409-c55511c0c230"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Green"",
                    ""type"": ""Button"",
                    ""id"": ""403e65f4-b935-4ef5-ab9c-a91be7dc6bda"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e6f8e5f9-063b-4804-ad43-bd0d2a7a44e2"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Green"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b68d0564-4d32-4ad2-aad3-423b05154d82"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Misc"",
            ""id"": ""45fe62e9-d9cc-4c51-a44e-6f81dcd7bc08"",
            ""actions"": [
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""e3b5e07f-4c80-4447-af56-6a049a1595c6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0d713eb3-5685-446b-8cd2-94318340279f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Character
            m_Character = asset.FindActionMap("Character", throwIfNotFound: true);
            m_Character_Movement = m_Character.FindAction("Movement", throwIfNotFound: true);
            m_Character_Jump = m_Character.FindAction("Jump", throwIfNotFound: true);
            m_Character_Shoot = m_Character.FindAction("Shoot", throwIfNotFound: true);
            m_Character_Aim = m_Character.FindAction("Aim", throwIfNotFound: true);
            m_Character_Run = m_Character.FindAction("Run", throwIfNotFound: true);
            // SlimeRepo
            m_SlimeRepo = asset.FindActionMap("SlimeRepo", throwIfNotFound: true);
            m_SlimeRepo_Purple = m_SlimeRepo.FindAction("Purple", throwIfNotFound: true);
            m_SlimeRepo_Green = m_SlimeRepo.FindAction("Green", throwIfNotFound: true);
            // Misc
            m_Misc = asset.FindActionMap("Misc", throwIfNotFound: true);
            m_Misc_Menu = m_Misc.FindAction("Menu", throwIfNotFound: true);
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
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Character
        private readonly InputActionMap m_Character;
        private ICharacterActions m_CharacterActionsCallbackInterface;
        private readonly InputAction m_Character_Movement;
        private readonly InputAction m_Character_Jump;
        private readonly InputAction m_Character_Shoot;
        private readonly InputAction m_Character_Aim;
        private readonly InputAction m_Character_Run;
        public struct CharacterActions
        {
            private @PlayerControls m_Wrapper;
            public CharacterActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Character_Movement;
            public InputAction @Jump => m_Wrapper.m_Character_Jump;
            public InputAction @Shoot => m_Wrapper.m_Character_Shoot;
            public InputAction @Aim => m_Wrapper.m_Character_Aim;
            public InputAction @Run => m_Wrapper.m_Character_Run;
            public InputActionMap Get() { return m_Wrapper.m_Character; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
            public void SetCallbacks(ICharacterActions instance)
            {
                if (m_Wrapper.m_CharacterActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                    @Jump.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                    @Shoot.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnShoot;
                    @Shoot.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnShoot;
                    @Shoot.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnShoot;
                    @Aim.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAim;
                    @Aim.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAim;
                    @Aim.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAim;
                    @Run.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRun;
                    @Run.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRun;
                    @Run.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRun;
                }
                m_Wrapper.m_CharacterActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Shoot.started += instance.OnShoot;
                    @Shoot.performed += instance.OnShoot;
                    @Shoot.canceled += instance.OnShoot;
                    @Aim.started += instance.OnAim;
                    @Aim.performed += instance.OnAim;
                    @Aim.canceled += instance.OnAim;
                    @Run.started += instance.OnRun;
                    @Run.performed += instance.OnRun;
                    @Run.canceled += instance.OnRun;
                }
            }
        }
        public CharacterActions @Character => new CharacterActions(this);

        // SlimeRepo
        private readonly InputActionMap m_SlimeRepo;
        private ISlimeRepoActions m_SlimeRepoActionsCallbackInterface;
        private readonly InputAction m_SlimeRepo_Purple;
        private readonly InputAction m_SlimeRepo_Green;
        public struct SlimeRepoActions
        {
            private @PlayerControls m_Wrapper;
            public SlimeRepoActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Purple => m_Wrapper.m_SlimeRepo_Purple;
            public InputAction @Green => m_Wrapper.m_SlimeRepo_Green;
            public InputActionMap Get() { return m_Wrapper.m_SlimeRepo; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(SlimeRepoActions set) { return set.Get(); }
            public void SetCallbacks(ISlimeRepoActions instance)
            {
                if (m_Wrapper.m_SlimeRepoActionsCallbackInterface != null)
                {
                    @Purple.started -= m_Wrapper.m_SlimeRepoActionsCallbackInterface.OnPurple;
                    @Purple.performed -= m_Wrapper.m_SlimeRepoActionsCallbackInterface.OnPurple;
                    @Purple.canceled -= m_Wrapper.m_SlimeRepoActionsCallbackInterface.OnPurple;
                    @Green.started -= m_Wrapper.m_SlimeRepoActionsCallbackInterface.OnGreen;
                    @Green.performed -= m_Wrapper.m_SlimeRepoActionsCallbackInterface.OnGreen;
                    @Green.canceled -= m_Wrapper.m_SlimeRepoActionsCallbackInterface.OnGreen;
                }
                m_Wrapper.m_SlimeRepoActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Purple.started += instance.OnPurple;
                    @Purple.performed += instance.OnPurple;
                    @Purple.canceled += instance.OnPurple;
                    @Green.started += instance.OnGreen;
                    @Green.performed += instance.OnGreen;
                    @Green.canceled += instance.OnGreen;
                }
            }
        }
        public SlimeRepoActions @SlimeRepo => new SlimeRepoActions(this);

        // Misc
        private readonly InputActionMap m_Misc;
        private IMiscActions m_MiscActionsCallbackInterface;
        private readonly InputAction m_Misc_Menu;
        public struct MiscActions
        {
            private @PlayerControls m_Wrapper;
            public MiscActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Menu => m_Wrapper.m_Misc_Menu;
            public InputActionMap Get() { return m_Wrapper.m_Misc; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MiscActions set) { return set.Get(); }
            public void SetCallbacks(IMiscActions instance)
            {
                if (m_Wrapper.m_MiscActionsCallbackInterface != null)
                {
                    @Menu.started -= m_Wrapper.m_MiscActionsCallbackInterface.OnMenu;
                    @Menu.performed -= m_Wrapper.m_MiscActionsCallbackInterface.OnMenu;
                    @Menu.canceled -= m_Wrapper.m_MiscActionsCallbackInterface.OnMenu;
                }
                m_Wrapper.m_MiscActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Menu.started += instance.OnMenu;
                    @Menu.performed += instance.OnMenu;
                    @Menu.canceled += instance.OnMenu;
                }
            }
        }
        public MiscActions @Misc => new MiscActions(this);
        public interface ICharacterActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnShoot(InputAction.CallbackContext context);
            void OnAim(InputAction.CallbackContext context);
            void OnRun(InputAction.CallbackContext context);
        }
        public interface ISlimeRepoActions
        {
            void OnPurple(InputAction.CallbackContext context);
            void OnGreen(InputAction.CallbackContext context);
        }
        public interface IMiscActions
        {
            void OnMenu(InputAction.CallbackContext context);
        }
    }
}
