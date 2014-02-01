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
using ZoneFiveSoftware.Common.Data.Fitness;
using SvettigPlugin.SvettigService;

namespace SvettigPlugin
{
    public partial class SettingsControl : UserControl
    {

        public SettingsControl()
        {
            InitializeComponent();

            txtUsername.Text = Settings.Instance.UserEmail;
            txtPassword.Text = Settings.Instance.EncryptedPassword;

            Mappings();
        }

        void Mappings()
        {

            try
            {
                // Activity type mappings
                System.ServiceModel.BasicHttpBinding binding = new System.ServiceModel.BasicHttpBinding();
                WorkoutServiceClient client = new WorkoutServiceClient(binding,
                    new System.ServiceModel.EndpointAddress("http://www.jogg.se/SvettigWorkoutService/SvettigWorkoutService.WorkoutService.svc/soap"));
                Dictionary<string, object> svettigCategoryDict = client.GetWorkoutCategories(Settings.Instance.UserEmail, 
                                                                                    Settings.Instance.EncryptedPassword, 
                                                                                    SvettigPlugin.SvettigService.Application.SPORT_TRACKS_PLUGIN);
                object result;
                svettigCategoryDict.TryGetValue("result", out result);
                actMappingsFlowLayoutPanel.Controls.Clear();
                if (result == null)
                {
                    //if (result != null)
                    //{
                    //    //Create a default dictionary structure 
                    //    svettigCategoryDict.Clear();
                    //    Dictionary<string, object> subCatDict = new Dictionary<string, object>();
                    //    subCatDict.Add("Distans", 0);
                    //    Dictionary<string, object> CatDict = new Dictionary<string, object>();
                    //    CatDict.Add("löpning", 0);
                    //    CatDict.Add("subcategories", subCatDict);
                    //    svettigCategoryDict.Add("löpning", CatDict);
                    //}
                    // Get a dictionary (ref ID & name) with all ST categories
                    string[] keyList = new string[Settings.Instance.STCategoriesDict.Keys.Count];
                    Settings.Instance.STCategoriesDict.Keys.CopyTo(keyList, 0);
                    string[] valueList = new string[Settings.Instance.STCategoriesDict.Values.Count];
                    Settings.Instance.STCategoriesDict.Values.CopyTo(valueList, 0);

                    List<Control> amcs = new List<Control>();
                    for (int i = 0; i < valueList.Length; i++)
                    {
                        ActivityMappingControl amc = new ActivityMappingControl(keyList[i], valueList[i], svettigCategoryDict);
                        amcs.Add(amc);
                    }
                    actMappingsFlowLayoutPanel.Controls.AddRange(amcs.ToArray());
                }
                // Equipment mappings

                Dictionary<string, object> tempSvettigEqDict = client.GetEquipment(Settings.Instance.UserEmail,
                                                                                       Settings.Instance.EncryptedPassword,
                                                                                       SvettigPlugin.SvettigService.Application.SPORT_TRACKS_PLUGIN);
                
                // Parse the structure received from Svettig and create a simple dictionary id(int), name(string)
                Dictionary<int, string> svettigEqDict = new Dictionary<int, string>();
                svettigEqDict.Add(0, "none");
                tempSvettigEqDict.TryGetValue("result", out result);
                eqMappingsFlowLayoutPanel.Controls.Clear();
                if (result == null)
                {
                    if (result != null)
                    {
                        tempSvettigEqDict.Clear();
                    }
                    // Interpret the svettig dictionary structure and create a simple id, name dictionary
                    foreach (object entry in tempSvettigEqDict.Values)
                    {
                        Dictionary<string, object> catEqDict = (Dictionary<string, object>)entry;
                        foreach (object entry2 in catEqDict.Values)
                        {
                            Dictionary<string, object> eqDict = (Dictionary<string, object>)entry2;
                            object id;
                            object namn;
                            eqDict.TryGetValue("id", out id);
                            eqDict.TryGetValue("namn", out namn);
                            svettigEqDict.Add((int)id, (string)namn);
                        }
                    }
                    // Get a dictionary (ref ID & name) with all ST equipment
                    string[] keyList = new string[Settings.Instance.STEquipmentDict.Keys.Count];
                    Settings.Instance.STEquipmentDict.Keys.CopyTo(keyList, 0);
                    string[] valueList = new string[Settings.Instance.STEquipmentDict.Values.Count];
                    Settings.Instance.STEquipmentDict.Values.CopyTo(valueList, 0);

                    List<Control> amcs = new List<Control>();
                    for (int i = 0; i < valueList.Length; i++)
                    {
                        EquipmentMappingControl amc = new EquipmentMappingControl(keyList[i], valueList[i], svettigEqDict);
                        amcs.Add(amc);
                    }
                    eqMappingsFlowLayoutPanel.Controls.AddRange(amcs.ToArray());
                }
                equipmentMappingsGroupBox.Location = new Point(actMappingsGroupBox.Location.X,
                                                               actMappingsGroupBox.Location.Y + actMappingsGroupBox.Size.Height + 10);
            }
            catch (Exception ex)
            {
                TextBox ErrMessageBox = new TextBox();
                ErrMessageBox.Text = string.Concat("Failed to read training type mappings from Svettig.\r\nException message:\r\n",
                                                    ex.ToString());
                ErrMessageBox.Size = actMappingsFlowLayoutPanel.Size;
                ErrMessageBox.ReadOnly = true;
                ErrMessageBox.Multiline = true;
                actMappingsFlowLayoutPanel.Controls.Add(ErrMessageBox);
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            Settings.Instance.UserEmail = txtUsername.Text;
            Mappings();
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            Settings.Instance.EncryptedPassword = SvettigEncryption.SvettigEncryption.GetEncryptedPassword(Plugin.GetApplication(), txtPassword.Text);
            Mappings();
        }

    }
}
