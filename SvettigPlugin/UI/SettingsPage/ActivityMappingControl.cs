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
    public partial class ActivityMappingControl : UserControl
    {
        private Dictionary<string, object> SvettigCategories;
        //        private ActivityTypeMapping ac;
        private void Init()
        {
            InitializeComponent();
            //cbFunbeatActivity.SelectedIndexChanged += new EventHandler(OnSelectedIndexChanged);
        }

        //public ActivityMappingControl()
        //{
        //    Init();
        //}
        public ActivityMappingControl(string STCategoryId, string STCategoryName, Dictionary<string, object> svettigCategories) 
        {
            //this.ac = ac;
            Init();
            SvettigCategories = svettigCategories; // Save the svettig categories dictionary for later use
            
            lblSTActivity.Tag = STCategoryId;
            lblSTActivity.Text = STCategoryName;
            
            int svettigCatId = Settings.Instance.GetSvettigWorkoutCat(STCategoryId);
            int svettigSubCatId = Settings.Instance.GetSvettigWorkoutSubcat(STCategoryId);

            SetCategoryComboboxes(svettigCategories, svettigCatId, svettigSubCatId, true);

            //cbSvettigCategory.DataSource = new List<string>(svettigEqDict.Keys);

            //for(int i = 0; i < svettigEqDict.Count; i++)
            //{
            //    Dictionary<string, object> entryValue = (Dictionary<string, object>)svettigEqDict.Values.ElementAt(i);
            //    int mainCatId = (int)entryValue.Values.ElementAt(0);
            //    //object mainCatId;
            //    //entryValue.TryGetValue(svettigEqDict.Keys.ElementAt(i), out mainCatId);

            //    if ((int)mainCatId == svettigCatId)
            //    {
            //        cbSvettigCategory.SelectedIndex = i;
            //        object subCat;
            //        entryValue.TryGetValue("subcategories", out subCat);
            //        Dictionary<string, object> subCatIdDict = (Dictionary<string, object>)subCat;
            //        cbSvettigSubcategory.DataSource = new List<string>(subCatIdDict.Keys);
            //        for (int j = 0; j < subCatIdDict.Count; j++)
            //        {
            //            if ((int)subCatIdDict.Values.ElementAt(j) == svettigSubCatId)
            //            {
            //                cbSvettigSubcategory.SelectedIndex = j;
            //                break;
            //            }
            //        }
            //        break;
            //    }
            //}
        }

        private void SetCategoryComboboxes(Dictionary<string, object> svettigCategories, int svettigCatId, int svettigSubCatId, bool setdatasource)
        {
            Settings.Instance.SetWorkoutCatMapping((string)lblSTActivity.Tag, svettigCatId);

            if (setdatasource)
                cbSvettigCategory.DataSource = new List<string>(svettigCategories.Keys);

            for(int i = 0; i < svettigCategories.Count; i++)
            {
                Dictionary<string, object> entryValue = (Dictionary<string, object>)svettigCategories.Values.ElementAt(i);
                int mainCatId = (int)entryValue.Values.ElementAt(0);
                //object mainCatId;
                //entryValue.TryGetValue(svettigEqDict.Keys.ElementAt(i), out mainCatId);

                if ((int)mainCatId == svettigCatId)
                {
                    cbSvettigCategory.SelectedIndex = i;
                    object subCat;
                    entryValue.TryGetValue("subcategories", out subCat);
                    Dictionary<string, object> subCatIdDict = (Dictionary<string, object>)subCat;
                    SetSubcategoryCombobox(subCatIdDict, svettigSubCatId, true);
                    //cbSvettigSubcategory.DataSource = new List<string>(subCatIdDict.Keys);
                    //for (int j = 0; j < subCatIdDict.Count; j++)
                    //{
                    //    if ((int)subCatIdDict.Values.ElementAt(j) == svettigSubCatId)
                    //    {
                    //        cbSvettigSubcategory.SelectedIndex = j;
                    //        break;
                    //    }
                    //}
                    break;
                }
            }
        }

        private void SetSubcategoryCombobox(Dictionary<string, object> subCatIdDict, int svettigSubCatId, bool setdatasource)
        {
            Settings.Instance.SetWorkoutSubCatMapping((string)lblSTActivity.Tag, svettigSubCatId);
            if (setdatasource)
                cbSvettigSubcategory.DataSource = new List<string>(subCatIdDict.Keys);
            for (int j = 0; j < subCatIdDict.Count; j++)
            {
                if ((int)subCatIdDict.Values.ElementAt(j) == svettigSubCatId)
                {
                    if(cbSvettigSubcategory.SelectedIndex != j)
                        cbSvettigSubcategory.SelectedIndex = j;
                    break;
                }
            }
        }

        private void cbSvettigCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, object> entryValue = (Dictionary<string, object>)SvettigCategories.Values.ElementAt(cbSvettigCategory.SelectedIndex);
            int mainCatId = (int)entryValue.Values.ElementAt(0);

            SetCategoryComboboxes(SvettigCategories, mainCatId, 0, false);
        }

        private void cbSvettigSubcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, object> entryValue = (Dictionary<string, object>)SvettigCategories.Values.ElementAt(cbSvettigCategory.SelectedIndex);
            object subCat;
            entryValue.TryGetValue("subcategories", out subCat);
            Dictionary<string, object> subCatIdDict = (Dictionary<string, object>)subCat;
            SetSubcategoryCombobox(subCatIdDict, (int)subCatIdDict.Values.ElementAt(cbSvettigSubcategory.SelectedIndex), false);
        }


        //void OnSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cbFunbeatActivity.SelectedItem != null)
        //    {
        //        this.ac.Funbeat = ((FunbeatService.FunbeatActivityType)cbFunbeatActivity.SelectedItem).Id;
        //    }
        //}
    }
}
