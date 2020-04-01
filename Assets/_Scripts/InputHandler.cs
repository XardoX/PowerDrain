using UnityEngine;
using NaughtyAttributes;

public class InputHandler : MonoBehaviour
{
    #region Data
        [Space,Header("Input Data")]
        [SerializeField] private InteractionInputData interactionInputData = null;
    #endregion

    #region BuiltIn Methods
        void Start()
        {
            interactionInputData.ResetInput();
        }

        void Update()
        {
            GetInteractionInputData();
        }
    #endregion

    #region Custom Methods
        void GetInteractionInputData()
        {
            interactionInputData.InteractedClicked = Input.GetKeyDown(KeyCode.E);
            interactionInputData.InteractedReleased = Input.GetKeyUp(KeyCode.E);
        }
    #endregion
}

