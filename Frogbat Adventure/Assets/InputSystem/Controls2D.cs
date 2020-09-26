// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/Controls2D.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls2D : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls2D()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls2D"",
    ""maps"": [
        {
            ""name"": ""BaseMovement"",
            ""id"": ""c5e2d4e6-7155-48cb-b9c0-5273b841c515"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""8a772880-584a-486c-8661-023263d00b97"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""f2259503-5781-4950-a56d-7cf819395c39"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drop_Through"",
                    ""type"": ""Button"",
                    ""id"": ""40bd6739-5840-4e04-998a-8577913a64d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""8599dcaa-f848-4f97-9a90-c2d95b43471f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9a74435b-6f06-4379-9c33-69fb28c1aed0"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""724a1de2-9ecd-4f3f-a0cf-1fe0e5cb3d45"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""887deac9-3c19-4221-89f2-4e2d8fe8bae3"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2582db63-cb07-4c76-9596-813190131d89"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""c406c754-5d4c-4d1d-bb82-9a2216bde3de"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop_Through"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""2526227a-6729-46f7-8b59-ba6f7ebbada2"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""Drop_Through"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""fb4c8ff3-0e1f-4ecc-917f-778e89e4772e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""Drop_Through"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c2d67d94-1978-4232-98c1-f9926ed56040"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ActionInputs"",
            ""id"": ""2060eff4-7a8b-4f2a-a912-8869b2316a58"",
            ""actions"": [
                {
                    ""name"": ""Action1"",
                    ""type"": ""Button"",
                    ""id"": ""229bcf52-8947-4f57-b2f3-1624044c295d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action2"",
                    ""type"": ""Button"",
                    ""id"": ""15ec2e95-4aed-4c88-a90a-c05fecaa54be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action3"",
                    ""type"": ""Button"",
                    ""id"": ""b2eb035e-b59f-4a54-bb47-fe543540e270"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LBumper"",
                    ""type"": ""Button"",
                    ""id"": ""32873960-6738-4a4c-b728-034b054ba509"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LTrigger"",
                    ""type"": ""Button"",
                    ""id"": ""9437e83c-8cf8-4085-bd0e-6ecb84f263e3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RBumper"",
                    ""type"": ""Button"",
                    ""id"": ""d99aff48-0376-41bb-a209-a340d87dce2c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RTrigger"",
                    ""type"": ""Button"",
                    ""id"": ""bc1d758c-85a5-462b-bdc3-f92201bdfb5e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""04a04f38-a30e-4048-85fa-f148bc99c360"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""Action1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""937e21ea-e814-4383-aa69-1834e26b4efa"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""Action2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a458c02-3e6d-42c4-b42b-58657b65b53e"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""Action3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f735056-185d-4527-84cf-626c3f158eee"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""LBumper"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""775b7ca6-d797-40d9-b822-99f03d60e4ad"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""LTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35728dc6-05d4-44ee-a84c-1747c236a2fe"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""RBumper"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30c65a58-f1e9-438b-a5f3-0009dfcc7059"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""RTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""4c17cf24-693a-4764-9f97-71fbda8ef3f2"",
            ""actions"": [
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""14893dfe-9bdb-406f-982b-3ffc36df63ed"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e2b286a1-8bb4-4632-ad85-273c4c3ba9d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c1da01dd-4c2a-44d0-92a0-542f1afbfab5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b9c92d43-4a2b-41d7-ae26-e20911db592e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a8389b8c-e395-492e-b1c2-22afd0bc2387"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e0e26d14-da96-4992-ab2d-bebf60df1dba"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0e753640-a7b5-49b1-90d6-1001fb7df441"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""04931af0-0c40-4221-842c-15008c4c065a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDevicePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bae6206b-eb97-4504-aa35-1fc66ed98aa7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDeviceOrientation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0736a717-84b6-44bb-b490-a03460392dad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""2166b40d-ce91-4bda-906d-a17f28a000e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ede51ffa-4149-41de-87cd-fa114adae207"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleDebug"",
                    ""type"": ""Button"",
                    ""id"": ""f512e690-3ba1-4e5a-8084-0104ef7b56c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchDebug"",
                    ""type"": ""Button"",
                    ""id"": ""dacd8bfa-6efc-4e5a-9a97-537db411c6f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""823884e9-703e-4416-b96c-136b549fc893"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""MiddleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a7e0c1f-c7ef-44c0-94fa-2f9f2a1eac82"",
                    ""path"": ""*/{Cancel}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff18ffb8-0fde-4584-a923-70c2c8f8cf67"",
                    ""path"": ""*/{Back}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd5d5aa3-21fa-4208-bb73-f4fd331fdfb3"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""ScrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a959920c-49a6-4684-9de3-dc6f378cb43c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b7639bfd-a70f-4b82-9e9d-e01511e94810"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""69af22fc-708a-434c-bdda-e608b3fc0345"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b77934dc-e4a5-4997-8cc6-898a1104d520"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a5bc83e1-daf0-40f6-aa06-797a28edf380"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4ea32b39-5b7a-45d0-bf61-ebcd30fe8c16"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5fb03fb7-5551-4d54-b163-96fbafce72fc"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e0100ad-172b-4b31-a5b7-4ab8c26df7a5"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""TrackedDevicePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfc7b5e9-7b3e-4f1f-adc3-78c18fc7f8dc"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""TrackedDeviceOrientation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31d57408-f37e-4ef5-8577-19f76c4716ab"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b51f1a12-ce8c-4815-98de-7fb2939817c5"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With Two Modifiers"",
                    ""id"": ""a6afce5c-3c19-4a8d-9434-0faf402bf7d4"",
                    ""path"": ""ButtonWithTwoModifiers"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleDebug"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier1"",
                    ""id"": ""ac459dc8-03b9-4502-a633-2c7ba4ab0929"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""ToggleDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""modifier2"",
                    ""id"": ""46fb7225-ce26-4f33-93a4-6b50ec9c80bb"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""ToggleDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""c3e9f783-21ca-4f7e-8258-058f623b1784"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""ToggleDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""NavigateLeft"",
                    ""id"": ""4324d3f3-c26b-420f-918f-25958d610d71"",
                    ""path"": ""ButtonWithTwoModifiers"",
                    ""interactions"": """",
                    ""processors"": ""Invert"",
                    ""groups"": """",
                    ""action"": ""SwitchDebug"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier1"",
                    ""id"": ""c3c626e6-7c04-4159-a1b3-cb69729e091b"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""SwitchDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""modifier2"",
                    ""id"": ""54d552d8-a491-430e-90ab-35784d4ffb67"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""SwitchDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""e00c3806-7d03-44d2-88ad-a5c2be7cadd4"",
                    ""path"": ""<Keyboard>/comma"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""SwitchDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""NavigateRIght"",
                    ""id"": ""b8f9cfce-2339-4769-b02f-cf71d93528c9"",
                    ""path"": ""ButtonWithTwoModifiers"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""SwitchDebug"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier1"",
                    ""id"": ""c76d2ebc-1d40-4245-99e6-a924267ff013"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""SwitchDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""modifier2"",
                    ""id"": ""dbed1474-7329-41f4-bf29-d94f7764e9af"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""SwitchDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""78a94e71-353d-4afe-a1df-ad1278a5b32b"",
                    ""path"": ""<Keyboard>/period"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardInputs"",
                    ""action"": ""SwitchDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d456c691-ec49-41e7-b6d2-d237ace7f8b8"",
                    ""path"": ""*/{Point}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6de2eeee-4d9a-46f6-baaf-6085c21721d0"",
                    ""path"": ""*/{Submit}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardInputs"",
            ""bindingGroup"": ""KeyboardInputs"",
            ""devices"": []
        }
    ]
}");
        // BaseMovement
        m_BaseMovement = asset.FindActionMap("BaseMovement", throwIfNotFound: true);
        m_BaseMovement_Movement = m_BaseMovement.FindAction("Movement", throwIfNotFound: true);
        m_BaseMovement_Jump = m_BaseMovement.FindAction("Jump", throwIfNotFound: true);
        m_BaseMovement_Drop_Through = m_BaseMovement.FindAction("Drop_Through", throwIfNotFound: true);
        // ActionInputs
        m_ActionInputs = asset.FindActionMap("ActionInputs", throwIfNotFound: true);
        m_ActionInputs_Action1 = m_ActionInputs.FindAction("Action1", throwIfNotFound: true);
        m_ActionInputs_Action2 = m_ActionInputs.FindAction("Action2", throwIfNotFound: true);
        m_ActionInputs_Action3 = m_ActionInputs.FindAction("Action3", throwIfNotFound: true);
        m_ActionInputs_LBumper = m_ActionInputs.FindAction("LBumper", throwIfNotFound: true);
        m_ActionInputs_LTrigger = m_ActionInputs.FindAction("LTrigger", throwIfNotFound: true);
        m_ActionInputs_RBumper = m_ActionInputs.FindAction("RBumper", throwIfNotFound: true);
        m_ActionInputs_RTrigger = m_ActionInputs.FindAction("RTrigger", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Point = m_UI.FindAction("Point", throwIfNotFound: true);
        m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
        m_UI_MiddleClick = m_UI.FindAction("MiddleClick", throwIfNotFound: true);
        m_UI_RightClick = m_UI.FindAction("RightClick", throwIfNotFound: true);
        m_UI_ScrollWheel = m_UI.FindAction("ScrollWheel", throwIfNotFound: true);
        m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
        m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
        m_UI_Cancel = m_UI.FindAction("Cancel", throwIfNotFound: true);
        m_UI_TrackedDevicePosition = m_UI.FindAction("TrackedDevicePosition", throwIfNotFound: true);
        m_UI_TrackedDeviceOrientation = m_UI.FindAction("TrackedDeviceOrientation", throwIfNotFound: true);
        m_UI_Menu = m_UI.FindAction("Menu", throwIfNotFound: true);
        m_UI_Select = m_UI.FindAction("Select", throwIfNotFound: true);
        m_UI_ToggleDebug = m_UI.FindAction("ToggleDebug", throwIfNotFound: true);
        m_UI_SwitchDebug = m_UI.FindAction("SwitchDebug", throwIfNotFound: true);
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

    // BaseMovement
    private readonly InputActionMap m_BaseMovement;
    private IBaseMovementActions m_BaseMovementActionsCallbackInterface;
    private readonly InputAction m_BaseMovement_Movement;
    private readonly InputAction m_BaseMovement_Jump;
    private readonly InputAction m_BaseMovement_Drop_Through;
    public struct BaseMovementActions
    {
        private @Controls2D m_Wrapper;
        public BaseMovementActions(@Controls2D wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_BaseMovement_Movement;
        public InputAction @Jump => m_Wrapper.m_BaseMovement_Jump;
        public InputAction @Drop_Through => m_Wrapper.m_BaseMovement_Drop_Through;
        public InputActionMap Get() { return m_Wrapper.m_BaseMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BaseMovementActions set) { return set.Get(); }
        public void SetCallbacks(IBaseMovementActions instance)
        {
            if (m_Wrapper.m_BaseMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_BaseMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_BaseMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_BaseMovementActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_BaseMovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_BaseMovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_BaseMovementActionsCallbackInterface.OnJump;
                @Drop_Through.started -= m_Wrapper.m_BaseMovementActionsCallbackInterface.OnDrop_Through;
                @Drop_Through.performed -= m_Wrapper.m_BaseMovementActionsCallbackInterface.OnDrop_Through;
                @Drop_Through.canceled -= m_Wrapper.m_BaseMovementActionsCallbackInterface.OnDrop_Through;
            }
            m_Wrapper.m_BaseMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Drop_Through.started += instance.OnDrop_Through;
                @Drop_Through.performed += instance.OnDrop_Through;
                @Drop_Through.canceled += instance.OnDrop_Through;
            }
        }
    }
    public BaseMovementActions @BaseMovement => new BaseMovementActions(this);

    // ActionInputs
    private readonly InputActionMap m_ActionInputs;
    private IActionInputsActions m_ActionInputsActionsCallbackInterface;
    private readonly InputAction m_ActionInputs_Action1;
    private readonly InputAction m_ActionInputs_Action2;
    private readonly InputAction m_ActionInputs_Action3;
    private readonly InputAction m_ActionInputs_LBumper;
    private readonly InputAction m_ActionInputs_LTrigger;
    private readonly InputAction m_ActionInputs_RBumper;
    private readonly InputAction m_ActionInputs_RTrigger;
    public struct ActionInputsActions
    {
        private @Controls2D m_Wrapper;
        public ActionInputsActions(@Controls2D wrapper) { m_Wrapper = wrapper; }
        public InputAction @Action1 => m_Wrapper.m_ActionInputs_Action1;
        public InputAction @Action2 => m_Wrapper.m_ActionInputs_Action2;
        public InputAction @Action3 => m_Wrapper.m_ActionInputs_Action3;
        public InputAction @LBumper => m_Wrapper.m_ActionInputs_LBumper;
        public InputAction @LTrigger => m_Wrapper.m_ActionInputs_LTrigger;
        public InputAction @RBumper => m_Wrapper.m_ActionInputs_RBumper;
        public InputAction @RTrigger => m_Wrapper.m_ActionInputs_RTrigger;
        public InputActionMap Get() { return m_Wrapper.m_ActionInputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionInputsActions set) { return set.Get(); }
        public void SetCallbacks(IActionInputsActions instance)
        {
            if (m_Wrapper.m_ActionInputsActionsCallbackInterface != null)
            {
                @Action1.started -= m_Wrapper.m_ActionInputsActionsCallbackInterface.OnAction1;
                @Action1.performed -= m_Wrapper.m_ActionInputsActionsCallbackInterface.OnAction1;
                @Action1.canceled -= m_Wrapper.m_ActionInputsActionsCallbackInterface.OnAction1;
                @Action2.started -= m_Wrapper.m_ActionInputsActionsCallbackInterface.OnAction2;
                @Action2.performed -= m_Wrapper.m_ActionInputsActionsCallbackInterface.OnAction2;
                @Action2.canceled -= m_Wrapper.m_ActionInputsActionsCallbackInterface.OnAction2;
                @Action3.started -= m_Wrapper.m_ActionInputsActionsCallbackInterface.OnAction3;
                @Action3.performed -= m_Wrapper.m_ActionInputsActionsCallbackInterface.OnAction3;
                @Action3.canceled -= m_Wrapper.m_ActionInputsActionsCallbackInterface.OnAction3;
                @LBumper.started -= m_Wrapper.m_ActionInputsActionsCallbackInterface.OnLBumper;
                @LBumper.performed -= m_Wrapper.m_ActionInputsActionsCallbackInterface.OnLBumper;
                @LBumper.canceled -= m_Wrapper.m_ActionInputsActionsCallbackInterface.OnLBumper;
                @LTrigger.started -= m_Wrapper.m_ActionInputsActionsCallbackInterface.OnLTrigger;
                @LTrigger.performed -= m_Wrapper.m_ActionInputsActionsCallbackInterface.OnLTrigger;
                @LTrigger.canceled -= m_Wrapper.m_ActionInputsActionsCallbackInterface.OnLTrigger;
                @RBumper.started -= m_Wrapper.m_ActionInputsActionsCallbackInterface.OnRBumper;
                @RBumper.performed -= m_Wrapper.m_ActionInputsActionsCallbackInterface.OnRBumper;
                @RBumper.canceled -= m_Wrapper.m_ActionInputsActionsCallbackInterface.OnRBumper;
                @RTrigger.started -= m_Wrapper.m_ActionInputsActionsCallbackInterface.OnRTrigger;
                @RTrigger.performed -= m_Wrapper.m_ActionInputsActionsCallbackInterface.OnRTrigger;
                @RTrigger.canceled -= m_Wrapper.m_ActionInputsActionsCallbackInterface.OnRTrigger;
            }
            m_Wrapper.m_ActionInputsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Action1.started += instance.OnAction1;
                @Action1.performed += instance.OnAction1;
                @Action1.canceled += instance.OnAction1;
                @Action2.started += instance.OnAction2;
                @Action2.performed += instance.OnAction2;
                @Action2.canceled += instance.OnAction2;
                @Action3.started += instance.OnAction3;
                @Action3.performed += instance.OnAction3;
                @Action3.canceled += instance.OnAction3;
                @LBumper.started += instance.OnLBumper;
                @LBumper.performed += instance.OnLBumper;
                @LBumper.canceled += instance.OnLBumper;
                @LTrigger.started += instance.OnLTrigger;
                @LTrigger.performed += instance.OnLTrigger;
                @LTrigger.canceled += instance.OnLTrigger;
                @RBumper.started += instance.OnRBumper;
                @RBumper.performed += instance.OnRBumper;
                @RBumper.canceled += instance.OnRBumper;
                @RTrigger.started += instance.OnRTrigger;
                @RTrigger.performed += instance.OnRTrigger;
                @RTrigger.canceled += instance.OnRTrigger;
            }
        }
    }
    public ActionInputsActions @ActionInputs => new ActionInputsActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Point;
    private readonly InputAction m_UI_Click;
    private readonly InputAction m_UI_MiddleClick;
    private readonly InputAction m_UI_RightClick;
    private readonly InputAction m_UI_ScrollWheel;
    private readonly InputAction m_UI_Navigate;
    private readonly InputAction m_UI_Submit;
    private readonly InputAction m_UI_Cancel;
    private readonly InputAction m_UI_TrackedDevicePosition;
    private readonly InputAction m_UI_TrackedDeviceOrientation;
    private readonly InputAction m_UI_Menu;
    private readonly InputAction m_UI_Select;
    private readonly InputAction m_UI_ToggleDebug;
    private readonly InputAction m_UI_SwitchDebug;
    public struct UIActions
    {
        private @Controls2D m_Wrapper;
        public UIActions(@Controls2D wrapper) { m_Wrapper = wrapper; }
        public InputAction @Point => m_Wrapper.m_UI_Point;
        public InputAction @Click => m_Wrapper.m_UI_Click;
        public InputAction @MiddleClick => m_Wrapper.m_UI_MiddleClick;
        public InputAction @RightClick => m_Wrapper.m_UI_RightClick;
        public InputAction @ScrollWheel => m_Wrapper.m_UI_ScrollWheel;
        public InputAction @Navigate => m_Wrapper.m_UI_Navigate;
        public InputAction @Submit => m_Wrapper.m_UI_Submit;
        public InputAction @Cancel => m_Wrapper.m_UI_Cancel;
        public InputAction @TrackedDevicePosition => m_Wrapper.m_UI_TrackedDevicePosition;
        public InputAction @TrackedDeviceOrientation => m_Wrapper.m_UI_TrackedDeviceOrientation;
        public InputAction @Menu => m_Wrapper.m_UI_Menu;
        public InputAction @Select => m_Wrapper.m_UI_Select;
        public InputAction @ToggleDebug => m_Wrapper.m_UI_ToggleDebug;
        public InputAction @SwitchDebug => m_Wrapper.m_UI_SwitchDebug;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Point.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Click.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @MiddleClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @RightClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @ScrollWheel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @Navigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Cancel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @TrackedDevicePosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDeviceOrientation.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                @Menu.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMenu;
                @Select.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSelect;
                @ToggleDebug.started -= m_Wrapper.m_UIActionsCallbackInterface.OnToggleDebug;
                @ToggleDebug.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnToggleDebug;
                @ToggleDebug.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnToggleDebug;
                @SwitchDebug.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSwitchDebug;
                @SwitchDebug.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSwitchDebug;
                @SwitchDebug.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSwitchDebug;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @MiddleClick.started += instance.OnMiddleClick;
                @MiddleClick.performed += instance.OnMiddleClick;
                @MiddleClick.canceled += instance.OnMiddleClick;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @ScrollWheel.started += instance.OnScrollWheel;
                @ScrollWheel.performed += instance.OnScrollWheel;
                @ScrollWheel.canceled += instance.OnScrollWheel;
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @TrackedDevicePosition.started += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled += instance.OnTrackedDevicePosition;
                @TrackedDeviceOrientation.started += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled += instance.OnTrackedDeviceOrientation;
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @ToggleDebug.started += instance.OnToggleDebug;
                @ToggleDebug.performed += instance.OnToggleDebug;
                @ToggleDebug.canceled += instance.OnToggleDebug;
                @SwitchDebug.started += instance.OnSwitchDebug;
                @SwitchDebug.performed += instance.OnSwitchDebug;
                @SwitchDebug.canceled += instance.OnSwitchDebug;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_KeyboardInputsSchemeIndex = -1;
    public InputControlScheme KeyboardInputsScheme
    {
        get
        {
            if (m_KeyboardInputsSchemeIndex == -1) m_KeyboardInputsSchemeIndex = asset.FindControlSchemeIndex("KeyboardInputs");
            return asset.controlSchemes[m_KeyboardInputsSchemeIndex];
        }
    }
    public interface IBaseMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDrop_Through(InputAction.CallbackContext context);
    }
    public interface IActionInputsActions
    {
        void OnAction1(InputAction.CallbackContext context);
        void OnAction2(InputAction.CallbackContext context);
        void OnAction3(InputAction.CallbackContext context);
        void OnLBumper(InputAction.CallbackContext context);
        void OnLTrigger(InputAction.CallbackContext context);
        void OnRBumper(InputAction.CallbackContext context);
        void OnRTrigger(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnPoint(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnMiddleClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnScrollWheel(InputAction.CallbackContext context);
        void OnNavigate(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnTrackedDevicePosition(InputAction.CallbackContext context);
        void OnTrackedDeviceOrientation(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnToggleDebug(InputAction.CallbackContext context);
        void OnSwitchDebug(InputAction.CallbackContext context);
    }
}
