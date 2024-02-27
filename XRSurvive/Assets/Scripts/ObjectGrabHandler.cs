// using Oculus.Interaction.Grab;
// using Oculus.Interaction.GrabAPI;
// using Oculus.Interaction.Input;
// using Oculus.Interaction.Throw;
// using System;
// using UnityEngine;

// namespace Oculus.Interaction.HandGrab
// {
//     public class ObjectGrabHandler : MonoBehaviour
//     {
//         public HandGrabInteractor handGrabInteractor;
//         public HandGrabInteractable interactable;

//         private void Start()
//         {
//             // handGrabInteractor = GetComponent<HandGrabInteractor>();

//             // if (handGrabInteractor != null)
//             // {
//             //     handGrabInteractor.onSelectEnter.AddListener(OnGrabBegin);
//             //     handGrabInteractor.onSelectExit.AddListener(OnGrabEnd);
//             // }
//         }

//         void Update()
//         {
//             // Debug.Log(handGrabInteractor.IsGrabbing);
//             // DebugCanvasController.ShowDebugMessage(interactable.name);
//             // DebugCanvasController.ShowDebugMessage(handGrabInteractor.IsGrabbing);
//             DebugCanvasController.ShowDebugMessage(handGrabInteractor.HandGrabTarget.name);
//         }

//         // private void OnGrabBegin()
//         // {
//         //     Debug.Log("Object grabbed!");
//         //     // Trigger your custom event or function here
//         // }

//         // private void OnGrabEnd()
//         // {
//         //     Debug.Log("Object released!");
//         //     // Trigger your custom event or function here
//         // }
//     }
// }