using Common;
using Foundation;
using UnityEngine;
using static AutoCode.Tables.BehaviourOption;

namespace Battle.Behaviour_Options
{
    public class Behaviour_Option : Model<Behaviour_Option, ISelectorView>, ISkillMono
    {
        public Record _desc;

        public Behaviour_OptionMgr mgr;

        uint ISkillMono.id => _desc.f_id;

        //==================================================================================================

        public Behaviour_Option(Behaviour_OptionMgr mgr,  params object[] args)
        {
            this.mgr = mgr;

            var id = (uint)args[0];
            Battle_DB.instance.behaviour_option.try_get(id, out _desc);
        }


        internal void tick()
        {
        }


        internal void tick1()
        {
            foreach (var view in views)
            {
                view.notify_on_tick1();
            }
        }


        public virtual void init()
        { 
        }


        public virtual void on_click()
        {
            mgr.reset();

            foreach (var view in views)
            {
                view.notify_on_select();
            }

            Mission.instance.try_get_mgr("SkillMgr", out var skill_mgr);
            skill_mgr.GetType().GetMethod("load")?.Invoke(skill_mgr, new object[] { this });
        }


        public virtual void on_cancel()
        {
            foreach (var view in views)
            {
                view.notify_on_cancel();
            }
        }
    }
}

