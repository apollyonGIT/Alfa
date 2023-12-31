﻿using Foundation;
using UnityEngine;

namespace Battle.Chesses
{
    public class ChessView : MonoBehaviour, IChessView
    {
        Chess cell;

        //==================================================================================================

        void IModelView<Chess>.attach(Chess cell)
        {
            this.cell = cell;

            transform.localPosition = cell.view_pos;
        }


        void IModelView<Chess>.detach(Chess cell)
        {
            this.cell = null;
        }


        void IModelView<Chess>.shift(Chess old_cell, Chess new_cell)
        {
        }


        void IChessView.notify_on_tick1()
        {
            transform.localPosition = cell.view_pos;
        }
    }
}

