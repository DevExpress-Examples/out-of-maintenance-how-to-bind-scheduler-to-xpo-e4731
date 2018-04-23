using System;

public class XPAppointmentViewModel : BaseViewModel<XPAppointment> {
    public string Subject { get; set; }
    public DateTime Created { get; set; }
    public DateTime Finish { get; set; }
    public bool AllDay { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public string ResourceIds { get; set; }
    public int Label { get; set; }
    public int Status { get; set; }
    public string Recurrence { get; set; }
    public int AppointmentType { get; set; }
    public string Reminder { get; set; }

    public override void GetData(XPAppointment model) {
        model.Subject = Subject;
        model.Created = Created;
        model.Finish = Finish;
        model.AllDay = AllDay;
        model.Location = Location;
        model.Description = Description;
        model.Label = Label;
        model.Status = Status;
        model.ResourceIds = ResourceIds;
        model.Recurrence = Recurrence;
        model.AppointmentType = AppointmentType;
        model.Reminder = Reminder;
    }
}