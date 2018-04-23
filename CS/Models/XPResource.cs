using System;
using DevExpress.Xpo;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Xml;

public class XPResource : XPObject {
    public XPResource(Session session) : base(session) { }

    [Size(SizeAttribute.Unlimited)]  // !!! To set the Memo field type.
    public string Name;              // Resource.Caption

    [Association()]
    public XPCollection<XPAppointment> Appointments {
        get {
            return GetCollection<XPAppointment>("Appointments");
        }
    }
}