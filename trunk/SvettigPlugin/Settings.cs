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
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using ZoneFiveSoftware.Common.Data.Fitness;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Diagnostics;
using Newtonsoft.Json;

namespace SvettigPlugin
{
    public delegate void ExtSettingsChangeHandler(object sender, EventArgs e);
    
    [Serializable]
    public class Settings
    {
        public int Version { get; private set; }
        private ILogbook logBook;

        // An event that clients can use to be notified whenever the
        // settings change due to an external event (changed logbook etc)
        public event ExtSettingsChangeHandler ExtSettingsChangeEvent;

        private static Settings instance;
        public static Settings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Settings();
                }
                return instance;
            }
        }


        private Settings()
        {
            Version = 1;
            Plugin.GetApplication().PropertyChanged += new PropertyChangedEventHandler(ApplicationChangedEventHandler);
            logBook = Plugin.GetApplication().Logbook;

            stCategoriesDict = new Dictionary<string, string>();
            ActivityCatMappings = new Dictionary<string, int>();
            ActivitySubcatMappings = new Dictionary<string, int>();
            stEquipmentDict = new Dictionary<string, string>();
            EquipmentMappings = new Dictionary<string, int>();
        }

        public string UserEmail { get; set; }

        public string EncryptedPassword { get; set; }

        public bool ExportToHiddenComment { get; set; }

        // Type mappings ST category id (string) to Svettig category id (int)
        private Dictionary<string, string> stCategoriesDict;
        public Dictionary<string, string> STCategoriesDict
        { 
            get
            {
                return stCategoriesDict;
            }
        }

        private Dictionary<string, int> ActivityCatMappings;
        public int GetSvettigWorkoutCat(string STActivityCat)
        {
            int workoutCat;
            bool ret = ActivityCatMappings.TryGetValue(STActivityCat, out workoutCat);
            return workoutCat;
        }

        private Dictionary<string, int> ActivitySubcatMappings;
        public int GetSvettigWorkoutSubcat(string STActivityCat)
        {
            int workoutCat;
            bool ret = ActivitySubcatMappings.TryGetValue(STActivityCat, out workoutCat);
            return workoutCat;
        }

        public void SetWorkoutCatMapping(string STId, int svettigMainCat)
        {
            ActivityCatMappings.Remove(STId);
            ActivityCatMappings.Add(STId, svettigMainCat);
        }

        public void SetWorkoutSubCatMapping(string STId, int svettigSubCat)
        {
            ActivitySubcatMappings.Remove(STId);
            ActivitySubcatMappings.Add(STId, svettigSubCat);
        }

        // Equipment mappings ST eq (string) to Svettig id (int)
        private Dictionary<string, string> stEquipmentDict;
        public Dictionary<string, string> STEquipmentDict
        {
            get
            {
                return stEquipmentDict;
            }
        }

        private Dictionary<string, int> EquipmentMappings;
        public int GetSvettigEquipment(string STEq)
        {
            int eq;
            bool ret = EquipmentMappings.TryGetValue(STEq, out eq);
            return eq;
        }

        public void SetEquipmentMapping(string STId, int svettigId)
        {
            EquipmentMappings.Remove(STId);
            EquipmentMappings.Add(STId, svettigId);
        }

        internal static void PopulateInstance(System.Xml.XmlElement pluginNode, XmlNamespaceManager nsmgr, XmlDocument xmlDoc)
        {
            instance = new Settings();
        }

        internal static void WriteInstance(XmlDocument xmlDoc, XmlElement pluginNode)
        {
        }

        private static void FlattenSportTrackActivityTypes(Dictionary<string, string> list, IActivityCategory category)
        {
            list.Add(category.ReferenceId, category.Name);
            foreach (IActivityCategory sub in category.SubCategories)
            {
                FlattenSportTrackActivityTypes(list, sub);
            }
        }

        private bool ReadFromLogbookMetaData(string tag, out string jsonData)
        {
            if (logBook.Metadata.Source.Contains(tag))
            {
                int startindex = logBook.Metadata.Source.IndexOf(tag);
                startindex = logBook.Metadata.Source.IndexOfAny(new char[] {'{','"'}, startindex);
                int endindex = logBook.Metadata.Source.IndexOf("\n", startindex);
                jsonData = logBook.Metadata.Source.Substring(startindex, endindex - startindex);
                return true;
            }
            else
            {
                jsonData = null;
                return false;
            }
        }

        private void ReadLogbookUserInfo()
        {
            string jsonString;

            //Read stored mappings from logbook here
            if (ReadFromLogbookMetaData("UserEmail", out jsonString))
            {
                UserEmail =
                    JsonConvert.DeserializeObject<string>(jsonString);
            }

            if (ReadFromLogbookMetaData("EncryptedPassword", out jsonString))
            {
                EncryptedPassword =
                    JsonConvert.DeserializeObject<string>(jsonString);
            }
        }

        private void ReadLogbookExportToHiddenComment()
        {
            string jsonString;

            if (ReadFromLogbookMetaData("ExportToHiddenComment", out jsonString))
            {
                ExportToHiddenComment =
                    JsonConvert.DeserializeObject<bool>(jsonString);
            }

        }

        private void ReadLogbookActivityCatMappings()
        {
            string jsonString;
            
            //Read stored mappings from logbook here
            Dictionary<string, int> tempActivityCatMappings = new Dictionary<string, int>();
            Dictionary<string, int> tempActivitySubcatMappings = new Dictionary<string, int>();
            if (ReadFromLogbookMetaData("SvettigPluginActCatMappings", out jsonString))
            {
                tempActivityCatMappings =
                    JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonString);
            }
            if (ReadFromLogbookMetaData("SvettigPluginActSubcatMappings", out jsonString))
            {
                tempActivitySubcatMappings =
                    JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonString);
            }

            // Recreate mappings based on current logbook categories
            ActivityCatMappings.Clear();
            ActivitySubcatMappings.Clear();
            foreach (KeyValuePair<string, string> entry in stCategoriesDict)
            {
                // Create default mapping for each ST category
                int tempCat;
                tempActivityCatMappings.TryGetValue(entry.Key, out tempCat);
                ActivityCatMappings.Add(entry.Key, tempCat);
                tempActivitySubcatMappings.TryGetValue(entry.Key, out tempCat);
                ActivitySubcatMappings.Add(entry.Key, tempCat);
            }
        }
        
        private void ReadLogbookEquipmentMappings()
        {
            string jsonString;

            //Read stored mappings from logbook here
            Dictionary<string, int> tempEquipmentMappings = new Dictionary<string, int>();
            if (ReadFromLogbookMetaData("SvettigPluginEquipmentMappings", out jsonString))
            {
                tempEquipmentMappings =
                    JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonString);
            }
            
            // Recreate mappings based on current logbook categories
            EquipmentMappings.Clear();
            foreach (KeyValuePair<string, string> entry in stEquipmentDict)
            {
                // Create default mapping for each ST category
                int tempEq;
                tempEquipmentMappings.TryGetValue(entry.Key, out tempEq);
                EquipmentMappings.Add(entry.Key, tempEq);
            }
        }

        private void ApplicationChangedEventHandler(object obj, PropertyChangedEventArgs args)
        {
            if ( args.PropertyName.Equals("Logbook"))
            {
                logBook = Plugin.GetApplication().Logbook;
                logBook.BeforeSave += new EventHandler(LogbookBeforeSaveEventHandler);

                // Create a dictionary (ref ID & name) with all ST categories
                stCategoriesDict.Clear();
                foreach (IActivityCategory cat in logBook.ActivityCategories)
                    FlattenSportTrackActivityTypes(stCategoriesDict, cat);

                // Create a dictionary (ref ID & name) with all ST equipment
                stEquipmentDict.Clear();
                foreach (IEquipmentItem eq in logBook.Equipment)
                    stEquipmentDict.Add(eq.ReferenceId, eq.Name);

                try
                {
                    ReadLogbookUserInfo();
                    ReadLogbookExportToHiddenComment();
                    ReadLogbookActivityCatMappings();
                    ReadLogbookEquipmentMappings();
                }
                catch
                {
                    // Incorrect values caused exception. Continue with default values on remaining settings
                }

                if (ExtSettingsChangeEvent != null)
                {
                    ExtSettingsChangeEvent(this, EventArgs.Empty);
                }
            }
        }

        private void StoreToLogbookMetadata(string tag, string jsondata)
        {
            string newString = tag + " = " + jsondata + "\n";

            if (logBook.Metadata.Source.Contains(tag))
            {
                int startindex = logBook.Metadata.Source.IndexOf(tag);
                int endindex = logBook.Metadata.Source.IndexOf("\n", startindex);
                if (!newString.Equals(logBook.Metadata.Source.Substring(startindex, endindex - startindex + 1)))
                {
                    // If the json string has changed, replace the old with the new!
                    logBook.Metadata.Source = logBook.Metadata.Source.Replace(logBook.Metadata.Source.Substring(startindex, endindex - startindex + 1),
                                                                              newString);
                }
            }
            else
            {
                logBook.Metadata.Source += newString;
            }
        }
        
        private void LogbookBeforeSaveEventHandler(object obj, EventArgs args)
        {
            string serUserEmail = JsonConvert.SerializeObject(UserEmail);
            StoreToLogbookMetadata("UserEmail", serUserEmail);

            string serEncryptedPassword = JsonConvert.SerializeObject(EncryptedPassword);
            StoreToLogbookMetadata("EncryptedPassword", serEncryptedPassword);

            string serExportToHiddenComment = JsonConvert.SerializeObject(ExportToHiddenComment);
            StoreToLogbookMetadata("ExportToHiddenComment", serExportToHiddenComment);

            string serActivityCatMappings = JsonConvert.SerializeObject(ActivityCatMappings);
            StoreToLogbookMetadata("SvettigPluginActCatMappings", serActivityCatMappings);
            
            string serActivitySubcatMappings = JsonConvert.SerializeObject(ActivitySubcatMappings);
            StoreToLogbookMetadata("SvettigPluginActSubcatMappings", serActivitySubcatMappings);

            string serEquipmentMappings = JsonConvert.SerializeObject(EquipmentMappings);
            StoreToLogbookMetadata("SvettigPluginEquipmentMappings", serEquipmentMappings);
        }
    }
}
