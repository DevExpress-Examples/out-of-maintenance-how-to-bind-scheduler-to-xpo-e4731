<!-- default file list -->
*Files to look at*:

* [BaseXpoController.cs](./CS/Controllers/BaseXpoController.cs) (VB: [BaseXpoController.vb](./VB/Controllers/BaseXpoController.vb))
* [HomeController.cs](./CS/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Controllers/HomeController.vb))
* [Global.asax](./CS/Global.asax) (VB: [Global.asax](./VB/Global.asax))
* [Global.asax.cs](./CS/Global.asax.cs) (VB: [Global.asax](./VB/Global.asax))
* [SchedulerHelper.cs](./CS/Helpers/SchedulerHelper.cs) (VB: [SchedulerHelper.vb](./VB/Helpers/SchedulerHelper.vb))
* [XpoHelper.cs](./CS/Helpers/XpoHelper.cs) (VB: [XpoHelper.vb](./VB/Helpers/XpoHelper.vb))
* [SchedulerDataObject.cs](./CS/Models/SchedulerDataObject.cs) (VB: [SchedulerDataObject.vb](./VB/Models/SchedulerDataObject.vb))
* [XPAppointment.cs](./CS/Models/XPAppointment.cs) (VB: [XPAppointmentViewModel.vb](./VB/ViewModels/XPAppointmentViewModel.vb))
* [XPResource.cs](./CS/Models/XPResource.cs) (VB: [XPResourceViewModel.vb](./VB/ViewModels/XPResourceViewModel.vb))
* [BaseViewModel.cs](./CS/ViewModels/BaseViewModel.cs) (VB: [BaseViewModel.vb](./VB/ViewModels/BaseViewModel.vb))
* [XPAppointmentViewModel.cs](./CS/ViewModels/XPAppointmentViewModel.cs) (VB: [XPAppointmentViewModel.vb](./VB/ViewModels/XPAppointmentViewModel.vb))
* [XPResourceViewModel.cs](./CS/ViewModels/XPResourceViewModel.cs) (VB: [XPResourceViewModel.vb](./VB/ViewModels/XPResourceViewModel.vb))
* [Index.cshtml](./CS/Views/Home/Index.cshtml)
* [SchedulerPartial.cshtml](./CS/Views/Home/SchedulerPartial.cshtml)
<!-- default file list end -->
# How to bind Scheduler to XPO


<p>This example illustrates how to bind a <a href="http://documentation.devexpress.com/#AspNet/CustomDocument11675">Scheduler extension</a> to the <a href="http://documentation.devexpress.com/#XPO/CustomDocument1998">XPO</a> datasource. As a starting point, we are using the Scheduler in the partial view (see the Note section in the <a href="http://documentation.devexpress.com/#AspNet/CustomDocument9052">Using Callbacks</a> help article). We use the <strong>SchedulerHelper </strong>class to initialize Scheduler settings for both view and controller. This allows us to implement a reliable solution according to the <a href="http://documentation.devexpress.com/#AspNet/CustomDocument11629">Lesson 3 - Use Scheduler in Complex Views</a>. This is preferable implementation, which should operate correctly in any possible scenarios. </p><p></p><p>As for data managing, we use an XPO-enabled controller from the <a href="https://www.devexpress.com/Support/Center/p/K18525">How to use XPO in an ASP.NET MVC application</a> KB article (see <strong>Approach #2</strong> in this article):</p><p></p>

```cs
public class HomeController : BaseXpoController<XPAppointment> { ... }
```

<p></p><p>The <strong>UpdateAppointment()</strong> method in this controller delegates handling to the base <strong>Save()</strong> and <strong>Delete()</strong> methods of the <strong>BaseXpoController<T></strong>. You can compare this implementation with the non-XPO version illustrated in the <a href="http://documentation.devexpress.com/#AspNet/CustomDocument11567">Lesson 2 - Implement Insert-Update-Delete Appointment Functionality</a> article. The actual data binding occurs at the view level:</p><p></p>

```cs
@Html.DevExpress().Scheduler(Html.CreateSchedulerSettings()).Bind(Model.Appointments, Model.Resources).GetHtml()
```

<p></p><p>The database connection string is adjusted in the context of  the <strong>XpoHelper</strong>class. Note that it is not necessary to create a database on your SQL Server instance beforehand because it will be created automatically by XPO according to the used models schema. These models are represented by the <strong>XPAppointment </strong>and <strong>XPResource</strong><strong> </strong>classes. They are taken from the <a href="https://www.devexpress.com/Support/Center/p/E1432">How to bind ASPxScheduler with multi-resource appointments to XPO via the Unit of Work</a> code example.</p>

<br/>


