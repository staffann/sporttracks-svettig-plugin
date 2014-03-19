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
using ZoneFiveSoftware.Common.Data;
using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Data.GPS;
using ZoneFiveSoftware.Common.Data.Fitness.CustomData;
using ZoneFiveSoftware.Common.Visuals.Fitness;
using SvettigPlugin.SvettigService;

namespace SvettigPlugin
{
    // This class handles all access to fitness data.
    // Only one instance should exist in the complete plugin
    class FitnessDataHandler
    {
        private Guid RPEGuid = new Guid("B1383C07-CB6E-407E-A78E-7E8DD2FEB5E1");
        private Guid TEGuid = new Guid("AB32B8CE-30E2-4795-A21B-51C7C481F8F5");
        private Guid RepetitionsGuid = new Guid("684AC20E-F90A-4410-9413-93DF8340872E");
        private Guid SetsGuid = new Guid("86D40A63-E56E-421B-9D13-EE6A372DED4B");

        ICustomDataFieldDefinition RPEField = null;
        ICustomDataFieldDefinition TEField = null;
        ICustomDataFieldDefinition RepetitionsField = null;
        ICustomDataFieldDefinition SetsField = null;

        public FitnessDataHandler(ILogbook Logbook, Guid PluginGuid)
        {
            CheckCustomDataFields(Logbook, PluginGuid);
        }

        public void CheckCustomDataFields(ILogbook Logbook, Guid PluginGuid)
        {
            // Check for custom data fields in the logbook. If they aren't there, create them!
            foreach (ICustomDataFieldDefinition custDataDef in Logbook.CustomDataFieldDefinitions )
            {
                if(custDataDef.Id == RPEGuid)
                {
                    RPEField = custDataDef;
                }
                else if (custDataDef.Id == TEGuid)
                {
                    TEField = custDataDef;
                }
                else if (custDataDef.Id == RepetitionsGuid)
                {
                    RepetitionsField = custDataDef;
                }
                else if (custDataDef.Id == SetsGuid)
                {
                    SetsField = custDataDef;
                }
            }
            if(RPEField == null)
            {
                RPEField = Logbook.CustomDataFieldDefinitions.Add(RPEGuid, 
                                                       CustomDataFieldDefinitions.StandardObjectType(typeof(IActivity)),
                                                       CustomDataFieldDefinitions.StandardDataType(CustomDataFieldDefinitions.StandardDataTypes.NumberDataTypeId),
                                                       "RPE (Borg Scale)");
                RPEField.CreatedBy = PluginGuid;
            }
            if (TEField == null)
            {
                TEField = Logbook.CustomDataFieldDefinitions.Add(TEGuid,
                                                       CustomDataFieldDefinitions.StandardObjectType(typeof(IActivity)),
                                                       CustomDataFieldDefinitions.StandardDataType(CustomDataFieldDefinitions.StandardDataTypes.NumberDataTypeId),
                                                       "Training Effect (TE)");
                TEField.CreatedBy = PluginGuid;
            }
            if (RepetitionsField == null)
            {
                RepetitionsField = Logbook.CustomDataFieldDefinitions.Add(RepetitionsGuid,
                                                       CustomDataFieldDefinitions.StandardObjectType(typeof(IActivity)),
                                                       CustomDataFieldDefinitions.StandardDataType(CustomDataFieldDefinitions.StandardDataTypes.NumberDataTypeId),
                                                       "Repetitions");
                RepetitionsField.CreatedBy = PluginGuid;
            }
            if (SetsField == null)
            {
                SetsField = Logbook.CustomDataFieldDefinitions.Add(SetsGuid,
                                                       CustomDataFieldDefinitions.StandardObjectType(typeof(IActivity)),
                                                       CustomDataFieldDefinitions.StandardDataType(CustomDataFieldDefinitions.StandardDataTypes.NumberDataTypeId),
                                                       "Sets");
                SetsField.CreatedBy = PluginGuid;
            }
        }

        public void GetCustomFieldsData(IActivity activity, 
                                        out int? RPE, 
                                        out double? TE, 
                                        out int? Repetitions, 
                                        out int? Sets)
        {
            if (activity != null)
            {
                RPE = (int?)(activity.GetCustomDataValue(RPEField) as double?);
                TE = activity.GetCustomDataValue(TEField) as double?;
                Repetitions = (int?)(activity.GetCustomDataValue(RepetitionsField) as double?);
                Sets = (int?)(activity.GetCustomDataValue(SetsField) as double?);
            }
            else
            {
                RPE = null;
                TE = null;
                Repetitions = null;
                Sets = null;
            }
        }

        public void SetCustomFieldsData(IActivity activity,
                                int? RPE,
                                double? TE,
                                int? Repetitions,
                                int? Sets)
        {
            if (activity != null)
            {
                int? CurrentRPE, CurrentRepetitions, CurrentSets;
                double? CurrentTE;
                GetCustomFieldsData(activity,
                                    out CurrentRPE,
                                    out CurrentTE,
                                    out CurrentRepetitions,
                                    out CurrentSets);
                if (CurrentRPE != RPE)
                    activity.SetCustomDataValue(RPEField, (double?)RPE);
                if (CurrentTE != TE)
                    activity.SetCustomDataValue(TEField, TE);
                if (CurrentRepetitions != Repetitions)
                    activity.SetCustomDataValue(RepetitionsField, (double?)Repetitions);
                if (CurrentSets != Sets)
                    activity.SetCustomDataValue(SetsField, (double?)Sets);
            }
        }

        public void GetExportData(IActivity activity,
                                  bool boExportNameInComment,
                                  out string name,
                                  out DateTime startDate,
                                  out bool hasStartTime,
                                  out TimeSpan duration,
                                  out float? TE,
                                  out int? cadenceAvg,
                                  out float? distance,
                                  out string comment,
                                  out int? hrAvg,
                                  out int? hrMax,
                                  out int? intensity,
                                  out int? kcal,
                                  out string privateComment,
                                  out int? repetitions,
                                  out int? sets
                                  //out TrainingInterval[] laps,
                                  //out TrackPoint[] trackPoints
                                  )
        {
            if (activity != null)
            {

                int? RPECustFieldData, RepetitionsCustFieldData, SetsCustFieldData;
                double? TECustFieldData;

                GetCustomFieldsData(activity,
                                    out RPECustFieldData,
                                    out TECustFieldData,
                                    out RepetitionsCustFieldData,
                                    out SetsCustFieldData);

                // Get pulse data. Works with and without a HR data track.
                ActivityInfo activityInfo = ActivityInfoCache.Instance.GetInfo(activity);
                if (activityInfo.AverageHeartRate == 0)
                    hrAvg = null;
                else
                    hrAvg = (int?)Math.Round(activityInfo.AverageHeartRate);
                if (activityInfo.MaximumHeartRate == 0)
                    hrMax = null;
                else
                    hrMax = (int?)Math.Round(activityInfo.MaximumHeartRate);
                if (activityInfo.AverageCadence == 0)
                    cadenceAvg = null;
                else
                    cadenceAvg = (int?)Math.Round(activityInfo.AverageCadence);

                startDate = ConvertToLocalTime(activity.StartTime);
                hasStartTime = activity.HasStartTime;
                duration = activityInfo.Time;
                TE = (float?)TECustFieldData;
                distance = (float?)activityInfo.DistanceMeters/1000;
                name = activity.Name;
                if (boExportNameInComment)
                {
                    comment = activity.Name + "\r\n" + activity.Notes;
                }
                else
                {
                    comment = activity.Notes;
                }
                intensity = RPECustFieldData;
                if (activity.TotalCalories == 0)
                    kcal = null;
                else
                    kcal = (int?)Math.Round(activity.TotalCalories);
                privateComment = "SportsTracks reference: " + activity.ReferenceId;
                repetitions = RepetitionsCustFieldData;
                sets = SetsCustFieldData;
                //laps = GetLaps(activity);
                //trackPoints = GetTrackPoints(activity);
            }
            else
            {                
                startDate = new DateTime(1900, 1, 1, 0, 0, 0);
                hasStartTime = false;
                duration = new TimeSpan(0, 0, 0);
                TE = null;
                cadenceAvg = null;
                distance = null;
                name = null;
                comment = "";
                hrAvg = null;
                hrMax = null;
                intensity = null;
                kcal = null;
                privateComment = "";
                repetitions = null;
                sets = null;
                //laps = null;
                //trackPoints = null;

            }
        }

        public void GetAvailableTrackData(IActivity activity,
                                          out bool boGPSCoordAvailable,
                                          out bool boDistanceAvailable,
                                          out bool boAltitudeAvailable,
                                          out bool boHeartRateAvailable)
        {
            if (activity != null)
            {
                if (activity.GPSRoute != null)
                {
                    boGPSCoordAvailable = true;
                    boDistanceAvailable = true;
                    boAltitudeAvailable = true;
                }
                else
                {
                    boGPSCoordAvailable = false;
                    boDistanceAvailable = (activity.DistanceMetersTrack != null);
                    boAltitudeAvailable = (activity.ElevationMetersTrack != null);
                }

                boHeartRateAvailable = (activity.HeartRatePerMinuteTrack != null);
            }
            else
            {
                boGPSCoordAvailable = false;
                boDistanceAvailable = false;
                boAltitudeAvailable = false;
                boHeartRateAvailable = false;
            }
        }

        public bool boGetSvettigExported(IActivity activity)
        {
            if (activity != null)
            {

                // Check if metadata string exists and update the cust data field
                bool boExported = (activity.Metadata.Source.IndexOf("SvettigExported") >= 0);
                return boExported;
            }
            else
                return false;
        }

        public void SetSvettigExported(IActivity activity, bool boExported)
        {
            if (activity != null)
            {
                if (boExported)
                {
                    // Use both old method (metadata string) and new method (cust data field)
                    activity.Metadata.Source += "SvettigExported";
                }
                else
                {
                    //TODO: Add code to remove the export string
                }
            }
        }

        public Tracksegment[] GetSvettigLaps(IActivity activity)
        {
            ActivityInfo activityInfo = ActivityInfoCache.Instance.GetInfo(activity);
            List<Tracksegment> newLaps = new List<Tracksegment>();
            IList<LapDetailInfo> activityLaps;

            if (Plugin.GetApplication().DisplayOptions.SelectedLapsType.Kind == ActivityLapsType.LapKind.RecordedLaps)
                activityLaps = activityInfo.RecordedLapDetailInfo;
            else if (Plugin.GetApplication().DisplayOptions.SelectedLapsType.Kind == ActivityLapsType.LapKind.CustomDistance)
                activityLaps = activityInfo.CustomDistanceLapDetailInfo;
            else
                activityLaps = activityInfo.DistanceLapDetailInfo(Plugin.GetApplication().DisplayOptions.SelectedLapsType.DistanceMeters);

            List<Trackpoint> tpList = GetSvettigTrackPoints(activity);
            if (tpList == null)
                tpList = new List<Trackpoint>();
            int i = 0;
            foreach (LapDetailInfo lapInfo in activityLaps)
            {
                Tracksegment newLap = new Tracksegment();
                newLap.distanceInMeters = lapInfo.LapDistanceMeters;
                newLap.created = ConvertToLocalTime(lapInfo.StartTime).ToString("yyyy-MM-dd HH:mm:ss:fff");
                newLap.pausedSeconds = lapInfo.EndTime.Subtract(lapInfo.StartTime).Subtract(lapInfo.LapElapsed).TotalSeconds;
                newLap.pausedSeconds = Math.Round(newLap.pausedSeconds);

                // Add track points to the lap
                int lapTpStartIdx = i;
                while (i < tpList.Count &&
                       DateTime.ParseExact(tpList[i].created, "yyyy-MM-dd HH:mm:ss:fff", null).CompareTo(ConvertToLocalTime(lapInfo.EndTime)) <= 0)
                {
                    i++;
                }
                if (i > lapTpStartIdx)
                    newLap.trackpoints = tpList.GetRange(lapTpStartIdx, i - lapTpStartIdx).ToArray();
                else
                    newLap.trackpoints = new Trackpoint[0];

                newLaps.Add(newLap);
            }

            //// As a test, add all trackpoints to the first lap
            //if (newLaps.Count > 0)
            //{
            //    newLaps[0].trackpoints = GetSvettigTrackPoints(activity).ToArray();
            //    //newLaps[0].trackpoints = new Trackpoint[1];
            //    //newLaps[0].trackpoints[0] = GetSvettigTrackPoints(activity)[0];
            //}

            return newLaps.ToArray();
        }

        
        //private TrainingInterval[] GetLaps(IActivity activity)
        //{
        //    ActivityInfo activityInfo = ActivityInfoCache.Instance.GetInfo(activity);
        //    List<TrainingInterval> newLaps = new List<TrainingInterval>();
        //    IList<LapDetailInfo> activityLaps;

        //    if (Plugin.GetApplication().DisplayOptions.SelectedLapsType.Kind == ActivityLapsType.LapKind.RecordedLaps)
        //        activityLaps = activityInfo.RecordedLapDetailInfo;
        //    else if (Plugin.GetApplication().DisplayOptions.SelectedLapsType.Kind == ActivityLapsType.LapKind.CustomDistance)
        //        activityLaps = activityInfo.CustomDistanceLapDetailInfo;
        //    else
        //        activityLaps = activityInfo.DistanceLapDetailInfo(Plugin.GetApplication().DisplayOptions.SelectedLapsType.DistanceMeters);

        //    foreach (LapDetailInfo lapInfo in activityLaps)
        //    {
        //        TrainingInterval newLap = new TrainingInterval();
        //        newLap.Distance = lapInfo.LapDistanceMeters / 1000;
        //        newLap.Comment = lapInfo.Notes;
        //        newLap.Duration = new Duration();
        //        newLap.Duration.Hours = lapInfo.LapElapsed.Hours;
        //        newLap.Duration.Minutes = lapInfo.LapElapsed.Minutes;
        //        newLap.Duration.Seconds = lapInfo.LapElapsed.Seconds;
        //        newLaps.Add(newLap);
        //    }
        //    return newLaps.ToArray();
        //}

        private List<Trackpoint> GetSvettigTrackPoints(IActivity activity)
        {
            if (activity.GPSRoute != null && activity.GPSRoute.Count > 0) // The second part is a workaround for the ST Suunto Ambit import that creates an empty GPS route when GPS was off
            {
                // GPS track exists. Base the trackpoints on that and use HR data if available
                return GetSvettigTrackPointsFromGPSTrack(activity);
            }
            else
            {
                // Jogg cannot accept data tracks without also having a GPS track, so return an empty list
                return (new List<Trackpoint>());
                
                //// Get any track data that exists
                //return GetSvettigTrackPointsFromDataTrack(activity);
            }
        }

        // Use the GPS track as a base when creating the TrackPoints.
        // Use heartbeat data if available
        private List<Trackpoint> GetSvettigTrackPointsFromGPSTrack(IActivity activity)
        {
            if (activity.GPSRoute == null)
                return null;
            List<Trackpoint> tps = new List<Trackpoint>();
            //double accDistance = 0;
            ITimeValueEntry<IGPSPoint> prevPoint = null;

            // Removing GPS points at identical time
            // Has been seen to be a problem with other sites
            IGPSRoute ActGPSRoute = new GPSRoute(activity.GPSRoute);
            ActGPSRoute.AllowMultipleAtSameTime = false;

            foreach (ITimeValueEntry<IGPSPoint> p in ActGPSRoute)
            {

                Trackpoint tp = new Trackpoint();
                tp.created = ConvertToLocalTime(ActGPSRoute.StartTime.AddSeconds(p.ElapsedSeconds)).ToString("yyyy-MM-dd HH:mm:ss:fff");

                DateTime actualTime = ActGPSRoute.StartTime.AddSeconds(p.ElapsedSeconds);

                // Get heartrate track
                if (activity.HeartRatePerMinuteTrack != null)
                {
                    if (actualTime < activity.HeartRatePerMinuteTrack.StartTime)
                        actualTime = activity.HeartRatePerMinuteTrack.StartTime;

                    ITimeValueEntry<float> interpolatedHR = activity.HeartRatePerMinuteTrack.GetInterpolatedValue(actualTime);
                    if (interpolatedHR != null)
                    {
                        float heartRate = interpolatedHR.Value;
                        tp.heartrate = Convert.ToInt32(heartRate);
                    }
                    else
                    {
                        tp.heartrate = 0;
                    }
                }
                else
                {
                    tp.heartrate = 0;
                }

                // Get cadence track
                //if (activity.CadencePerMinuteTrack != null)
                //{
                //    if (actualTime < activity.CadencePerMinuteTrack.StartTime)
                //        actualTime = activity.CadencePerMinuteTrack.StartTime;

                //    ITimeValueEntry<float> interpolatedCadence = activity.CadencePerMinuteTrack.GetInterpolatedValue(actualTime);
                //    if (interpolatedCadence != null)
                //    {
                //        float cadence = interpolatedCadence.Value;
                //        tp.Cad = Convert.ToInt32(cadence);
                //        if (double.IsNaN((double)tp.Cad))
                //        {
                //            tp.Cad = null;
                //        }
                //    }
                //    else
                //    {
                //        tp.Cad = null;
                //    }
                //}
                //else
                //{
                //    tp.Cad = null;
                //}

                tp.latitude = p.Value.LatitudeDegrees;
                tp.longitude = p.Value.LongitudeDegrees;
                tp.altitude = p.Value.ElevationMeters;
                if (float.IsNaN(tp.altitude))
                {
                    tp.altitude = 0;
                }

                //if (prevPoint != null)
                //    accDistance += p.Value.DistanceMetersToPoint(prevPoint.Value);
                //tp.Distance = accDistance / 1000;


                tps.Add(tp);
                prevPoint = p;
            }
            return tps;
        }

        // Use any data track as a base when creating the TrackPoints.
        // Set GPS properties to null
        private List<Trackpoint> GetSvettigTrackPointsFromDataTrack(IActivity activity)
        {
            ITimeDataSeries<float> ReferenceTrack;
            if (activity.DistanceMetersTrack != null)
                ReferenceTrack = new TimeDataSeries<float>(activity.DistanceMetersTrack);
            else if (activity.HeartRatePerMinuteTrack != null)
                ReferenceTrack = new TimeDataSeries<float>(activity.HeartRatePerMinuteTrack);
            else if (activity.ElevationMetersTrack != null)
                ReferenceTrack = new TimeDataSeries<float>(activity.ElevationMetersTrack);
            else if (activity.CadencePerMinuteTrack != null)
                ReferenceTrack = new TimeDataSeries<float>(activity.CadencePerMinuteTrack);
            else
                return null;
            ReferenceTrack.AllowMultipleAtSameTime = false;

            List<Trackpoint> tps = new List<Trackpoint>();
            foreach (ITimeValueEntry<float> p in ReferenceTrack)
            {

                Trackpoint tp = new Trackpoint();

                tp.created = ConvertToLocalTime(ReferenceTrack.StartTime.AddSeconds(p.ElapsedSeconds)).ToString("yyyy-MM-dd HH:mm:ss:fff");

                DateTime actualTime = ReferenceTrack.StartTime.AddSeconds(p.ElapsedSeconds);

                //// Get distance
                //if (activity.DistanceMetersTrack != null)
                //{
                //    if (actualTime < activity.DistanceMetersTrack.StartTime)
                //        actualTime = activity.DistanceMetersTrack.StartTime;

                //    ITimeValueEntry<float> interpolatedDistance = activity.DistanceMetersTrack.GetInterpolatedValue(actualTime);
                //    if (interpolatedDistance != null)
                //    {
                //        tp.Distance = interpolatedDistance.Value / 1000;
                //        if (double.IsNaN((double)tp.Distance))
                //        {
                //            tp.Distance = null;
                //        }
                //    }
                //    else
                //    {
                //        tp.Distance = null;
                //    }
                //}
                //else
                //{
                //    tp.Distance = null;
                //}

                // Get elevation track
                if (activity.ElevationMetersTrack != null)
                {
                    if (actualTime < activity.ElevationMetersTrack.StartTime)
                        actualTime = activity.ElevationMetersTrack.StartTime;

                    ITimeValueEntry<float> interpolatedElevation = activity.ElevationMetersTrack.GetInterpolatedValue(actualTime);
                    if (interpolatedElevation != null)
                    {
                        tp.altitude = interpolatedElevation.Value;
                        //if (double.IsNaN((double)tp.Altitude))
                        //{
                        //    tp.Altitude = null;
                        //}

                    }
                    //else
                    //{
                    //    tp.Altitude = null;
                    //}
                }
                //else
                //{
                //    tp.Altitude = null;
                //}

                // Get heart rate track
                if (activity.HeartRatePerMinuteTrack != null)
                {
                    if (actualTime < activity.HeartRatePerMinuteTrack.StartTime)
                        actualTime = activity.HeartRatePerMinuteTrack.StartTime;

                    ITimeValueEntry<float> interpolatedHR = activity.HeartRatePerMinuteTrack.GetInterpolatedValue(actualTime);
                    if (interpolatedHR != null)
                    {
                        float heartRate = interpolatedHR.Value;
                        tp.heartrate = Convert.ToInt32(heartRate);
                        //if (double.IsNaN((double)tp.HR))
                        //{
                        //    tp.heartrate = 0;
                        //}
                    }
                    else
                    {
                        tp.heartrate = 0;
                    }
                }
                else
                {
                    tp.heartrate = 0;
                }


                //// Get cadence track
                //if (activity.CadencePerMinuteTrack != null)
                //{
                //    if (actualTime < activity.CadencePerMinuteTrack.StartTime)
                //        actualTime = activity.CadencePerMinuteTrack.StartTime;

                //    ITimeValueEntry<float> interpolatedCadence = activity.CadencePerMinuteTrack.GetInterpolatedValue(actualTime);
                //    if (interpolatedCadence != null)
                //    {
                //        float cadence = interpolatedCadence.Value;
                //        tp.Cad = Convert.ToInt32(cadence);
                //        if (double.IsNaN((double)tp.Cad))
                //        {
                //            tp.Cad = null;
                //        }
                //    }
                //    else
                //    {
                //        tp.Cad = null;
                //    }
                //}
                //else
                //{
                //    tp.Cad = null;
                //}

                tp.latitude = 0;
                tp.longitude = 0;

                tps.Add(tp);
            }
            return tps;
        }

        private DateTime ConvertToLocalTime(DateTime utc)
        {
            TimeSpan diff = new TimeSpan(DateTime.Now.Ticks - DateTime.UtcNow.Ticks);
            return utc.AddTicks(diff.Ticks);
        }

    }
}
