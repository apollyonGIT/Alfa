using Battle.Chesses;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Battle
{
    public class OprSender : MonoBehaviour, IPointerClickHandler
    {
        public BattleSceneRoot root;

        //==================================================================================================

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            root.try_get_mouse_attach_cpn(eventData, out OprReciver reciver);
        }
    }
}

