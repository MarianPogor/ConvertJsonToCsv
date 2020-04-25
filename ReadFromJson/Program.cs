using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChoETL;
using GracefulDynamicDictionary;

namespace ReadFromJson
{










    class Program
    {


        static void Main(string[] args)
        {

            /*  List<Rootobject> obj = new List<Rootobject>();
              var anonymousData = from pl in obj
                                  select new
                                  {
                                      pl.id,
                                      pl.uuid,
                                      pl.name,
                                      pl.description,
                                      pl.state
                                  };*/





            using (var csv = new ChoCSVWriter("emp2.csv").WithFirstLineHeader())
            {
                using (var json = new ChoJSONReader("all.json"))
                {
                    csv.Write(json.Select(i => new
                    {


                        // Info about device
                        Id = i.id != null ? i.id : 0,
                        DeviceUuid = i.uuid != null ? i.uuid : null,
                        DeviceName = i.name != null ? i.name : null,
                        DeviceDescription = i.description != null ? i.description : null,
                        DeviceState = i.state != null ? i.state : null,
                        SystemTags = i.system_tags.Length > 0 ? i.system_tags[0] : null,


                        UserTags = i.user_tags.Length > 0 ? i.user_tags[0] : null,
                        LastReading = i.last_reading_at != null ? i.last_reading_at : null,
                        AddedAt = i.added_at != null ? i.added_at : null,
                        Updated = i.updated_at != null ? i.updated_at : null,
                        MacAddress = i.mac_address != null ? i.mac_address : null,

                        //Info about owner
                        OwnerID = i.owner != null ? i.owner.id : 0,
                        OwnerUuid = i.owner != null ? i.owner.uuid : null,
                        OwnerUserName = i.owner != null ? i.owner.username : null,
                        OwnerAvatar = i.owner != null ? i.owner.avatar : null,
                        OwnerUrl = i.owner != null ? i.owner.url : null,
                        OwnerJoinDate = i.owner != null ? i.owner.joined_at : null,
                        OwnerCity = i.owner != null ? i.owner.location.city : null,
                        OwnerCountry = i.owner != null ? i.owner.location.country : null,
                        OwnerCountryCode = i.owner != null ? i.owner.location.country_code : null,
                        // DeviceIds = i.owner.device_ids.Length > 0 ? i.owner.device_ids[0] : 0,




                        //Info about data

                        DataRecorded_At = i.data != null ? i.data.recorded_at : null,
                        DataAdded_At = i.data != null ? i.data.added_at : null,
                        DataLocation = i.data.ip != null ? i.data.location.ip : null,
                        DataExposure = i.data != null ? i.data.location.exposure : null,
                        DataElevation = i.data != null ? i.data.location.elevation : 0,
                        DataLatitude = i.data != null ? i.data.location.latitude : 0,
                        DataLongitude = i.data != null ? i.data.location.longitude : 0,
                        DataGeoLocation = i.data != null ? i.data.location.geohash : null,
                        DataCity = i.data != null ? i.data.location.city : null,
                        DataCountryCode = i.data != null ? i.data.location.country_code : null,
                        DataCountry = i.data != null ? i.data.location.country : null,






                        //SensorBattery
                        BSensorsId = i.data.sensors.Length > 0 ? i.data.sensors[0].id : 0,
                        BSensortAncestry = i.data.sensors.Length > 0 ? i.data.sensors[0].ancestry : null,
                        BSensorName = i.data.sensors.Length > 0 ? i.data.sensors[0].name : null,
                        BSensorDescription = i.data.sensors.Length > 0 ? i.data.sensors[0].description : null,
                        BSensorUnit = i.data.sensors.Length > 0 ? i.data.sensors[0].unit : 0,
                        BSensorCreatedAt = i.data.sensors.Length > 0 ? i.data.sensors[0].created_at : DateTime.MinValue,
                        BSensorUpdated_at = i.data.sensors.Length > 0 ? i.data.sensors[0].updated_at : DateTime.MinValue,
                        BSensorMeasurement_id = i.data.sensors.Length > 0 ? i.data.sensors[0].measurement_id : 0,
                        BSensorUuid = i.data.sensors.Length > 0 ? i.data.sensors[0].uuid : null,
                        BSensorValue = i.data.sensors.Length > 0 ? i.data.sensors[0].value : 0,
                        BSensorRawValue = i.data.sensors.Length > 0 ? i.data.sensors[0].raw_value : 0,
                        BSensorPrevValue = i.data.sensors.Length > 0 ? i.data.sensors[0].prev_value : 0,
                        BSensorPrevRawValue = i.data.sensors.Length > 0 ? i.data.sensors[0].prev_raw_value : 0,
                        //SensorHumidity

                        SensorsHId = i.data.sensors.Length > 1 ? i.data.sensors[1].id : 0,
                        SensortHAncestry = i.data.sensors.Length > 1 ? i.data.sensors[1].ancestry : null,
                        SensorHName = i.data.sensors.Length > 1 ? i.data.sensors[1].name : null,
                        SensorHDescription = i.data.sensors.Length > 1 ? i.data.sensors[1].description : null,
                        SensorHUnit = i.data.sensors.Length > 1 ? i.data.sensors[1].unit : 0,
                        SensorHCreatedAt = i.data.sensors.Length > 1 ? i.data.sensors[1].created_at : DateTime.MinValue,
                        SensorHUpdated_at = i.data.sensors.Length > 1 ? i.data.sensors[1].updated_at : DateTime.MinValue,
                        SensorHMeasurement_id = i.data.sensors.Length > 1 ? i.data.sensors[1].measurement_id : 0,
                        SensorHUuid = i.data.sensors.Length > 1 ? i.data.sensors[1].uuid : null,
                        SensorHValue = i.data.sensors.Length > 1 ? i.data.sensors[1].value : 0,
                        SensorHRawValue = i.data.sensors.Length > 1 ? i.data.sensors[1].raw_value : 0,
                        SensorHPrevValue = i.data.sensors.Length > 1 ? i.data.sensors[1].prev_value : 0,
                        SensorHPrevRawValue = i.data.sensors.Length > 1 ? i.data.sensors[1].prev_raw_value : 0,

                        //Temperature
                        TSensorsId = i.data.sensors.Length > 2 ? i.data.sensors[2].id : 0,
                        TSensortAncestry = i.data.sensors.Length > 2 ? i.data.sensors[2].ancestry : null,
                        TSensorName = i.data.sensors.Length > 2 ? i.data.sensors[2].name : null,
                        TSensorDescription = i.data.sensors.Length > 2 ? i.data.sensors[2].description : null,
                        TSensorUnit = i.data.sensors.Length > 2 ? i.data.sensors[2].unit : 0,
                        TSensorCreatedAt = i.data.sensors.Length > 2 ? i.data.sensors[2].created_at : DateTime.MinValue,
                        TSensorUpdated_at = i.data.sensors.Length > 2 ? i.data.sensors[2].updated_at : DateTime.MinValue,
                        TSensorMeasurement_id = i.data.sensors.Length > 2 ? i.data.sensors[2].measurement_id : 0,
                        TSensorUuid = i.data.sensors.Length > 2 ? i.data.sensors[2].uuid : null,
                        TSensorValue = i.data.sensors.Length > 2 ? i.data.sensors[2].value : 0,
                        TSensorRawValue = i.data.sensors.Length > 2 ? i.data.sensors[2].raw_value : 0,
                        TSensorPrevValue = i.data.sensors.Length > 2 ? i.data.sensors[2].prev_value : 0,
                        TSensorPrevRawValue = i.data.sensors.Length > 2 ? i.data.sensors[2].prev_raw_value : 0,

                        //No2 gas sensor

                        GasSensorsId = i.data.sensors.Length > 3 ? i.data.sensors[3].id : 0,
                        GasSensortAncestry = i.data.sensors.Length > 3 ? i.data.sensors[3].ancestry : null,
                        GasSensorName = i.data.sensors.Length > 3 ? i.data.sensors[3].name : null,
                        GasSensorDescription = i.data.sensors.Length > 3 ? i.data.sensors[3].description : null,
                        GasSensorUnit = i.data.sensors.Length > 3 ? i.data.sensors[3].unit : 0,
                        GasSensorCreatedAt = i.data.sensors.Length > 3 ? i.data.sensors[3].created_at : DateTime.MinValue,
                        GasSensorUpdated_at = i.data.sensors.Length > 3 ? i.data.sensors[3].updated_at : DateTime.MinValue,
                        GasSensorMeasurement_id = i.data.sensors.Length > 3 ? i.data.sensors[3].measurement_id : 0,
                        GasSensorUuid = i.data.sensors.Length > 4 ? i.data.sensors[3].uuid : null,
                        GasSensorValue = i.data.sensors.Length > 4 ? i.data.sensors[3].value : 0,
                        GasSensorRawValue = i.data.sensors.Length > 4 ? i.data.sensors[3].raw_value : 0,
                        GasSensorPrevValue = i.data.sensors.Length > 4 ? i.data.sensors[3].prev_value : 0,
                        GasSensorPrevRawValue = i.data.sensors.Length > 4 ? i.data.sensors[3].prev_raw_value : 0,


                        //CO2 gas sensor 
                        CoSensorsId = i.data.sensors.Length > 5 ? i.data.sensors[4].id : -1,
                        CoSensortAncestry = i.data.sensors.Length > 5 ? i.data.sensors[4].ancestry : null,
                        CoSensorName = i.data.sensors.Length > 5 ? i.data.sensors[4].name : null,
                        CoSensorDescription = i.data.sensors.Length > 5 ? i.data.sensors[4].description : null,
                        CoSensorUnit = i.data.sensors.Length > 5 ? i.data.sensors[4].unit : -1,
                        CoSensorCreatedAt = i.data.sensors.Length > 5 ? i.data.sensors[4].created_at : DateTime.MinValue,
                        CoSensorUpdated_at = i.data.sensors.Length > 5 ? i.data.sensors[4].updated_at : DateTime.MinValue,
                        CoSensorMeasurement_id = i.data.sensors.Length > 5 ? i.data.sensors[4].measurement_id : -1,
                        CoSensorUuid = i.data.sensors.Length > 5 ? i.data.sensors[4].uuid : null,
                        CoSensorValue = i.data.sensors.Length > 5 ? i.data.sensors[4].value : -1,
                        CoSensorRawValue = i.data.sensors.Length > 5 ? i.data.sensors[4].raw_value : -1,
                        CoSensorPrevValue = i.data.sensors.Length > 5 ? i.data.sensors[4].prev_value : -1,
                        CoSensorPrevRawValue = i.data.sensors.Length > 5 ? i.data.sensors[4].prev_raw_value : -1,


                        //Network sensor


                        NetSensorsId = i.data.sensors.Length > 6 ? i.data.sensors[5].id : 0,
                        NetSensortAncestry = i.data.sensors.Length > 6 ? i.data.sensors[5].ancestry : null,
                        NetSensorName = i.data.sensors.Length > 6 ? i.data.sensors[5].name : null,
                        NetSensorDescription = i.data.sensors.Length > 6 ? i.data.sensors[5].description : null,
                        NetSensorUnit = i.data.sensors.Length > 6 ? i.data.sensors[5].unit : 0,
                        NetSensorCreatedAt = i.data.sensors.Length > 6 ? i.data.sensors[5].created_at : DateTime.MinValue,
                        NetSensorUpdated_at = i.data.sensors.Length > 6 ? i.data.sensors[5].updated_at : DateTime.MinValue,
                        NetSensorMeasurement_id = i.data.sensors.Length > 6 ? i.data.sensors[5].measurement_id : 0,
                        NetSensorUuid = i.data.sensors.Length > 6 ? i.data.sensors[5].uuid : null,
                        NetSensorValue = i.data.sensors.Length > null ? i.data.sensors[5].value : 0,
                        NetSensorRawValue = i.data.sensors.Length > null ? i.data.sensors[5].raw_value : 0,
                        NetSensorPrevValue = i.data.sensors.Length > null ? i.data.sensors[5].prev_value : 0,
                        NetSensorPrevRawValue = i.data.sensors.Length > null ? i.data.sensors[5].prev_raw_value : 0,




                        //decibel sensor  db

                        DBSensorsId = i.data.sensors.Length > 7 ? i.data.sensors[6].id : 0,
                        DBSensortAncestry = i.data.sensors.Length > 7 ? i.data.sensors[6].ancestry : null,
                        DbSensorName = i.data.sensors.Length > 7 ? i.data.sensors[6].name : null,
                        DbSensorDescription = i.data.sensors.Length > 7 ? i.data.sensors[6].description : null,
                        DbSensorUnit = i.data.sensors.Length > 7 ? i.data.sensors[6].unit : 0,
                        DbSensorCreatedAt = i.data.sensors.Length > 7 ? i.data.sensors[6].created_at : DateTime.MinValue,
                        DbSensorUpdated_at = i.data.sensors.Length > 7 ? i.data.sensors[6].updated_at : DateTime.MinValue,
                        DbSensorMeasurement_id = i.data.sensors.Length > 7 ? i.data.sensors[6].measurement_id : 0,
                        DbSensorUuid = i.data.sensors.Length > 7 ? i.data.sensors[6].uuid : null,
                        DbSensorValue = i.data.sensors.Length > 7 ? i.data.sensors[6].value : 0,
                        DbSensorRawValue = i.data.sensors.Length > 7 ? i.data.sensors[6].raw_value : 0,
                        DbSensorPrevValue = i.data.sensors.Length > 7 ? i.data.sensors[6].prev_value : 0,
                        DbSensorPrevRawValue = i.data.sensors.Length > 7 ? i.data.sensors[6].prev_raw_value : 0,

                        // LDR Analog Light Sensor

                        LSensorsId = i.data.sensors.Length > 8 ? i.data.sensors[7].id : 0,
                        LSensortAncestry = i.data.sensors.Length > 8 ? i.data.sensors[7].ancestry : null,
                        LSensorName = i.data.sensors.Length > 8 ? i.data.sensors[7].name : null,
                        LSensorDescription = i.data.sensors.Length > 8 ? i.data.sensors[7].description : null,
                        LSensorUnit = i.data.sensors.Length > 8 ? i.data.sensors[7].unit : 0,
                        LSensorCreatedAt = i.data.sensors.Length > 8 ? i.data.sensors[7].created_at : DateTime.MinValue,
                        LSensorUpdated_at = i.data.sensors.Length > 8 ? i.data.sensors[7].updated_at : DateTime.MinValue,
                        LSensorMeasurement_id = i.data.sensors.Length > 8 ? i.data.sensors[7].measurement_id : 0,
                        LSensorUuid = i.data.sensors.Length > 8 ? i.data.sensors[7].uuid : null,
                        LSensorValue = i.data.sensors.Length > 8 ? i.data.sensors[7].value : 0,
                        LSensorRawValue = i.data.sensors.Length > 8 ? i.data.sensors[7].raw_value : 0,
                        LSensorPrevValue = i.data.sensors.Length > 8 ? i.data.sensors[7].prev_value : 0,
                        LSensorPrevRawValue = i.data.sensors.Length > 8 ? i.data.sensors[7].prev_raw_value : 0,

                        //solar panel 
                        SolSensorsId = i.data.sensors.Length > 9 ? i.data.sensors[8].id : 0,
                        SolSensortAncestry = i.data.sensors.Length > 9 ? i.data.sensors[8].ancestry : null,
                        SolSensorName = i.data.sensors.Length > 9 ? i.data.sensors[8].name : null,
                        SolSensorDescription = i.data.sensors.Length > 9 ? i.data.sensors[8].description : null,
                        SolSensorUnit = i.data.sensors.Length > 9 ? i.data.sensors[8].unit : 0,
                        SolSensorCreatedAt = i.data.sensors.Length > 9 ? i.data.sensors[8].created_at : DateTime.MinValue,
                        SolSensorUpdated_at = i.data.sensors.Length > 9 ? i.data.sensors[8].updated_at : DateTime.MinValue,
                        SolSensorMeasurement_id = i.data.sensors.Length > 9 ? i.data.sensors[8].measurement_id : 0,
                        SolSensorUuid = i.data.sensors.Length > 9 ? i.data.sensors[8].uuid : null,
                        SolSensorValue = i.data.sensors.Length > 9 ? i.data.sensors[8].value : 0,
                        SolSensorRawValue = i.data.sensors.Length > 9 ? i.data.sensors[8].raw_value : 0,
                        SolSensorPrevValue = i.data.sensors.Length > 9 ? i.data.sensors[8].prev_value : 0,
                        SolSensorPrevRawValue = i.data.sensors.Length > 9 ? i.data.sensors[8].prev_raw_value : 0,

                        //kit info
                        KitId = i.kit != null ? i.kit.id : 0,
                        KitUuid = i.kit != null ? i.kit.uuid : null,
                        KitSlug = i.kit != null ? i.kit.slug : null,
                        KitName = i.kit != null ? i.kit.name : null,
                        KitDescription = i.kit != null ? i.kit.description : null,
                        KitCreatedAt = i.kit != null ? i.kit.created_at : null,
                        KitUpdatedAt = i.kit != null ? i.kit.updated_at : null



                    }));
                }
            }
        }



    }


}




/* using (var csv = new ChoCSVWriter("emph.csv").WithFirstLineHeader())
                        {
                            using (var json23 = new ChoJSONReader("F:\\file5.json"))
                            {
                                csv.Write(json23.Select(i => new
                                {


                                    // Info about device
                                    Id = i.id != null ? i.id : 0,
                                    DeviceUuid = i.uuid != null ? i.uuid : null,
                                    DeviceName = i.name != null ? i.name : null,
                                    DeviceDescription = i.description != null ? i.description : null,
                                    DeviceState = i.state != null ? i.state : null,
                                    SystemTags = i.system_tags.Length > 0 ? i.system_tags[0] : null,


                                    UserTags = i.user_tags.Length > 0 ? i.user_tags[0] : null,
                                    LastReading = i.last_reading_at != null ? i.last_reading_at : null,
                                    AddedAt = i.added_at != null ? i.added_at : null,
                                    Updated = i.updated_at != null ? i.updated_at : null,
                                    MacAddress = i.mac_address != null ? i.mac_address : null,

                                    //Info about owner
                                    OwnerID = i.owner != null ? i.owner.id : 0,
                                    OwnerUuid = i.owner != null ? i.owner.uuid : null,
                                    OwnerUserName = i.owner != null ? i.owner.username : null,
                                    OwnerAvatar = i.owner != null ? i.owner.avatar : null,
                                    OwnerUrl = i.owner != null ? i.owner.url : null,
                                    OwnerJoinDate = i.owner != null ? i.owner.joined_at : null,
                                    OwnerCity = i.owner != null ? i.owner.location.city : null,
                                    OwnerCountry = i.owner != null ? i.owner.location.country : null,
                                    OwnerCountryCode = i.owner != null ? i.owner.location.country_code : null,
                                    // DeviceIds = i.owner.device_ids.Length > 0 ? i.owner.device_ids[0] : 0,




                                    //Info about data

                                    DataRecorded_At = i.data != null ? i.data.recorded_at : null,
                                    DataAdded_At = i.data != null ? i.data.added_at : null,
                                    DataLocation = i.data.ip != null ? i.data.location.ip : null,
                                    DataExposure = i.data != null ? i.data.location.exposure : null,
                                    DataElevation = i.data != null ? i.data.location.elevation : 0,
                                    DataLatitude = i.data != null ? i.data.location.latitude : 0,
                                    DataLongitude = i.data != null ? i.data.location.longitude : 0,
                                    DataGeoLocation = i.data != null ? i.data.location.geohash : null,
                                    DataCity = i.data != null ? i.data.location.city : null,
                                    DataCountryCode = i.data != null ? i.data.location.country_code : null,
                                    DataCountry = i.data != null ? i.data.location.country : null,






                                    //SensorBattery
                                    BSensorsId = i.data.sensors.Length > 0 ? i.data.sensors[0].id : 0,
                                    BSensortAncestry = i.data.sensors.Length > 0 ? i.data.sensors[0].ancestry : null,
                                    BSensorName = i.data.sensors.Length > 0 ? i.data.sensors[0].name : null,
                                    BSensorDescription = i.data.sensors.Length > 0 ? i.data.sensors[0].description : null,
                                    BSensorUnit = i.data.sensors.Length > 0 ? i.data.sensors[0].unit : 0,
                                    BSensorCreatedAt = i.data.sensors.Length > 0 ? i.data.sensors[0].created_at : DateTime.MinValue,
                                    BSensorUpdated_at = i.data.sensors.Length > 0 ? i.data.sensors[0].updated_at : DateTime.MinValue,
                                    BSensorMeasurement_id = i.data.sensors.Length > 0 ? i.data.sensors[0].measurement_id : 0,
                                    BSensorUuid = i.data.sensors.Length > 0 ? i.data.sensors[0].uuid : null,
                                    BSensorValue = i.data.sensors.Length > 0 ? i.data.sensors[0].value : 0,
                                    BSensorRawValue = i.data.sensors.Length > 0 ? i.data.sensors[0].raw_value : 0,
                                    BSensorPrevValue = i.data.sensors.Length > 0 ? i.data.sensors[0].prev_value : 0,
                                    BSensorPrevRawValue = i.data.sensors.Length > 0 ? i.data.sensors[0].prev_raw_value : 0,
                                    //SensorHumidity

                                    SensorsHId = i.data.sensors.Length > 1 ? i.data.sensors[1].id : 0,
                                    SensortHAncestry = i.data.sensors.Length > 1 ? i.data.sensors[1].ancestry : null,
                                    SensorHName = i.data.sensors.Length > 1 ? i.data.sensors[1].name : null,
                                    SensorHDescription = i.data.sensors.Length > 1 ? i.data.sensors[1].description : null,
                                    SensorHUnit = i.data.sensors.Length > 1 ? i.data.sensors[1].unit : 0,
                                    SensorHCreatedAt = i.data.sensors.Length > 1 ? i.data.sensors[1].created_at : DateTime.MinValue,
                                    SensorHUpdated_at = i.data.sensors.Length > 1 ? i.data.sensors[1].updated_at : DateTime.MinValue,
                                    SensorHMeasurement_id = i.data.sensors.Length > 1 ? i.data.sensors[1].measurement_id : 0,
                                    SensorHUuid = i.data.sensors.Length > 1 ? i.data.sensors[1].uuid : null,
                                    SensorHValue = i.data.sensors.Length > 1 ? i.data.sensors[1].value : 0,
                                    SensorHRawValue = i.data.sensors.Length > 1 ? i.data.sensors[1].raw_value : 0,
                                    SensorHPrevValue = i.data.sensors.Length > 1 ? i.data.sensors[1].prev_value : 0,
                                    SensorHPrevRawValue = i.data.sensors.Length > 1 ? i.data.sensors[1].prev_raw_value : 0,

                                    //Temperature
                                    TSensorsId = i.data.sensors.Length > 2 ? i.data.sensors[2].id : 0,
                                    TSensortAncestry = i.data.sensors.Length > 2 ? i.data.sensors[2].ancestry : null,
                                    TSensorName = i.data.sensors.Length > 2 ? i.data.sensors[2].name : null,
                                    TSensorDescription = i.data.sensors.Length > 2 ? i.data.sensors[2].description : null,
                                    TSensorUnit = i.data.sensors.Length > 2 ? i.data.sensors[2].unit : 0,
                                    TSensorCreatedAt = i.data.sensors.Length > 2 ? i.data.sensors[2].created_at : DateTime.MinValue,
                                    TSensorUpdated_at = i.data.sensors.Length > 2 ? i.data.sensors[2].updated_at : DateTime.MinValue,
                                    TSensorMeasurement_id = i.data.sensors.Length > 2 ? i.data.sensors[2].measurement_id : 0,
                                    TSensorUuid = i.data.sensors.Length > 2 ? i.data.sensors[2].uuid : null,
                                    TSensorValue = i.data.sensors.Length > 2 ? i.data.sensors[2].value : 0,
                                    TSensorRawValue = i.data.sensors.Length > 2 ? i.data.sensors[2].raw_value : 0,
                                    TSensorPrevValue = i.data.sensors.Length > 2 ? i.data.sensors[2].prev_value : 0,
                                    TSensorPrevRawValue = i.data.sensors.Length > 2 ? i.data.sensors[2].prev_raw_value : 0,

                                    //No2 gas sensor

                                    GasSensorsId = i.data.sensors.Length > 3 ? i.data.sensors[3].id : 0,
                                    GasSensortAncestry = i.data.sensors.Length > 3 ? i.data.sensors[3].ancestry : null,
                                    GasSensorName = i.data.sensors.Length > 3 ? i.data.sensors[3].name : null,
                                    GasSensorDescription = i.data.sensors.Length > 3 ? i.data.sensors[3].description : null,
                                    GasSensorUnit = i.data.sensors.Length > 3 ? i.data.sensors[3].unit : 0,
                                    GasSensorCreatedAt = i.data.sensors.Length > 3 ? i.data.sensors[3].created_at : DateTime.MinValue,
                                    GasSensorUpdated_at = i.data.sensors.Length > 3 ? i.data.sensors[3].updated_at : DateTime.MinValue,
                                    GasSensorMeasurement_id = i.data.sensors.Length > 3 ? i.data.sensors[3].measurement_id : 0,
                                    GasSensorUuid = i.data.sensors.Length > 4 ? i.data.sensors[3].uuid : null,
                                    GasSensorValue = i.data.sensors.Length > 4 ? i.data.sensors[3].value : 0,
                                    GasSensorRawValue = i.data.sensors.Length > 4 ? i.data.sensors[3].raw_value : 0,
                                    GasSensorPrevValue = i.data.sensors.Length > 4 ? i.data.sensors[3].prev_value : 0,
                                    GasSensorPrevRawValue = i.data.sensors.Length > 4 ? i.data.sensors[3].prev_raw_value : 0,


                                    //CO2 gas sensor 
                                    CoSensorsId = i.data.sensors.Length > 5 ? i.data.sensors[4].id : -1,
                                    CoSensortAncestry = i.data.sensors.Length > 5 ? i.data.sensors[4].ancestry : null,
                                    CoSensorName = i.data.sensors.Length > 5 ? i.data.sensors[4].name : null,
                                    CoSensorDescription = i.data.sensors.Length > 5 ? i.data.sensors[4].description : null,
                                    CoSensorUnit = i.data.sensors.Length > 5 ? i.data.sensors[4].unit : -1,
                                    CoSensorCreatedAt = i.data.sensors.Length > 5 ? i.data.sensors[4].created_at : DateTime.MinValue,
                                    CoSensorUpdated_at = i.data.sensors.Length > 5 ? i.data.sensors[4].updated_at : DateTime.MinValue,
                                    CoSensorMeasurement_id = i.data.sensors.Length > 5 ? i.data.sensors[4].measurement_id : -1,
                                    CoSensorUuid = i.data.sensors.Length > 5 ? i.data.sensors[4].uuid : null,
                                    CoSensorValue = i.data.sensors.Length > 5 ? i.data.sensors[4].value : -1,
                                    CoSensorRawValue = i.data.sensors.Length > 5 ? i.data.sensors[4].raw_value : -1,
                                    CoSensorPrevValue = i.data.sensors.Length > 5 ? i.data.sensors[4].prev_value : -1,
                                    CoSensorPrevRawValue = i.data.sensors.Length > 5 ? i.data.sensors[4].prev_raw_value : -1,


                                    //Network sensor


                                    NetSensorsId = i.data.sensors.Length > 6 ? i.data.sensors[5].id : 0,
                                    NetSensortAncestry = i.data.sensors.Length > 6 ? i.data.sensors[5].ancestry : null,
                                    NetSensorName = i.data.sensors.Length > 6 ? i.data.sensors[5].name : null,
                                    NetSensorDescription = i.data.sensors.Length > 6 ? i.data.sensors[5].description : null,
                                    NetSensorUnit = i.data.sensors.Length > 6 ? i.data.sensors[5].unit : 0,
                                    NetSensorCreatedAt = i.data.sensors.Length > 6 ? i.data.sensors[5].created_at : DateTime.MinValue,
                                    NetSensorUpdated_at = i.data.sensors.Length > 6 ? i.data.sensors[5].updated_at : DateTime.MinValue,
                                    NetSensorMeasurement_id = i.data.sensors.Length > 6 ? i.data.sensors[5].measurement_id : 0,
                                    NetSensorUuid = i.data.sensors.Length > 6 ? i.data.sensors[5].uuid : null,
                                    NetSensorValue = i.data.sensors.Length > null ? i.data.sensors[5].value : 0,
                                    NetSensorRawValue = i.data.sensors.Length > null ? i.data.sensors[5].raw_value : 0,
                                    NetSensorPrevValue = i.data.sensors.Length > null ? i.data.sensors[5].prev_value : 0,
                                    NetSensorPrevRawValue = i.data.sensors.Length > null ? i.data.sensors[5].prev_raw_value : 0,




                                    //decibel sensor  db

                                    DBSensorsId = i.data.sensors.Length > 7 ? i.data.sensors[6].id : 0,
                                    DBSensortAncestry = i.data.sensors.Length > 7 ? i.data.sensors[6].ancestry : null,
                                    DbSensorName = i.data.sensors.Length > 7 ? i.data.sensors[6].name : null,
                                    DbSensorDescription = i.data.sensors.Length > 7 ? i.data.sensors[6].description : null,
                                    DbSensorUnit = i.data.sensors.Length > 7 ? i.data.sensors[6].unit : 0,
                                    DbSensorCreatedAt = i.data.sensors.Length > 7 ? i.data.sensors[6].created_at : DateTime.MinValue,
                                    DbSensorUpdated_at = i.data.sensors.Length > 7 ? i.data.sensors[6].updated_at : DateTime.MinValue,
                                    DbSensorMeasurement_id = i.data.sensors.Length > 7 ? i.data.sensors[6].measurement_id : 0,
                                    DbSensorUuid = i.data.sensors.Length > 7 ? i.data.sensors[6].uuid : null,
                                    DbSensorValue = i.data.sensors.Length > 7 ? i.data.sensors[6].value : 0,
                                    DbSensorRawValue = i.data.sensors.Length > 7 ? i.data.sensors[6].raw_value : 0,
                                    DbSensorPrevValue = i.data.sensors.Length > 7 ? i.data.sensors[6].prev_value : 0,
                                    DbSensorPrevRawValue = i.data.sensors.Length > 7 ? i.data.sensors[6].prev_raw_value : 0,

                                    // LDR Analog Light Sensor

                                    LSensorsId = i.data.sensors.Length > 8 ? i.data.sensors[7].id : 0,
                                    LSensortAncestry = i.data.sensors.Length > 8 ? i.data.sensors[7].ancestry : null,
                                    LSensorName = i.data.sensors.Length > 8 ? i.data.sensors[7].name : null,
                                    LSensorDescription = i.data.sensors.Length > 8 ? i.data.sensors[7].description : null,
                                    LSensorUnit = i.data.sensors.Length > 8 ? i.data.sensors[7].unit : 0,
                                    LSensorCreatedAt = i.data.sensors.Length > 8 ? i.data.sensors[7].created_at : DateTime.MinValue,
                                    LSensorUpdated_at = i.data.sensors.Length > 8 ? i.data.sensors[7].updated_at : DateTime.MinValue,
                                    LSensorMeasurement_id = i.data.sensors.Length > 8 ? i.data.sensors[7].measurement_id : 0,
                                    LSensorUuid = i.data.sensors.Length > 8 ? i.data.sensors[7].uuid : null,
                                    LSensorValue = i.data.sensors.Length > 8 ? i.data.sensors[7].value : 0,
                                    LSensorRawValue = i.data.sensors.Length > 8 ? i.data.sensors[7].raw_value : 0,
                                    LSensorPrevValue = i.data.sensors.Length > 8 ? i.data.sensors[7].prev_value : 0,
                                    LSensorPrevRawValue = i.data.sensors.Length > 8 ? i.data.sensors[7].prev_raw_value : 0,

                                    //solar panel 
                                    SolSensorsId = i.data.sensors.Length > 9 ? i.data.sensors[8].id : 0,
                                    SolSensortAncestry = i.data.sensors.Length > 9 ? i.data.sensors[8].ancestry : null,
                                    SolSensorName = i.data.sensors.Length > 9 ? i.data.sensors[8].name : null,
                                    SolSensorDescription = i.data.sensors.Length > 9 ? i.data.sensors[8].description : null,
                                    SolSensorUnit = i.data.sensors.Length > 9 ? i.data.sensors[8].unit : 0,
                                    SolSensorCreatedAt = i.data.sensors.Length > 9 ? i.data.sensors[8].created_at : DateTime.MinValue,
                                    SolSensorUpdated_at = i.data.sensors.Length > 9 ? i.data.sensors[8].updated_at : DateTime.MinValue,
                                    SolSensorMeasurement_id = i.data.sensors.Length > 9 ? i.data.sensors[8].measurement_id : 0,
                                    SolSensorUuid = i.data.sensors.Length > 9 ? i.data.sensors[8].uuid : null,
                                    SolSensorValue = i.data.sensors.Length > 9 ? i.data.sensors[8].value : 0,
                                    SolSensorRawValue = i.data.sensors.Length > 9 ? i.data.sensors[8].raw_value : 0,
                                    SolSensorPrevValue = i.data.sensors.Length > 9 ? i.data.sensors[8].prev_value : 0,
                                    SolSensorPrevRawValue = i.data.sensors.Length > 9 ? i.data.sensors[8].prev_raw_value : 0,

                                    //kit info
                                    KitId = i.kit != null ? i.kit.id : 0,
                                    KitUuid = i.kit != null ? i.kit.uuid : null,
                                    KitSlug = i.kit != null ? i.kit.slug : null,
                                    KitName = i.kit != null ? i.kit.name : null,
                                    KitDescription = i.kit != null ? i.kit.description : null,
                                    KitCreatedAt = i.kit != null ? i.kit.created_at : null,
                                    KitUpdatedAt = i.kit != null ? i.kit.updated_at : null



                                }));
                            }
                        }
                    }*/

















