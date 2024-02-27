using Foundation;
using Common;
using TMPro;

namespace Battle.Trigrams
{
    public class TrigramView : View, ITrigramView
    {
        public TextMeshProUGUI desc;

        Trigram cell;

        public override object vmgr => cell.mgr;
        public override object vcell => cell;

        //==================================================================================================

        void IModelView<Trigram>.attach(Trigram cell)
        {
            this.cell = cell;

            transform.localRotation = cell.dir;
            transform.localPosition = cell.pos;
            desc.text = cell._desc.f_name;
        }


        void IModelView<Trigram>.detach(Trigram cell)
        {
            this.cell = null;
        }
    }
}

