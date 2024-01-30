﻿using Common;
using Common.Ticker_Module;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Battle.Res_Cards
{
    public interface IRes_CardView : IModelView<Res_Card>
    {
        void notify_on_click();
    }


    public class Res_CardMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;
        int IMgr.priority => m_mgr_priority;
        readonly int m_mgr_priority;

        LinkedList<Res_Card> m_cells = new();
        LinkedList<Res_Card> m_selected_cells = new();

        public Vector2 node_pos => new(m_cells.Count * 40, 0);

        public Action add_cells_ac;

        //==================================================================================================

        public Res_CardMgr(string name, int priority, params object[] args)
        {
            m_mgr_name = name;
            m_mgr_priority = priority;

            (this as IMgr).init(args);
        }


        void IMgr.fini()
        {
            Mission.instance.detach_mgr(m_mgr_name);

            var ticker = Ticker.instance;
            {
                ticker.remove_tick(m_mgr_name);
            }
        }


        void IMgr.init(object[] args)
        {
            Mission.instance.attach_mgr(m_mgr_name, this);

            var ticker = Ticker.instance;
            {
                ticker.add_tick(m_mgr_priority, m_mgr_name, tick);
            }
        }


        void tick()
        {
            var bctx = BattleContext.instance;
            {
                bctx.res_cards_count = m_cells.Count;
                bctx.selected_res_cards_count = m_selected_cells.Count;
            }
        }


        bool IMgr.try_get_cell(out object cell, params object[] args)
        {
            throw new System.NotImplementedException();
        }


        public void add_cell(Res_Card cell)
        {
            m_cells.AddLast(cell);
        }


        public void remove_cell(Res_Card cell)
        {
            m_cells.Remove(cell);

            cell.destroy();
        }


        public void remove_cells()
        {
            foreach (var cell in m_cells)
            {
                cell.destroy();
            }

            m_cells.Clear();
        }


        public void play()
        {
            foreach (var cell in m_selected_cells)
            {
                remove_cell(cell);
            }
            m_selected_cells.Clear();
        }


        public void reset()
        {
            var temp = m_selected_cells.ToList();
            foreach (var cell in temp)
            {
                cell.select();
            }
            m_selected_cells.Clear();
        }


        public void change_selected_cells(Res_Card cell)
        {
            if (cell.is_selected)
                m_selected_cells.AddLast(cell);
            else
                m_selected_cells.Remove(cell);
        }


        public void add_cells()
        {
            add_cells_ac?.Invoke();
        }
    }
}

