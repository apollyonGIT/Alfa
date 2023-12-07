using Foundation;
using UnityEngine;

namespace Battle.Territorys
{
    public class Territory : Model<Territory, ITerritoryView>
    {
        public VID vid;

        public Vector2 view_pos => VID.convert(vid);

        //==================================================================================================


    }
}

