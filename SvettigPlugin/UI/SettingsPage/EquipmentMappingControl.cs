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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Linq;


namespace SvettigPlugin
{
    public partial class EquipmentMappingControl : UserControl
    {
        private Dictionary<int, string> SvettigEqDict;

        private void Init()
        {
            InitializeComponent();
        }

        public EquipmentMappingControl(string STEqId, string STEqName, Dictionary<int, string> svettigEqDict) 
        {
            //this.ac = ac;
            Init();
            SvettigEqDict = svettigEqDict; // Save the svettig categories dictionary for later use
            
            lblSTActivity.Tag = STEqId;
            lblSTActivity.Text = STEqName;
            
            int svettigEqId = Settings.Instance.GetSvettigEquipment(STEqId);

            SetEquipmentComboboxes(svettigEqDict, svettigEqId, true);
        }

        private void SetEquipmentComboboxes(Dictionary<int, string> svettigEqDict, int svettigEqId, bool setdatasource)
        {
            Settings.Instance.SetEquipmentMapping((string)lblSTActivity.Tag, svettigEqId);

            if (setdatasource)
                cbSvettigEqCategory.DataSource = new List<string>(svettigEqDict.Values);

            for(int i = 0; i < svettigEqDict.Count; i++)
            {
                int id = svettigEqDict.Keys.ElementAt(i);

                if (id == svettigEqId)
                {
                    cbSvettigEqCategory.SelectedIndex = i;
                    break;
                }
            }
        }

        private void cbSvettigEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedId = SvettigEqDict.Keys.ElementAt(cbSvettigEqCategory.SelectedIndex);

            SetEquipmentComboboxes(SvettigEqDict, selectedId, false);
        }
    }
}
