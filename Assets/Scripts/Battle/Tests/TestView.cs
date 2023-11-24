using Foundation;
using UnityEngine;

namespace Battle.Tests
{
    public class TestView : MonoBehaviour, ITestView
    {
        Test cell;

        //==================================================================================================

        void IModelView<Test>.attach(Test cell)
        {
            this.cell = cell;
        }


        void IModelView<Test>.detach(Test cell)
        {
            this.cell = null;
        }


        void IModelView<Test>.shift(Test old_cell, Test new_cell)
        {
        }
    }
}

