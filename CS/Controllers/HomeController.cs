using System.Linq;
using System.Web.Mvc;
using System.Collections;
using DevExpress.Web.Mvc;
using DevExpress.Xpo;

namespace SchedulerBindXPOMvc {
    public class HomeController : BaseXpoController<XPAppointment> {
        public ActionResult Index() {
            return View(DataObject);
        }

        public ActionResult SchedulerPartial() {
            return PartialView("SchedulerPartial", DataObject);
        }

        [HttpPost]
        public ActionResult EditAppointment() {
            UpdateAppointment();
            return PartialView("SchedulerPartial", DataObject);
        }

        void UpdateAppointment() {
            XPAppointmentViewModel insertedAppt = SchedulerExtension.GetAppointmentToInsert<XPAppointmentViewModel>(
                SchedulerHelper.Settings,
                GetAppointments(),
                GetResources()
            );

            if (insertedAppt != null) 
                Save(insertedAppt);

            XPAppointmentViewModel[] updatedAppt = SchedulerExtension.GetAppointmentsToUpdate<XPAppointmentViewModel>(
                SchedulerHelper.Settings,
                GetAppointments(),
                GetResources()
            );

            foreach (var appt in updatedAppt) {
                Save(appt);
            }

            XPAppointmentViewModel[] removedAppt = SchedulerExtension.GetAppointmentsToRemove<XPAppointmentViewModel>(
                SchedulerHelper.Settings,
                GetAppointments(),
                GetResources()
            );

            foreach (var appt in removedAppt) {
                Delete(appt);
            }
        }

        public SchedulerDataObject DataObject {
            get {
                return new SchedulerDataObject() {
                    Appointments = GetAppointments(),
                    Resources = GetResources()
                };
            }
        }

        public IEnumerable GetResources() {
            return (from r in XpoSession.Query<XPResource>().ToList()
                    select new XPResourceViewModel() { ID = r.Oid, Name = r.Name }).ToList();
        }

        public IEnumerable GetAppointments() {
            return (from a in XpoSession.Query<XPAppointment>().ToList()
                    select new XPAppointmentViewModel() { 
                        ID = a.Oid, Subject = a.Subject, Created= a.Created, Finish = a.Finish, 
                        AllDay = a.AllDay, Location = a.Location, Description = a.Description,
                        Label = a.Label, Status = a.Status, ResourceIds = a.ResourceIds,
                        Recurrence = a.Recurrence, AppointmentType = a.AppointmentType,
                        Reminder = a.Reminder
                    }).ToList();
        }
    }
}