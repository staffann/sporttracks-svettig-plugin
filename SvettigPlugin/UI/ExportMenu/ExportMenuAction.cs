/*
Copyright (C) 2014 Staffan Nilsson

This library is free software; you can redistribute it and/or
modify it under the terms of the GNU Lesser General Public
License as published by the Free Software Foundation; either
version 3 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public
License along with this library. If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Text;
using ZoneFiveSoftware.Common.Visuals;
using ZoneFiveSoftware.Common.Visuals.Fitness;
using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Visuals.Util;

namespace SvettigPlugin
{
    class ExportMenuActionExtender:IExtendDailyActivityViewActions, IExtendActivityReportsViewActions
    {
        #region IExtendDailyActivityViewActions Members

        public IList<ZoneFiveSoftware.Common.Visuals.IAction> GetActions(IDailyActivityView view, ExtendViewActions.Location location)
        {
            if (location == ExtendViewActions.Location.ExportMenu)
            {
                return new IAction[] { new ExportMenuAction(view) };
            }
            else return new IAction[0];
        }

        #endregion

        #region IExtendActivityReportsViewActions Members

        public IList<ZoneFiveSoftware.Common.Visuals.IAction> GetActions(IActivityReportsView view, ExtendViewActions.Location location)
        {
            if (location == ExtendViewActions.Location.ExportMenu)
            {
                return new IAction[] { new ExportMenuAction(view) };
            }
            else return new IAction[0];
        }

        #endregion
    }

    class ExportMenuAction : IAction
    {
        #region IAction Members

        ISelectionProvider sel;
        IDailyActivityView dailyView = null;
        IActivityReportsView actReportView = null;

        public ExportMenuAction(IDailyActivityView dailyView)
        {
            this.dailyView = dailyView;
            sel = dailyView.SelectionProvider;
        }

        public ExportMenuAction(IActivityReportsView actReportView)
        {
            this.actReportView = actReportView;
            sel = actReportView.SelectionProvider;
        }

        public bool Enabled
        {
            get
            {
                IList<IActivity> activities = CollectionUtils.GetAllContainedItemsOfType<IActivity>(sel.SelectedItems);
                return(activities.Count > 0);
            }
        }

        public bool HasMenuArrow
        {
            get { return false; }
        }

        public System.Drawing.Image Image
        {
            get { return Properties.Resources.SvettigIcon; }
        }

        public IList<string> MenuPath
        {
            get { return null; }
        }

        public void Refresh()
        {
            
        }

        public void Run(System.Drawing.Rectangle rectButton)
        {
            // Implement functionality here
            IList<IActivity> activities = CollectionUtils.GetAllContainedItemsOfType<IActivity>(sel.SelectedItems);
            Export.boExport(activities);
        }

        public string Title
        {
            get { return ("Svettig"); ; }
        }

        public bool Visible
        {
            get { return(true); }
        }

        #endregion

        #region INotifyPropertyChanged Members

#pragma warning disable 67
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
