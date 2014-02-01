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

namespace SvettigPlugin
{
    public class SettingsPageExtender : ZoneFiveSoftware.Common.Visuals.Fitness.IExtendSettingsPages
    {
        #region IExtendSettingsPages Members

        public IList<ZoneFiveSoftware.Common.Visuals.ISettingsPage> SettingsPages
        {
            get
            {
                List<ISettingsPage> pageList = new List<ISettingsPage>();
                pageList.Add(new SettingsPage());
                return pageList;
            }
        }

        #endregion
    }

    public class SettingsPage : ISettingsPage
    {
        #region ISettingsPage Members

        public Guid Id
        {
            get { return new Guid("{A9B09D4A-5CFA-4187-99E7-00A21E1AA121}"); }
        }

        public IList<ISettingsPage> SubPages
        {
            get { return null; }
        }

        #endregion

        #region IDialogPage Members

        public System.Windows.Forms.Control CreatePageControl()
        {
            return new SettingsControl();
        }

        public bool HidePage()
        {
            return true;
        }

        public string PageName
        {
            get { return "Svettig"; }
        }

        public void ShowPage(string bookmark)
        {
            //NOOP
        }

        public IPageStatus Status
        {
            get { return null; }
        }

        public void ThemeChanged(ITheme visualTheme)
        {
            //NOOP
        }

        public string Title
        {
            get { return "Svettig plugin settings"; }
        }

        public void UICultureChanged(System.Globalization.CultureInfo culture)
        {
            //NOOP
        }

        #endregion

        #region INotifyPropertyChanged Members

#pragma warning disable 67
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        #endregion
    }

}
