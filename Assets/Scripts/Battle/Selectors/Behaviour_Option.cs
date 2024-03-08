﻿using Common;
using Foundation;
using static AutoCode.Tables.BehaviourOption;

namespace Battle.Behaviour_Options
{
    public class Behaviour_Option : Model<Behaviour_Option, ISelectorView>, ISkillMono
    {
        public Record _desc;
        public Behaviour_OptionMgr mgr;

        uint ISkillMono.id => m_skill_id;
        object ISkillMono.exec_method_obj => m_exec_method_obj;

        protected uint m_skill_id;
        protected object m_exec_method_obj;

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
            m_skill_id = _desc.f_id;
            m_exec_method_obj = this;
        }


        public virtual void on_left_click()
        {
            mgr.reset();

            foreach (var view in views)
            {
                view.notify_on_select();
            }

            Mission.instance.try_get_mgr("SkillMgr", out Skills.SkillMgr skill_mgr);
            skill_mgr.load(this);
        }


        public virtual void on_right_click()
        {
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

