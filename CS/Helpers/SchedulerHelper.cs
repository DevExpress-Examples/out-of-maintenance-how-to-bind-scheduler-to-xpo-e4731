using System;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using DevExpress.XtraScheduler;

namespace SchedulerBindXPOMvc {
    public static class SchedulerHelper {
        static SchedulerSettings settings;

        public static SchedulerSettings Settings {
            get {
                if (settings == null)
                    settings = CreateSchedulerSettings(null);
                return settings;
            }
        }

        public static SchedulerSettings CreateSchedulerSettings(this HtmlHelper htmlHelper) {
            SchedulerSettings settings = new SchedulerSettings();
            settings.Name = "scheduler";
            settings.CallbackRouteValues = new { Controller = "Home", Action = "SchedulerPartial" };
            settings.EditAppointmentRouteValues = new { Controller = "Home", Action = "EditAppointment" };

            settings.Storage.Appointments.Assign(DefaultAppointmentStorage);
            settings.Storage.Resources.Assign(DefaultResourceStorage);

            settings.GroupType = SchedulerGroupType.Resource;
            settings.Storage.Appointments.ResourceSharing = true;
            settings.Start = new DateTime(2008, 7, 11);
            return settings;
        }

        static MVCxAppointmentStorage defaultAppointmentStorage;
        public static MVCxAppointmentStorage DefaultAppointmentStorage {
            get {
                if (defaultAppointmentStorage == null)
                    defaultAppointmentStorage = CreateDefaultAppointmentStorage();
                return defaultAppointmentStorage;
            }
        }
        static MVCxAppointmentStorage CreateDefaultAppointmentStorage() {
            MVCxAppointmentStorage appointmentStorage = new MVCxAppointmentStorage();
            
            appointmentStorage.Mappings.AppointmentId = "ID";
            appointmentStorage.Mappings.Subject = "Subject";
            appointmentStorage.Mappings.Start = "Created";
            appointmentStorage.Mappings.End = "Finish";
            appointmentStorage.Mappings.AllDay = "AllDay";
            appointmentStorage.Mappings.Location = "Location";
            appointmentStorage.Mappings.Description = "Description";
            appointmentStorage.Mappings.Label = "Label";
            appointmentStorage.Mappings.Status = "Status";
            appointmentStorage.Mappings.ResourceId = "ResourceIds";
            appointmentStorage.Mappings.RecurrenceInfo = "Recurrence";
            appointmentStorage.Mappings.Type = "AppointmentType";
            appointmentStorage.Mappings.ReminderInfo = "Reminder";

            return appointmentStorage;
        }

        static MVCxResourceStorage defaultResourceStorage;
        public static MVCxResourceStorage DefaultResourceStorage {
            get {
                if (defaultResourceStorage == null)
                    defaultResourceStorage = CreateDefaultResourceStorage();
                return defaultResourceStorage;
            }
        }
        static MVCxResourceStorage CreateDefaultResourceStorage() {
            MVCxResourceStorage resourceStorage = new MVCxResourceStorage();

            resourceStorage.Mappings.ResourceId = "ID";
            resourceStorage.Mappings.Caption = "Name";

            return resourceStorage;
        }
    }
}