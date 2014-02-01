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
using System.Xml;
using System.ComponentModel;
using ZoneFiveSoftware.Common.Visuals.Fitness;

namespace SvettigPlugin
{
    class Plugin:IPlugin
    {
        public static FitnessDataHandler dataHandler = null;
        private PropertyChangedEventHandler appEventHandler = null;
        string logBookLocation = null;

        #region IPlugin Members

        private static IApplication application;
        public IApplication Application
        {
            set 
            { 
                application = value;
                if (appEventHandler == null)
                {
                    appEventHandler = new PropertyChangedEventHandler(OnApplicationChanged);
                    application.PropertyChanged += appEventHandler;
                }
            }
        }

        public Guid Id
        {
            get { return new Guid(Properties.Resources.Guid); }
        }

        public string Name
        {
            get { return "Svettig Plugin"; }
        }

        public void ReadOptions(XmlDocument xmlDoc, XmlNamespaceManager nsmgr, XmlElement pluginNode)
        {
            Settings.PopulateInstance(pluginNode, nsmgr, xmlDoc);
        }

        public string Version
        {
            get { return GetType().Assembly.GetName().Version.ToString(3); }
        }

        public void WriteOptions(XmlDocument xmlDoc, XmlElement pluginNode)
        {
            Settings.WriteInstance(xmlDoc, pluginNode);
        }

        #endregion

        public static IApplication GetApplication()
        {
            return application;
        }
        
        private void OnApplicationChanged(object sender, PropertyChangedEventArgs e)
        {
            // Check for changed logbook. If changed, call datahandler to check for custom data fields
            if (application.Logbook != null)
            {
                if (application.Logbook.FileLocation != logBookLocation)
                {
                    Guid PluginId = new Guid(Properties.Resources.Guid);
                    logBookLocation = application.Logbook.FileLocation;
                    if (dataHandler == null)
                        dataHandler = new FitnessDataHandler(application.Logbook, PluginId);
                    else
                    {
                        dataHandler.CheckCustomDataFields(application.Logbook, PluginId);
                    }
                }
            }
        }
    }
}
