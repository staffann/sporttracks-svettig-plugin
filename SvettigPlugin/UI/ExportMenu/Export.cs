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
using System.ServiceModel.Description;
using ZoneFiveSoftware.Common.Data.Fitness;
using SvettigEncryption;
using SvettigPlugin.SvettigService;

//using Newtonsoft.Json;
//using System.IO;

namespace SvettigPlugin
{
    static public class Export
    {
        static public bool boExport(IList<IActivity> activities)
        {
            FitnessDataHandler dataHandler = Plugin.dataHandler;

            foreach (IActivity activity in activities)
            {
                bool okToExport = !dataHandler.boGetSvettigExported(activity);
                if (!okToExport)
                    okToExport = MessageBox.Show("Already exported once. The workout must be manually deleted from the website before attempting a new export. Export again?", "Re-Export", MessageBoxButtons.YesNo) == DialogResult.Yes;

                if (okToExport)
                {
                    try
                    {
                        string name;
                        DateTime startDate;
                        bool hasStartTime;
                        TimeSpan duration;
                        float? TE;
                        int? cadenceAvg;
                        float? distance;
                        string comment;
                        int? hrAvg;
                        int? hrMax;
                        int? intensity;
                        int? kcal;
                        string privateComment;
                        int? repetitions;
                        int? sets;

                        dataHandler.GetExportData(activity,
                            false,
                            out name,
                            out startDate,
                            out hasStartTime,
                            out duration,
                            out TE,
                            out cadenceAvg,
                            out distance,
                            out comment,
                            out hrAvg,
                            out hrMax,
                            out intensity,
                            out kcal,
                            out privateComment,
                            out repetitions,
                            out sets
                            );

                        Workout workout = new Workout();
                        workout.application = (int)SvettigPlugin.SvettigService.Application.SPORT_TRACKS_PLUGIN;
                        workout.email = Settings.Instance.UserEmail;
                        workout.encryptedPassword = Settings.Instance.EncryptedPassword;

                        workout.created = startDate.ToString("yyyy-MM-dd HH:mm:ss:fff"); //2014-01-09 16:05:00:000;
                        workout.name = name;

                        workout.workoutCategory = Settings.Instance.GetSvettigWorkoutCat(activity.Category.ReferenceId);
                        workout.workoutSubcategory = Settings.Instance.GetSvettigWorkoutSubcat(activity.Category.ReferenceId);

                        foreach (IEquipmentItem eq in activity.EquipmentUsed)
                        {
                            int id = Settings.Instance.GetSvettigEquipment(eq.ReferenceId);
                            if (id != 0) // Equipment is mapped to an item at Svettig
                            {
                                workout.equipmentId = id;
                            }
                        }
                        
                        workout.timeInSeconds = (float)duration.TotalSeconds;

                        //workout.maxPulseSpecified = (hrMax != null);
                        workout.maxPulse = (hrMax != null) ? hrMax.Value : 0;

                        //workout.avgPulseSpecified = (hrAvg != null);
                        workout.avgPulse = (hrAvg != null) ? hrAvg.Value : 0;

                        //workout.distanceInMetersSpecified = (distance != null);
                        workout.distanceInMeters = (distance != null) ? distance.Value * 1000 : 0;

                        //workout.borgValueSpecified = (intensity != null);
                        workout.borgValue = (intensity != null) ? intensity.Value : 0;

                        workout.comment = comment;
                        workout.hiddenComment = privateComment;

                        workout.tracksegments = dataHandler.GetSvettigLaps(activity);


                        System.ServiceModel.BasicHttpBinding binding = new System.ServiceModel.BasicHttpBinding();
//                        binding.MaxBufferSize = Int32.MaxValue;
//                        binding.MaxBufferPoolSize = binding.MaxBufferSize;
//                        binding.MaxReceivedMessageSize = binding.MaxBufferSize;

                        // Debug code to write the workout contents to file
                        //string serWorkout = JsonConvert.SerializeObject(workout);
                        //using (StreamWriter writer = new StreamWriter("workout.txt"))
                        //{
                        //    writer.WriteLine(serWorkout);
                        //}
                        
                        WorkoutServiceClient client = new WorkoutServiceClient(binding,
                            new System.ServiceModel.EndpointAddress("http://www.jogg.se/SvettigWorkoutService/SvettigWorkoutService.WorkoutService.svc/soap"));
                        
                        // Modify the MaxItemsInObjectGraph behaviour in order to allow serialization of large lists
                        foreach (OperationDescription operationDescription in client.Endpoint.Contract.Operations)
                        {
                            DataContractSerializerOperationBehavior dcsob =
                                operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();
                            if (dcsob != null)
                            {
                                dcsob.MaxItemsInObjectGraph = int.MaxValue;
                            }
                        }
                        
                        Dictionary<string, object> resultDict = client.SyncWorkout(workout);
                        object result;
                        resultDict.TryGetValue("result", out result);
                        switch ((int)result)
                        {
                            case 0:
                                dataHandler.SetSvettigExported(activity, true);
                                break;
                            case 1:
                                MessageBox.Show("Empty email address");
                                break;
                            case 2:
                                MessageBox.Show("Incorrect email address or password");
                                break;
                            case 3:
                                MessageBox.Show("The user is blocked");
                                break;
                            case 4:
                                MessageBox.Show("Operation failed");
                                break;
                            case 5:
                                MessageBox.Show("Workout already exists");
                                break;
                            default:
                                MessageBox.Show("Export to the server failed with the code " + result.ToString());
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            
            return false;
        }
    }
}
